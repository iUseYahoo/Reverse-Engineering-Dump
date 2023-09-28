using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_USER
	{
		
		[MarshalAs(UnmanagedType.BStr)]
		public string UserName;

		
		public XboxAccessFlags Access;
	}
}
