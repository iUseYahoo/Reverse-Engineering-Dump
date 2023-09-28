using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4288)]
	[Guid("CB8E47BA-2673-48AF-B0C5-FD5738FFCC6B")]
	[ComImport]
	public interface IXboxExecutableDatabase
	{
		
		
		[DispId(1)]
		bool IsDirty { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(2)]
		string CurrentFileName { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		[DispId(100)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void LoadDatabase([MarshalAs(UnmanagedType.BStr)] [In] string DatabaseFile, [In] bool ReadOnly, [In] XboxCreateDisposition CreateDisposition, [In] XboxShareMode ShareMode);

		
		[DispId(101)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SaveDatabase([MarshalAs(UnmanagedType.BStr)] [In] string DatabaseFile, [In] bool Remember);

		
		[DispId(102)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CloseDatabase();

		
		[DispId(103)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ResetDatabase();

		
		[DispId(120)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddExecutable([MarshalAs(UnmanagedType.BStr)] [In] string XboxExecutablePath, [MarshalAs(UnmanagedType.BStr)] [In] string PortableExecutablePath, [MarshalAs(UnmanagedType.BStr)] [In] string SymbolPath, [MarshalAs(UnmanagedType.BStr)] [In] string PublicSymbolPath, [In] bool ExplictFilesOnly, [In] bool StoreRelativePath);

		
		[DispId(121)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveExecutable([MarshalAs(UnmanagedType.BStr)] [In] string Guid);

		
		[DispId(122)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool FindExecutableByGuid([MarshalAs(UnmanagedType.BStr)] [In] string Guid, [MarshalAs(UnmanagedType.Interface)] out IXboxExecutableInfo Info);

		
		[DispId(123)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool FindExecutableForSymServ([MarshalAs(UnmanagedType.BStr)] [In] string ModuleName, [In] uint TimeDateStamp, [In] uint SizeOfImage, [MarshalAs(UnmanagedType.Interface)] out IXboxExecutableInfo Info);
	}
}
