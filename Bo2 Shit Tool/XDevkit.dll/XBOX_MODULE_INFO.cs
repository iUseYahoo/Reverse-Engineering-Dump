using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_MODULE_INFO
	{
		
		[MarshalAs(UnmanagedType.BStr)]
		public string Name;

		
		[MarshalAs(UnmanagedType.BStr)]
		public string FullName;

		
		public uint BaseAddress;

		
		public uint Size;

		
		public uint TimeStamp;

		
		public uint CheckSum;

		
		public XboxModuleInfoFlags Flags;
	}
}
