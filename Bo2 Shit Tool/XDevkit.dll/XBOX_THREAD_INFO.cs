using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct XBOX_THREAD_INFO
	{
		
		public uint ThreadId;

		
		public uint SuspendCount;

		
		public uint Priority;

		
		public uint TlsBase;

		
		public uint StartAddress;

		
		public uint StackBase;

		
		public uint StackLimit;

		
		public uint StackSlackSpace;

		
		[MarshalAs(UnmanagedType.Struct)]
		public object CreateTime;

		
		[MarshalAs(UnmanagedType.BStr)]
		public string Name;
	}
}
