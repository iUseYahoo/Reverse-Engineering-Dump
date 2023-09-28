using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("75DD80A9-5A33-42D4-8A39-AB07C9B17CC3")]
	[TypeLibType(4288)]
	[DefaultMember("Name")]
	[ComImport]
	public interface IXboxConsole
	{
		
		
		
		[DispId(0)]
		[IndexerName("Name")]
		string Name { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		
		
		[DispId(1)]
		uint IPAddress { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(2)]
		uint IPAddressTitle { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		
		[DispId(3)]
		object SystemTime { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		
		
		
		[DispId(20)]
		bool Shared { [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(21)]
		uint ConnectTimeout { [DispId(21)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(21)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(22)]
		uint ConversationTimeout { [DispId(22)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(22)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		[DispId(30)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FindConsole([In] uint Retries, [In] uint RetryDelay);

		
		
		[DispId(50)]
		XboxManager XboxManager { [DispId(50)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		
		[DispId(51)]
		IXboxDebugTarget DebugTarget { [DispId(51)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(100)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Reboot([MarshalAs(UnmanagedType.BStr)] [In] string Name, [MarshalAs(UnmanagedType.BStr)] [In] string MediaDirectory, [MarshalAs(UnmanagedType.BStr)] [In] string CmdLine, [In] XboxRebootFlags Flags);

		
		[DispId(101)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDefaultTitle([MarshalAs(UnmanagedType.BStr)] [In] string TitleName, [MarshalAs(UnmanagedType.BStr)] [In] string MediaDirectory, [In] uint Flags);

		
		
		[DispId(102)]
		XBOX_PROCESS_INFO RunningProcessInfo { [DispId(102)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		[DispId(110)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint OpenConnection([MarshalAs(UnmanagedType.BStr)] [In] string Handler);

		
		[DispId(111)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CloseConnection([In] uint Connection);

		
		[DispId(112)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SendTextCommand([In] uint Connection, [MarshalAs(UnmanagedType.BStr)] [In] string Command, [MarshalAs(UnmanagedType.BStr)] out string Response);

		
		[DispId(113)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ReceiveSocketLine([In] uint Connection, [MarshalAs(UnmanagedType.BStr)] out string Line);

		
		[DispId(114)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int ReceiveStatusResponse([In] uint Connection, [MarshalAs(UnmanagedType.BStr)] out string Line);

		
		[DispId(115)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SendBinary([In] uint Connection, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] byte[] Data, [In] uint Count);

		
		[DispId(116)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ReceiveBinary([In] uint Connection, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] [Out] byte[] Data, [In] uint Count, out uint BytesReceived);

		
		[TypeLibFunc(64)]
		[DispId(117)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SendBinary_cpp([In] uint Connection, [In] ref byte Data, [In] uint Count);

		
		[DispId(118)]
		[TypeLibFunc(64)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ReceiveBinary_cpp([In] uint Connection, [In] ref byte Data, [In] uint Count, out uint BytesReceived);

		
		
		[DispId(120)]
		string Drives { [DispId(120)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		[DispId(121)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDiskFreeSpace([In] ushort Drive, out ulong FreeBytesAvailableToCaller, out ulong TotalNumberOfBytes, out ulong TotalNumberOfFreeBytes);

		
		[DispId(125)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void MakeDirectory([MarshalAs(UnmanagedType.BStr)] [In] string Directory);

		
		[DispId(126)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveDirectory([MarshalAs(UnmanagedType.BStr)] [In] string Directory);

		
		[DispId(127)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IXboxFiles DirectoryFiles([MarshalAs(UnmanagedType.BStr)] [In] string Directory);

		
		[DispId(130)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SendFile([MarshalAs(UnmanagedType.BStr)] [In] string LocalName, [MarshalAs(UnmanagedType.BStr)] [In] string RemoteName);

		
		[DispId(131)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ReceiveFile([MarshalAs(UnmanagedType.BStr)] [In] string LocalName, [MarshalAs(UnmanagedType.BStr)] [In] string RemoteName);

		
		[DispId(132)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ReadFileBytes([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] [Out] byte[] Data, out uint BytesRead);

		
		[DispId(133)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void WriteFileBytes([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] byte[] Data, out uint BytesWritten);

		
		[TypeLibFunc(64)]
		[DispId(134)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ReadFileBytes_cpp([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, out byte Data, out uint BytesRead);

		
		[TypeLibFunc(64)]
		[DispId(135)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void WriteFileBytes_cpp([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, [In] ref byte Data, out uint BytesWritten);

		
		[DispId(136)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetFileSize([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] XboxCreateDisposition CreateDisposition);

		
		[DispId(140)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IXboxFile GetFileObject([MarshalAs(UnmanagedType.BStr)] [In] string Filename);

		
		[DispId(141)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RenameFile([MarshalAs(UnmanagedType.BStr)] [In] string OldName, [MarshalAs(UnmanagedType.BStr)] [In] string NewName);

		
		[DispId(142)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void DeleteFile([MarshalAs(UnmanagedType.BStr)] [In] string Filename);

		
		[DispId(150)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ScreenShot([MarshalAs(UnmanagedType.BStr)] string Filename);

		
		
		
		[DispId(160)]
		XboxDumpMode DumpMode { [DispId(160)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(160)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		[DispId(161)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetDumpSettings(out XBOX_DUMP_SETTINGS DumpMode);

		
		[DispId(162)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDumpSettings([In] ref XBOX_DUMP_SETTINGS DumpMode);

		
		
		
		[DispId(163)]
		XboxEventDeferFlags EventDeferFlags { [DispId(163)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(163)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		[DispId(170)]
		XboxConsoleType ConsoleType { [DispId(170)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		[DispId(182)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void StartFileEventCapture();

		
		[DispId(183)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void StopFileEventCapture();

		
		
		[DispId(184)]
		IXboxAutomation XboxAutomation { [DispId(184)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(185)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint LoadDebuggerExtension([MarshalAs(UnmanagedType.BStr)] [In] string ExtensionName);

		
		[DispId(186)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void UnloadDebuggerExtension([In] uint ModuleHandle);
	}
}
