using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Stand_Launchpad.Properties;

namespace Stand_Launchpad
{
	public class Launchpad : Form
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		[DllImport("dwmapi.dll", SetLastError = true)]
		private static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttribute, int[] pvAttribute, uint cbAttribute);

		protected override void OnHandleCreated(EventArgs e)
		{
			if (Launchpad.DwmSetWindowAttribute(base.Handle, 19U, new int[]
			{
				1
			}, 4U) != 0)
			{
				Launchpad.DwmSetWindowAttribute(base.Handle, 20U, new int[]
				{
					1
				}, 4U);
			}
		}

		public Launchpad()
		{
			this.stand_dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stand";
			if (!Directory.Exists(this.stand_dir))
			{
				Directory.CreateDirectory(this.stand_dir);
			}
			if (!Directory.Exists(this.stand_dir + "\\Bin"))
			{
				Directory.CreateDirectory(this.stand_dir + "\\Bin");
			}
			if (File.Exists(this.stand_dir + "\\Bin\\Launchpad.lock"))
			{
				try
				{
					File.Delete(this.stand_dir + "\\Bin\\Launchpad.lock");
				}
				catch (Exception)
				{
					this.showMessageBox("Only one instance of the Launchpad can be open at a time.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Environment.Exit(1);
					return;
				}
			}
			this.lockfile = File.Create(this.stand_dir + "\\Bin\\Launchpad.lock");
			this.InitializeComponent();
			this.width_advanced = base.Width;
			this.Text += " 1.8.10";
			this.LauncherType.DataSource = new DropDownEntry[]
			{
				new DropDownEntry(1, "Steam"),
				new DropDownEntry(0, "Epic Games"),
				new DropDownEntry(2, "Rockstar Games")
			};
			if (Settings.Default.MustUpgrade)
			{
				Settings.Default.Upgrade();
				Settings.Default.MustUpgrade = false;
				if (Settings.Default.Version == -1)
				{
					Settings.Default.Version = 0;
				}
				Settings.Default.Save();
			}
			this.AutoInjectCheckBox.Checked = Settings.Default.AutoInject;
			this.AutoInjectDelaySeconds.Value = Settings.Default.AutoInjectDelaySeconds;
			this.LauncherType.SelectedValue = Settings.Default.GameLauncher;
			this.toggleInjectOrLaunchBtn(false);
			this.UpdateTimer.Start();
		}

		private void UpdateTimer_Tick(object sender, EventArgs e)
		{
			this.UpdateTimer.Stop();
			this.checkForUpdate(false);
			this.updateGtaPid();
			this.processGtaPidUpdate(false);
			if (this.gta_pid != 0)
			{
				this.InjectBtn.Focus();
			}
			this.ProcessScanTimer.Start();
		}

		private bool isStandDll(FileInfo file)
		{
			return file.Name.StartsWith("Stand ") && file.Name.EndsWith(".dll");
		}

		private string getStandVersionFromDll(FileInfo file)
		{
			return file.Name.Substring(6, file.Name.Length - 6 - 4);
		}

		private bool checkForUpdate(bool recheck)
		{
			Task<string> stringAsync = new HttpClient().GetStringAsync("https://stand.gg/versions.txt");
			DirectoryInfo directoryInfo = new DirectoryInfo(this.stand_dir + "\\Bin\\");
			string text = "";
			try
			{
				stringAsync.Wait();
				text = stringAsync.Result;
			}
			catch (Exception)
			{
				foreach (FileInfo file in directoryInfo.GetFiles())
				{
					if (this.isStandDll(file))
					{
						text = "1.8.10:" + this.getStandVersionFromDll(file);
					}
				}
			}
			if (text.Length == 0)
			{
				this.showMessageBox("Failed to get version information. Ensure you're connected to the internet and have no anti-virus program or firewall interfering.", MessageBoxButtons.OK, MessageBoxIcon.None);
				if (recheck)
				{
					return false;
				}
				Application.Exit();
			}
			this.versions = text.Split(new char[]
			{
				':'
			});
			if (recheck)
			{
				this.saveSettings();
				this.DllList.Items.Clear();
			}
			if (!Settings.Default.Advanced)
			{
				this.updateAdvancedMode();
			}
			this.DllList.Items.Add("Stand " + this.versions[1]);
			if (Settings.Default.CustomDll != "")
			{
				foreach (string text2 in Settings.Default.CustomDll.Split(new char[]
				{
					'|'
				}))
				{
					this.DllList.Items.Add(text2);
				}
			}
			for (int j = 0; j < Settings.Default.InjectDll.Length; j++)
			{
				if (Settings.Default.InjectDll.Substring(j, 1) == "1")
				{
					this.DllList.Items[j].Checked = true;
				}
			}
			bool result = false;
			this.stand_dll = this.stand_dir + "\\Bin\\Stand " + this.versions[1] + ".dll";
			if (!File.Exists(this.stand_dll))
			{
				if (this.downloadStandDll())
				{
					foreach (FileInfo fileInfo in directoryInfo.GetFiles())
					{
						if (this.isStandDll(fileInfo) && this.getStandVersionFromDll(fileInfo) != this.versions[1])
						{
							try
							{
								fileInfo.Delete();
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.ToString());
							}
						}
					}
				}
				result = true;
			}
			if (this.versions[0] != "1.8.10")
			{
				if (this.showMessageBox("Launchpad " + this.versions[0] + " is available. Would you like to download it?", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
				{
					Process.Start("https://stand.gg/launchpad_update");
				}
				result = true;
			}
			return result;
		}

		private void onDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
		{
			this.download_progress = e.ProgressPercentage;
		}

		private void onDownloadComplete(object sender, AsyncCompletedEventArgs e)
		{
			object userState = e.UserState;
			lock (userState)
			{
				Monitor.Pulse(e.UserState);
			}
		}

		private bool downloadStandDll()
		{
			bool result = true;
			this.InfoText.Text = "Downloading Stand " + this.versions[1] + "...";
			this.download_progress = 0;
			this.progressBar1.Show();
			Task task = Task.Run(delegate()
			{
				WebClient webClient = new WebClient();
				webClient.DownloadProgressChanged += this.onDownloadProgress;
				webClient.DownloadFileCompleted += this.onDownloadComplete;
				object obj = new object();
				object obj2 = obj;
				lock (obj2)
				{
					webClient.DownloadFileAsync(new Uri("https://stand.gg/Stand%20" + this.versions[1] + ".dll"), this.stand_dll + ".tmp", obj);
					Monitor.Wait(obj);
				}
			});
			do
			{
				this.progressBar1.Value = this.download_progress;
			}
			while (!task.Wait(20));
			File.Move(this.stand_dll + ".tmp", this.stand_dll);
			if (new FileInfo(this.stand_dll).Length < 1024L)
			{
				File.Delete(this.stand_dll);
				this.showMessageBox("It looks like the DLL download has failed. Ensure you have no anti-virus program interfering.", MessageBoxButtons.OK, MessageBoxIcon.None);
				result = false;
			}
			this.progressBar1.Hide();
			return result;
		}

		private void ProcessScanTimer_Tick(object sender, EventArgs e)
		{
			if (this.updateGtaPid())
			{
				this.processGtaPidUpdate(this.can_auto_inject);
			}
		}

		private bool updateGtaPid()
		{
			Process[] processes = Process.GetProcesses();
			int i = 0;
			while (i < processes.Length)
			{
				Process process = processes[i];
				if (process.ProcessName == "GTA5")
				{
					if (this.gta_pid == process.Id)
					{
						return false;
					}
					this.gta_pid = process.Id;
					this.game_was_open = true;
					return true;
				}
				else
				{
					i++;
				}
			}
			this.AutoInjectTimer.Stop();
			bool result = this.gta_pid != 0;
			this.gta_pid = 0;
			return result;
		}

		private void processGtaPidUpdate(bool proc_can_auto_inject)
		{
			bool flag = this.gta_pid != 0;
			this.toggleInjectOrLaunchBtn(flag);
			if (!flag)
			{
				this.InfoText.Text = "Ready to inject; just start the game.";
				if (this.game_was_open)
				{
					this.game_was_open = false;
					this.can_auto_inject = false;
					this.GameClosedTimer.Start();
				}
				return;
			}
			if (!this.AutoInjectCheckBox.Checked || !proc_can_auto_inject)
			{
				this.InfoText.Text = "Ready to inject.";
				return;
			}
			if (Settings.Default.Advanced && this.AutoInjectDelaySeconds.Value > 0m)
			{
				this.InfoText.Text = "Automatically injecting in a few seconds...";
				this.AutoInjectTimer.Interval = (int)this.AutoInjectDelaySeconds.Value * 1000;
				this.AutoInjectTimer.Start();
				return;
			}
			this.inject();
		}

		private void InjectBtn_Click(object sender, EventArgs e)
		{
			this.inject();
		}

		private void AutoInjectTimer_Tick(object sender, EventArgs e)
		{
			this.inject();
		}

		private void inject()
		{
			bool flag = false;
			this.AutoInjectTimer.Stop();
			this.ProcessScanTimer.Stop();
			this.InjectBtn.Enabled = false;
			List<string> list = new List<string>();
			if (Settings.Default.Advanced)
			{
				for (int i = 0; i < this.DllList.Items.Count; i++)
				{
					if (this.DllList.Items[i].Checked)
					{
						list.Add((i == 0) ? this.stand_dll : this.DllList.Items[i].Text);
					}
				}
			}
			else
			{
				list.Add(this.stand_dll);
			}
			if (list.Contains(this.stand_dll) && !File.Exists(this.stand_dll) && !this.downloadStandDll())
			{
				list.Remove(this.stand_dll);
			}
			this.InfoText.Text = "Injecting...";
			int num = 0;
			IntPtr intPtr = Launchpad.OpenProcess(1082U, 1, (uint)this.gta_pid);
			if (intPtr == IntPtr.Zero)
			{
				Console.WriteLine("Failed to get a hold of the game's process.");
			}
			else
			{
				IntPtr procAddress = Launchpad.GetProcAddress(Launchpad.GetModuleHandle("kernel32.dll"), "LoadLibraryW");
				if (procAddress == IntPtr.Zero)
				{
					Console.WriteLine("Failed to find LoadLibraryW.");
				}
				else
				{
					string text = this.stand_dir + "\\Bin\\Temp";
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					else
					{
						foreach (FileInfo fileInfo in new DirectoryInfo(text).GetFiles())
						{
							try
							{
								fileInfo.Delete();
							}
							catch (Exception)
							{
							}
						}
					}
					try
					{
						foreach (string text2 in list)
						{
							if (!File.Exists(text2))
							{
								Console.WriteLine("Couldn't inject " + text2 + " because the file doesn't exist.");
							}
							else
							{
								string text3 = text + "\\SL_" + Launchpad.generateRandomString(5) + ".dll";
								File.Copy(text2, text3);
								byte[] bytes = Encoding.Unicode.GetBytes(text3);
								IntPtr intPtr2 = Launchpad.VirtualAllocEx(intPtr, (IntPtr)null, (IntPtr)bytes.Length, 12288U, 64U);
								if (intPtr2 == IntPtr.Zero)
								{
									Console.WriteLine("Couldn't allocate the bytes to represent " + text2);
								}
								else if (Launchpad.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, 0) == 0)
								{
									Console.WriteLine("Couldn't write " + text3 + " to allocated memory");
								}
								else if (Launchpad.CreateRemoteThread(intPtr, (IntPtr)null, IntPtr.Zero, procAddress, intPtr2, 0U, (IntPtr)null) == IntPtr.Zero)
								{
									Console.WriteLine("Failed to create remote thread for " + text2);
								}
								else
								{
									num++;
								}
							}
						}
					}
					catch (IOException)
					{
						base.Activate();
						flag = true;
						this.showMessageBox("Your antivirus seems to be preventing injection.\nDisable your anti virus or add an exclusion and try again.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				Launchpad.CloseHandle(intPtr);
			}
			Control infoText = this.InfoText;
			string[] array = new string[5];
			array[0] = "Injected ";
			array[1] = num.ToString();
			array[2] = "/";
			int num2 = 3;
			int j = list.Count;
			array[num2] = j.ToString();
			array[4] = " DLLs.";
			infoText.Text = string.Concat(array);
			if (num == 0)
			{
				if (!this.any_successful_injection && list.Count != 0 && !flag)
				{
					this.showMessageBox("No DLL was injected. You may need to start the Launchpad as Administrator.", MessageBoxButtons.OK, MessageBoxIcon.None);
				}
				this.EnableReInject();
				return;
			}
			this.any_successful_injection = true;
			this.ReInjectTimer.Start();
		}

		private static string generateRandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[Launchpad.random.Next(s.Length)]).ToArray<char>());
		}

		private DialogResult showMessageBox(string message, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
		{
			return MessageBox.Show(message, "Stand Launchpad 1.8.10", buttons, icon);
		}

		private void Launchpad_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.AutoInject = this.AutoInjectCheckBox.Checked;
			Settings.Default.AutoInjectDelaySeconds = (int)this.AutoInjectDelaySeconds.Value;
			Settings.Default.GameLauncher = ((DropDownEntry)this.LauncherType.SelectedItem).Id;
			this.saveSettings();
			this.lockfile.Close();
			File.Delete(this.stand_dir + "\\Bin\\Launchpad.lock");
		}

		private void saveSettings()
		{
			Settings.Default.InjectDll = "";
			Settings.Default.CustomDll = "";
			for (int i = 0; i < this.DllList.Items.Count; i++)
			{
				Settings @default = Settings.Default;
				@default.InjectDll += (this.DllList.Items[i].Checked ? "1" : "0");
				if (i != 0)
				{
					Settings default2 = Settings.Default;
					default2.CustomDll = default2.CustomDll + this.DllList.Items[i].Text + "|";
				}
			}
			if (Settings.Default.CustomDll != "")
			{
				Settings.Default.CustomDll = Settings.Default.CustomDll.Substring(0, Settings.Default.CustomDll.Length - 1);
			}
			Settings.Default.Save();
		}

		private void CustomDllDialog_FileOk(object sender, CancelEventArgs e)
		{
			this.addDll(this.CustomDllDialog.FileName);
		}

		private void addDll(string path)
		{
			this.DllList.Items[this.DllList.Items.Add(path).Index].Checked = true;
		}

		private void AdvancedBtn_Click(object sender, EventArgs e)
		{
			Settings.Default.Advanced = !Settings.Default.Advanced;
			this.updateAdvancedMode();
		}

		private void updateAdvancedMode()
		{
			if (Settings.Default.Advanced)
			{
				base.Width = this.width_advanced;
				base.MinimizeBox = true;
				this.InjectBtn.Text = "Inject";
				this.AutoInjectDelaySeconds.Visible = true;
				this.AddBtn.TabStop = true;
				this.RemoveBtn.TabStop = true;
				this.DllList.Visible = true;
				return;
			}
			base.MinimizeBox = false;
			base.Width = 248;
			this.InjectBtn.Text = "Inject Stand " + this.versions[1];
			this.AutoInjectDelaySeconds.Visible = false;
			this.AddBtn.TabStop = false;
			this.RemoveBtn.TabStop = false;
			this.DllList.Visible = false;
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			this.CustomDllDialog.ShowDialog();
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			this.removeSelectedDll();
		}

		private void removeSelectedDll()
		{
			if (this.DllList.SelectedItems.Count != 1)
			{
				for (int i = this.DllList.Items.Count - 1; i > 0; i--)
				{
					if (this.DllList.Items[i].Selected)
					{
						this.DllList.Items.RemoveAt(i);
					}
				}
				return;
			}
			int num = this.DllList.SelectedIndices[0];
			if (num == 0)
			{
				return;
			}
			this.DllList.Items.RemoveAt(num);
			if (this.DllList.Items.Count > num && this.DllList.Items[num] != null)
			{
				this.DllList.Items[num].Selected = true;
				return;
			}
			this.DllList.Items[num - 1].Selected = true;
		}

		private void AutoInjectCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.AutoInjectCheckBox.Checked && this.AutoInjectTimer.Enabled)
			{
				this.AutoInjectTimer.Stop();
				this.InfoText.Text = "You may inject now.";
			}
		}

		private void GameClosedTimer_Tick(object sender, EventArgs e)
		{
			this.GameClosedTimer.Stop();
			this.can_auto_inject = true;
		}

		private void ChangelogBtn_Click(object sender, EventArgs e)
		{
			new Changelog().Show();
		}

		private void ReInjectTimer_Tick(object sender, EventArgs e)
		{
			this.ReInjectTimer.Stop();
			this.EnableReInject();
		}

		private void EnableReInject()
		{
			this.InjectBtn.Enabled = true;
			this.ProcessScanTimer.Start();
		}

		private void StandFolderBtn_Click(object sender, EventArgs e)
		{
			Process.Start(this.stand_dir);
		}

		private void UpdCheckBtn_Click(object sender, EventArgs e)
		{
			if (!this.checkForUpdate(true))
			{
				this.showMessageBox("Everything up-to-date.", MessageBoxButtons.OK, MessageBoxIcon.None);
			}
			this.processGtaPidUpdate(false);
		}

		private void DllList_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		private void DllList_DragDrop(object sender, DragEventArgs e)
		{
			foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop))
			{
				this.addDll(path);
			}
		}

		private void DllList_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				this.removeSelectedDll();
			}
		}

		private void LaunchBtn_Click(object sender, EventArgs e)
		{
			switch (((DropDownEntry)this.LauncherType.SelectedItem).Id)
			{
			case 0:
				Process.Start("com.epicgames.launcher://apps/9d2d0eb64d5c44529cece33fe2a46482?action=launch&silent=true");
				return;
			case 1:
			{
				object value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", null);
				if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
				{
					Process.Start("steam://run/271590");
					return;
				}
				this.showMessageBox("Whoops, looks like Steam isn't installed. Try selecting a different launcher in the dropdown.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			case 2:
				try
				{
					using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Rockstar Games\\Launcher"))
					{
						string text = (string)((registryKey != null) ? registryKey.GetValue("InstallFolder") : null);
						if (text != null)
						{
							Process.Start(text + "\\Launcher.exe", "-minmodeApp=gta5");
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
				return;
			default:
				return;
			}
		}

		private void LauncherType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LaunchBtn.Focus();
		}

		private void toggleInjectOrLaunchBtn(bool gameRunning)
		{
			this.InjectBtn.Visible = gameRunning;
			this.LauncherType.Visible = (this.LaunchBtn.Visible = !gameRunning);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Launchpad));
			this.InjectBtn = new Button();
			this.ProcessScanTimer = new System.Windows.Forms.Timer(this.components);
			this.InfoText = new Label();
			this.AutoInjectCheckBox = new CheckBox();
			this.CustomDllDialog = new OpenFileDialog();
			this.AdvancedBtn = new Button();
			this.AddBtn = new Button();
			this.RemoveBtn = new Button();
			this.AutoInjectDelaySeconds = new NumericUpDown();
			this.AutoInjectDelayLabel = new Label();
			this.AutoInjectTimer = new System.Windows.Forms.Timer(this.components);
			this.GameClosedTimer = new System.Windows.Forms.Timer(this.components);
			this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.ChanglogBtn = new Button();
			this.ReInjectTimer = new System.Windows.Forms.Timer(this.components);
			this.StandFolderBtn = new Button();
			this.UpdCheckBtn = new Button();
			this.DllList = new ListView();
			this.Column = new ColumnHeader();
			this.LauncherType = new ComboBox();
			this.dropDownEntryBindingSource = new BindingSource(this.components);
			this.LaunchBtn = new Button();
			this.progressBar1 = new ProgressBar();
			((ISupportInitialize)this.AutoInjectDelaySeconds).BeginInit();
			((ISupportInitialize)this.dropDownEntryBindingSource).BeginInit();
			base.SuspendLayout();
			this.InjectBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.InjectBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.InjectBtn.FlatStyle = FlatStyle.Flat;
			this.InjectBtn.Location = new Point(12, 12);
			this.InjectBtn.Name = "InjectBtn";
			this.InjectBtn.Size = new Size(208, 23);
			this.InjectBtn.TabIndex = 0;
			this.InjectBtn.Text = "Inject";
			this.InjectBtn.TextAlign = ContentAlignment.MiddleLeft;
			this.InjectBtn.UseVisualStyleBackColor = false;
			this.InjectBtn.Click += this.InjectBtn_Click;
			this.ProcessScanTimer.Interval = 1000;
			this.ProcessScanTimer.Tick += this.ProcessScanTimer_Tick;
			this.InfoText.AutoSize = true;
			this.InfoText.Location = new Point(9, 153);
			this.InfoText.Name = "InfoText";
			this.InfoText.Size = new Size(117, 13);
			this.InfoText.TabIndex = 9;
			this.InfoText.Text = "Checking for updates...";
			this.AutoInjectCheckBox.AutoSize = true;
			this.AutoInjectCheckBox.FlatStyle = FlatStyle.Flat;
			this.AutoInjectCheckBox.ForeColor = Color.White;
			this.AutoInjectCheckBox.Location = new Point(12, 41);
			this.AutoInjectCheckBox.Name = "AutoInjectCheckBox";
			this.AutoInjectCheckBox.Size = new Size(202, 17);
			this.AutoInjectCheckBox.TabIndex = 4;
			this.AutoInjectCheckBox.Text = "Automatically inject when game starts.";
			this.AutoInjectCheckBox.UseVisualStyleBackColor = true;
			this.AutoInjectCheckBox.CheckedChanged += this.AutoInjectCheckBox_CheckedChanged;
			this.CustomDllDialog.Filter = "DLL files|*.dll|All files|*.*";
			this.CustomDllDialog.FileOk += this.CustomDllDialog_FileOk;
			this.AdvancedBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.AdvancedBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.AdvancedBtn.FlatStyle = FlatStyle.Flat;
			this.AdvancedBtn.Location = new Point(12, 122);
			this.AdvancedBtn.Name = "AdvancedBtn";
			this.AdvancedBtn.Size = new Size(208, 23);
			this.AdvancedBtn.TabIndex = 8;
			this.AdvancedBtn.Text = "Advanced";
			this.AdvancedBtn.TextAlign = ContentAlignment.MiddleLeft;
			this.AdvancedBtn.UseVisualStyleBackColor = false;
			this.AdvancedBtn.Click += this.AdvancedBtn_Click;
			this.AddBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.AddBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.AddBtn.FlatStyle = FlatStyle.Flat;
			this.AddBtn.Location = new Point(567, 12);
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new Size(47, 23);
			this.AddBtn.TabIndex = 12;
			this.AddBtn.Text = "Add";
			this.AddBtn.UseVisualStyleBackColor = false;
			this.AddBtn.Click += this.AddBtn_Click;
			this.RemoveBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.RemoveBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.RemoveBtn.FlatStyle = FlatStyle.Flat;
			this.RemoveBtn.Location = new Point(620, 12);
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new Size(65, 23);
			this.RemoveBtn.TabIndex = 13;
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.UseVisualStyleBackColor = false;
			this.RemoveBtn.Click += this.RemoveBtn_Click;
			this.AutoInjectDelaySeconds.BackColor = Color.FromArgb(17, 17, 17);
			this.AutoInjectDelaySeconds.ForeColor = Color.White;
			this.AutoInjectDelaySeconds.Location = new Point(415, 15);
			NumericUpDown autoInjectDelaySeconds = this.AutoInjectDelaySeconds;
			int[] array = new int[4];
			array[0] = 60;
			autoInjectDelaySeconds.Maximum = new decimal(array);
			this.AutoInjectDelaySeconds.Name = "AutoInjectDelaySeconds";
			this.AutoInjectDelaySeconds.Size = new Size(45, 20);
			this.AutoInjectDelaySeconds.TabIndex = 11;
			this.AutoInjectDelayLabel.AutoSize = true;
			this.AutoInjectDelayLabel.ForeColor = Color.White;
			this.AutoInjectDelayLabel.Location = new Point(232, 17);
			this.AutoInjectDelayLabel.Name = "AutoInjectDelayLabel";
			this.AutoInjectDelayLabel.Size = new Size(181, 13);
			this.AutoInjectDelayLabel.TabIndex = 10;
			this.AutoInjectDelayLabel.Text = "Automatic Injection Delay (Seconds):";
			this.AutoInjectTimer.Interval = 1;
			this.AutoInjectTimer.Tick += this.AutoInjectTimer_Tick;
			this.GameClosedTimer.Interval = 10000;
			this.GameClosedTimer.Tick += this.GameClosedTimer_Tick;
			this.UpdateTimer.Interval = 1;
			this.UpdateTimer.Tick += this.UpdateTimer_Tick;
			this.ChanglogBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.ChanglogBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.ChanglogBtn.FlatStyle = FlatStyle.Flat;
			this.ChanglogBtn.ForeColor = Color.White;
			this.ChanglogBtn.Location = new Point(146, 64);
			this.ChanglogBtn.Name = "ChanglogBtn";
			this.ChanglogBtn.Size = new Size(74, 23);
			this.ChanglogBtn.TabIndex = 6;
			this.ChanglogBtn.Text = "Changelog";
			this.ChanglogBtn.TextAlign = ContentAlignment.MiddleLeft;
			this.ChanglogBtn.UseVisualStyleBackColor = false;
			this.ChanglogBtn.Click += this.ChangelogBtn_Click;
			this.ReInjectTimer.Interval = 3000;
			this.ReInjectTimer.Tick += this.ReInjectTimer_Tick;
			this.StandFolderBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.StandFolderBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.StandFolderBtn.FlatStyle = FlatStyle.Flat;
			this.StandFolderBtn.Location = new Point(12, 93);
			this.StandFolderBtn.Name = "StandFolderBtn";
			this.StandFolderBtn.Size = new Size(208, 23);
			this.StandFolderBtn.TabIndex = 7;
			this.StandFolderBtn.Text = "Open Stand Folder";
			this.StandFolderBtn.TextAlign = ContentAlignment.MiddleLeft;
			this.StandFolderBtn.UseVisualStyleBackColor = false;
			this.StandFolderBtn.Click += this.StandFolderBtn_Click;
			this.UpdCheckBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.UpdCheckBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.UpdCheckBtn.FlatStyle = FlatStyle.Flat;
			this.UpdCheckBtn.ForeColor = Color.White;
			this.UpdCheckBtn.Location = new Point(12, 64);
			this.UpdCheckBtn.Name = "UpdCheckBtn";
			this.UpdCheckBtn.Size = new Size(128, 23);
			this.UpdCheckBtn.TabIndex = 5;
			this.UpdCheckBtn.Text = "Check For Updates";
			this.UpdCheckBtn.TextAlign = ContentAlignment.MiddleLeft;
			this.UpdCheckBtn.UseVisualStyleBackColor = false;
			this.UpdCheckBtn.Click += this.UpdCheckBtn_Click;
			this.DllList.AllowDrop = true;
			this.DllList.BackColor = Color.FromArgb(17, 17, 17);
			this.DllList.BorderStyle = BorderStyle.FixedSingle;
			this.DllList.CheckBoxes = true;
			this.DllList.Columns.AddRange(new ColumnHeader[]
			{
				this.Column
			});
			this.DllList.ForeColor = SystemColors.Window;
			this.DllList.HideSelection = false;
			this.DllList.Location = new Point(235, 41);
			this.DllList.Margin = new Padding(6);
			this.DllList.Name = "DllList";
			this.DllList.Size = new Size(450, 122);
			this.DllList.TabIndex = 14;
			this.DllList.UseCompatibleStateImageBehavior = false;
			this.DllList.View = View.List;
			this.DllList.DragDrop += this.DllList_DragDrop;
			this.DllList.DragOver += this.DllList_DragOver;
			this.DllList.KeyUp += this.DllList_KeyUp;
			this.Column.Text = "";
			this.Column.Width = 450;
			this.LauncherType.BackColor = Color.FromArgb(37, 40, 43);
			this.LauncherType.DataSource = this.dropDownEntryBindingSource;
			this.LauncherType.DisplayMember = "Name";
			this.LauncherType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.LauncherType.FlatStyle = FlatStyle.Flat;
			this.LauncherType.ForeColor = SystemColors.Window;
			this.LauncherType.FormattingEnabled = true;
			this.LauncherType.ItemHeight = 13;
			this.LauncherType.Location = new Point(92, 14);
			this.LauncherType.Name = "LauncherType";
			this.LauncherType.Size = new Size(128, 21);
			this.LauncherType.TabIndex = 2;
			this.LauncherType.ValueMember = "Id";
			this.LauncherType.SelectedIndexChanged += this.LauncherType_SelectedIndexChanged;
			this.dropDownEntryBindingSource.DataSource = typeof(DropDownEntry);
			this.LaunchBtn.BackColor = Color.FromArgb(37, 40, 43);
			this.LaunchBtn.FlatAppearance.BorderColor = Color.FromArgb(22, 25, 29);
			this.LaunchBtn.FlatStyle = FlatStyle.Flat;
			this.LaunchBtn.Location = new Point(12, 12);
			this.LaunchBtn.Name = "LaunchBtn";
			this.LaunchBtn.Size = new Size(74, 23);
			this.LaunchBtn.TabIndex = 1;
			this.LaunchBtn.Text = "Launch";
			this.LaunchBtn.UseVisualStyleBackColor = false;
			this.LaunchBtn.Click += this.LaunchBtn_Click;
			this.progressBar1.Location = new Point(12, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new Size(208, 23);
			this.progressBar1.TabIndex = 0;
			this.progressBar1.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(17, 17, 17);
			base.ClientSize = new Size(694, 175);
			base.Controls.Add(this.progressBar1);
			base.Controls.Add(this.LaunchBtn);
			base.Controls.Add(this.LauncherType);
			base.Controls.Add(this.DllList);
			base.Controls.Add(this.UpdCheckBtn);
			base.Controls.Add(this.StandFolderBtn);
			base.Controls.Add(this.ChanglogBtn);
			base.Controls.Add(this.AutoInjectDelayLabel);
			base.Controls.Add(this.AutoInjectDelaySeconds);
			base.Controls.Add(this.RemoveBtn);
			base.Controls.Add(this.AddBtn);
			base.Controls.Add(this.AdvancedBtn);
			base.Controls.Add(this.AutoInjectCheckBox);
			base.Controls.Add(this.InfoText);
			base.Controls.Add(this.InjectBtn);
			this.ForeColor = Color.White;
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Launchpad";
			this.Text = "Stand Launchpad";
			base.FormClosing += this.Launchpad_FormClosing;
			((ISupportInitialize)this.AutoInjectDelaySeconds).EndInit();
			((ISupportInitialize)this.dropDownEntryBindingSource).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private static Random random = new Random();

		private const string launchpad_update_version = "1.8.10";

		private const string launchpad_display_version = "1.8.10";

		private string stand_dir;

		private FileStream lockfile;

		private string stand_dll;

		private const int width_simple = 248;

		private readonly int width_advanced;

		private string[] versions;

		private int download_progress;

		private int gta_pid;

		private bool game_was_open;

		private bool can_auto_inject = true;

		private bool any_successful_injection;

		private IContainer components;

		private Button InjectBtn;

		private Label InfoText;

		private CheckBox AutoInjectCheckBox;

		private OpenFileDialog CustomDllDialog;

		private Button AdvancedBtn;

		private System.Windows.Forms.Timer ProcessScanTimer;

		private Button AddBtn;

		private Button RemoveBtn;

		private NumericUpDown AutoInjectDelaySeconds;

		private Label AutoInjectDelayLabel;

		private System.Windows.Forms.Timer AutoInjectTimer;

		private System.Windows.Forms.Timer GameClosedTimer;

		private System.Windows.Forms.Timer UpdateTimer;

		private Button ChanglogBtn;

		private System.Windows.Forms.Timer ReInjectTimer;

		private Button StandFolderBtn;

		private Button UpdCheckBtn;

		private ListView DllList;

		private ComboBox LauncherType;

		private BindingSource dropDownEntryBindingSource;

		private Button LaunchBtn;

		private ProgressBar progressBar1;

		private ColumnHeader Column;
	}
}
