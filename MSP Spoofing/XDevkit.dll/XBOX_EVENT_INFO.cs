using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_EVENT_INFO
	{
		
		public XboxDebugEventType Event;

		
		public short IsThreadStopped;

		
		[MarshalAs(UnmanagedType.Interface)]
		public IXboxThread Thread;

		
		[MarshalAs(UnmanagedType.Interface)]
		public IXboxModule Module;

		
		[MarshalAs(UnmanagedType.Interface)]
		public IXboxSection Section;

		
		public XboxExecutionState ExecState;

		
		[MarshalAs(UnmanagedType.BStr)]
		public string Message;

		
		public uint Code;

		
		public uint Address;

		
		public XboxExceptionFlags Flags;

		
		public uint ParameterCount;

		
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = (UnmanagedType)80)]
		public uint[] Parameters;
	}
}
