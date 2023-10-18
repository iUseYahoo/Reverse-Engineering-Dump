using System;
using System.Windows.Forms;

namespace Stand_Launchpad
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Launchpad());
		}
	}
}
