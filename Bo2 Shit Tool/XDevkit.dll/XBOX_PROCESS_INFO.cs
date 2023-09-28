using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_PROCESS_INFO
	{
		
		public uint ProcessId;

		
		[MarshalAs(UnmanagedType.BStr)]
		public string ProgramName;
	}
}
