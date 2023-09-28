using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("4B103593-DB52-4E18-913D-B3B17824BD76")]
	[TypeLibType(4288)]
	[ComImport]
	public interface IXboxExecutable
	{
		
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetPEModuleName();
	}
}
