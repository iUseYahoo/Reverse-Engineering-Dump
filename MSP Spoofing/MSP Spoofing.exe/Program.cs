using System;
using System.Windows.Forms;

namespace MSP_SPoofing
{
	
	internal static class Program
	{
		
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
