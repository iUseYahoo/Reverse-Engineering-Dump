using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("D5EE3179-7955-41B4-A507-BD78EFC462C9")]
	[TypeLibType(4288)]
	[ComImport]
	public interface IXboxUsers : IEnumerable
	{
		
		[DispId(0)]
		IXboxUser this[[In] int Index]
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
