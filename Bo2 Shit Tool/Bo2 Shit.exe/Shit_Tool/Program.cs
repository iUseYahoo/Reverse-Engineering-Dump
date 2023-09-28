using System;
using System.Windows.Forms;

namespace Shit_Tool
{
	
	internal static class Program
	{
		
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new GForm2());
		}
	}
}
