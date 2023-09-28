using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4288)]
	[Guid("7F8E857B-FD59-4B67-8156-FAA3FD06D1E5")]
	[ComImport]
	public interface IXboxMemoryRegions : IEnumerable
	{
		
		[DispId(0)]
		IXboxMemoryRegion this[[In] int Index]
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
