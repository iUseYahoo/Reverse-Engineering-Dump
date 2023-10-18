using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stand_Launchpad
{
	public class Changelog : Form
	{
		[DllImport("dwmapi.dll")]
		private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

		public Changelog()
		{
			this.InitializeComponent();
			if (Changelog.DwmSetWindowAttribute(base.Handle, 19, new int[]
			{
				1
			}, 4) != 0)
			{
				Changelog.DwmSetWindowAttribute(base.Handle, 20, new int[]
				{
					1
				}, 4);
			}
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
			this.webBrowser1 = new WebBrowser();
			base.SuspendLayout();
			this.webBrowser1.Dock = DockStyle.Fill;
			this.webBrowser1.Location = new Point(0, 0);
			this.webBrowser1.MinimumSize = new Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new Size(800, 450);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.Url = new Uri("https://stand.gg/help/changelog-launchpad", UriKind.Absolute);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(800, 450);
			base.Controls.Add(this.webBrowser1);
			base.Name = "Changelog";
			this.Text = "Changelog";
			base.Icon = (Icon)new ComponentResourceManager(typeof(Launchpad)).GetObject("$this.Icon");
			base.ResumeLayout(false);
		}

		private IContainer components;

		private WebBrowser webBrowser1;
	}
}
