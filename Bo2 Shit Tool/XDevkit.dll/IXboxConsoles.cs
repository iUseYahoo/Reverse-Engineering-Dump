using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4288)]
	[Guid("110980E4-F8D4-45F1-8A86-90D86FD4A879")]
	[ComImport]
	public interface IXboxConsoles : IEnumerable
	{
		
		[DispId(0)]
		string this[[In] int Index]
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		
		
		[DispId(1)]
		int Count { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		[DispId(-4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler)]
		IEnumerator GetEnumerator();
	}
}
