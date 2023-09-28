using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4288)]
	[Guid("978B90D1-1F44-4ADC-B992-12AF5DBE16E2")]
	[ComImport]
	public interface IXboxExecutableInfo
	{
		
		
		[DispId(1)]
		string SymbolGuid { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		
		[DispId(2)]
		string XboxExecutablePath { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		
		[DispId(3)]
		string PortableExecutablePath { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		
		[DispId(4)]
		string SymbolPath { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		
		[DispId(5)]
		string PublicSymbolPath { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		
		[DispId(6)]
		string ModuleName { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		
		[DispId(7)]
		uint TimeDateStamp { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(8)]
		uint SizeOfImage { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(9)]
		bool StoreRelativePath { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		
		[DispId(10)]
		string BasePath { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		
		
		
		[DispId(11)]
		bool PropGetRelativePath { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
