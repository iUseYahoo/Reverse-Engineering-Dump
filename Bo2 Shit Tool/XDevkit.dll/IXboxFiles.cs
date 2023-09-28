using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4288)]
	[Guid("DFCF3F84-5394-448D-BCAC-E30AF6C840E1")]
	[ComImport]
	public interface IXboxFiles : IEnumerable
	{
		
		[DispId(0)]
		IXboxFile this[[In] int Index]
		{
			[DispId(0)]
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
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
