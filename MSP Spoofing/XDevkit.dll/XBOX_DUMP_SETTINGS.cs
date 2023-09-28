using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_DUMP_SETTINGS
	{
		
		public XboxDumpReportFlags Flags;

		
		[MarshalAs(UnmanagedType.BStr)]
		public string NetworkPath;
	}
}
