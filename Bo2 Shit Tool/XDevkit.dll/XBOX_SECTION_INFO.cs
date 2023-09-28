using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_SECTION_INFO
	{
		
		[MarshalAs(UnmanagedType.BStr)]
		public string Name;

		
		public uint BaseAddress;

		
		public uint Size;

		
		public uint Index;

		
		public XboxSectionInfoFlags Flags;
	}
}
