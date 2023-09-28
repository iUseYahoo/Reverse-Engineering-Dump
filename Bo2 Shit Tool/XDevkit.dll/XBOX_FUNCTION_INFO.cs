using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_FUNCTION_INFO
	{
		
		public XboxFunctionType FunctionType;

		
		public uint BeginAddress;

		
		public uint PrologEndAddress;

		
		public uint FunctionEndAddress;
	}
}
