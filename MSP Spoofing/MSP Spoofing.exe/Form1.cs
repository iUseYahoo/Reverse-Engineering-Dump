using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using JRPC_Client;
using XDevkit;

namespace MSP_SPoofing
{
	
	public class Form1 : Form
	{
		
		public Form1()
		{
			this.InitializeComponent();
		}

		
		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = this.jtag.Connect(out this.jtag, "default");
			if (flag)
			{
				MessageBox.Show("Connected to default RGH", "Connection successful!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.label2.ForeColor = Color.Green;
				this.label2.Text = "Connected";
			}
			else
			{
				MessageBox.Show("Unable to connect to your console", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.label2.ForeColor = Color.Red;
				this.label2.Text = "Not connected";
			}
		}

		
		private void button2_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				56,
				128,
				0,
				5,
				128,
				99,
				0,
				28,
				144,
				131,
				0,
				4,
				56,
				128,
				9,
				196,
				144,
				131,
				0,
				8,
				56,
				96,
				0,
				0,
				78,
				128,
				0,
				32
			};
			IXboxConsole console = this.jtag;
			object[] arguments = new object[]
			{
				"Guide.MP.Purchase.xex"
			};
			uint num;
			IXboxConsole console2;
			object[] arguments2;
			for (num = console.Call("xam.xex", 1102, arguments); num == 0U; num = console2.Call("xam.xex", 1102, arguments2))
			{
				console2 = this.jtag;
				arguments2 = new object[]
				{
					"Guide.MP.Purchase.xex"
				};
			}
			bool flag = num == 0U;
			if (!flag)
			{
				this.jtag.SetMemory(2171119352U, data);
				this.jtag.WriteInt32(2173606884U, 1610612736);
				this.jtag.WriteInt32(2173625364U, 1207959752);
				this.jtag.WriteInt32(2417350752U, 1610612736);
				this.jtag.WriteInt32(2417350948U, 1610612736);
				MessageBox.Show("You are now spoofing your MSP.", "IMPORTANT!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			this.button1 = new Button();
			this.button2 = new Button();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			base.SuspendLayout();
			this.button1.Location = new Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new Size(285, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			this.button2.Location = new Point(12, 41);
			this.button2.Name = "button2";
			this.button2.Size = new Size(285, 89);
			this.button2.TabIndex = 1;
			this.button2.Text = "Spoof MSP";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += this.button2_Click;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 138);
			this.label1.Name = "label1";
			this.label1.Size = new Size(64, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Connection:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(82, 138);
			this.label2.Name = "label2";
			this.label2.Size = new Size(35, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "status";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(181, 138);
			this.label3.Name = "label3";
			this.label3.Size = new Size(116, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Created by HYX [2022]";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(309, 160);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Form1";
			this.Text = "MSP Spoofing 17599";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		
		private IXboxConsole jtag;

		
		private IContainer components = null;

		
		private Button button1;

		
		private Button button2;

		
		private Label label1;

		
		private Label label2;

		
		private Label label3;
	}
}
