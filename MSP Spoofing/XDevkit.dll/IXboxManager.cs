using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("C4C077E9-BF83-4657-AD8B-1E5ABB9BB9A8")]
	[TypeLibType(4288)]
	[ComImport]
	public interface IXboxManager
	{
		
		
		
		[DispId(1)]
		string DefaultConsole { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		
		
		[DispId(2)]
		IXboxConsoles Consoles { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddConsole([MarshalAs(UnmanagedType.BStr)] [In] string Xbox);

		
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveConsole([MarshalAs(UnmanagedType.BStr)] [In] string Xbox);

		
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		XboxConsole OpenConsole([MarshalAs(UnmanagedType.BStr)] [In] string XboxName);

		
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IXboxDebugTarget OpenDumpFile([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [MarshalAs(UnmanagedType.BStr)] [In] string ImageSearchPath);

		
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SelectConsole([In] int ParentWindow, [MarshalAs(UnmanagedType.BStr)] out string SelectedXbox, [In] XboxAccessFlags DesiredAccess, [In] XboxSelectConsoleFlags Flags);

		
		[DispId(9)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RunAddConsoleWizard([In] int ParentWindow, [In] bool Modal);

		
		[DispId(10)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OpenWindowsExplorer([MarshalAs(UnmanagedType.BStr)] [In] string XboxName, [MarshalAs(UnmanagedType.BStr)] [In] string Path);

		
		[DispId(20)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string TranslateError([MarshalAs(UnmanagedType.Error)] [In] int hr);

		
		
		[DispId(21)]
		string SystemSymbolServerPath { [DispId(21)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
