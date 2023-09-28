using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[ComSourceInterfaces("XDevkit.XboxEvents\0\0")]
	[TypeLibType(2)]
	[ClassInterface(0)]
	[DefaultMember("Name")]
	[Guid("3ED2B073-99A1-42DB-80CC-295E9FFBA18F")]
	[ComImport]
	public class XboxConsoleClass : IXboxConsole, XboxConsole, XboxEvents_Event
	{
		
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern XboxConsoleClass();

		
		
		
		[DispId(0)]
		[IndexerName("Name")]
		public virtual extern string Name { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		
		
		[DispId(1)]
		public virtual extern uint IPAddress { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(2)]
		public virtual extern uint IPAddressTitle { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		
		[DispId(3)]
		public virtual extern object SystemTime { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Struct)] get; [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.Struct)] [param: In] set; }

		
		
		
		[DispId(20)]
		public virtual extern bool Shared { [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(21)]
		public virtual extern uint ConnectTimeout { [DispId(21)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(21)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(22)]
		public virtual extern uint ConversationTimeout { [DispId(22)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(22)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		[DispId(30)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void FindConsole([In] uint Retries, [In] uint RetryDelay);

		
		
		[DispId(50)]
		public virtual extern XboxManager XboxManager { [DispId(50)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		
		[DispId(51)]
		public virtual extern IXboxDebugTarget DebugTarget { [DispId(51)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(100)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void Reboot([MarshalAs(UnmanagedType.BStr)] [In] string Name, [MarshalAs(UnmanagedType.BStr)] [In] string MediaDirectory, [MarshalAs(UnmanagedType.BStr)] [In] string CmdLine, [In] XboxRebootFlags Flags);

		
		[DispId(101)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SetDefaultTitle([MarshalAs(UnmanagedType.BStr)] [In] string TitleName, [MarshalAs(UnmanagedType.BStr)] [In] string MediaDirectory, [In] uint Flags);

		
		
		[DispId(102)]
		public virtual extern XBOX_PROCESS_INFO RunningProcessInfo { [DispId(102)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		[DispId(110)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern uint OpenConnection([MarshalAs(UnmanagedType.BStr)] [In] string Handler);

		
		[DispId(111)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void CloseConnection([In] uint Connection);

		
		[DispId(112)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SendTextCommand([In] uint Connection, [MarshalAs(UnmanagedType.BStr)] [In] string Command, [MarshalAs(UnmanagedType.BStr)] out string Response);

		
		[DispId(113)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void ReceiveSocketLine([In] uint Connection, [MarshalAs(UnmanagedType.BStr)] out string Line);

		
		[DispId(114)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int ReceiveStatusResponse([In] uint Connection, [MarshalAs(UnmanagedType.BStr)] out string Line);

		
		[DispId(115)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SendBinary([In] uint Connection, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] byte[] Data, [In] uint Count);

		
		[DispId(116)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void ReceiveBinary([In] uint Connection, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] [Out] byte[] Data, [In] uint Count, out uint BytesReceived);

		
		[DispId(117)]
		[TypeLibFunc(64)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SendBinary_cpp([In] uint Connection, [In] ref byte Data, [In] uint Count);

		
		[DispId(118)]
		[TypeLibFunc(64)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void ReceiveBinary_cpp([In] uint Connection, [In] ref byte Data, [In] uint Count, out uint BytesReceived);

		
		
		[DispId(120)]
		public virtual extern string Drives { [DispId(120)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		
		[DispId(121)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void GetDiskFreeSpace([In] ushort Drive, out ulong FreeBytesAvailableToCaller, out ulong TotalNumberOfBytes, out ulong TotalNumberOfFreeBytes);

		
		[DispId(125)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void MakeDirectory([MarshalAs(UnmanagedType.BStr)] [In] string Directory);

		
		[DispId(126)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void RemoveDirectory([MarshalAs(UnmanagedType.BStr)] [In] string Directory);

		
		[DispId(127)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		public virtual extern IXboxFiles DirectoryFiles([MarshalAs(UnmanagedType.BStr)] [In] string Directory);

		
		[DispId(130)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SendFile([MarshalAs(UnmanagedType.BStr)] [In] string LocalName, [MarshalAs(UnmanagedType.BStr)] [In] string RemoteName);

		
		[DispId(131)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void ReceiveFile([MarshalAs(UnmanagedType.BStr)] [In] string LocalName, [MarshalAs(UnmanagedType.BStr)] [In] string RemoteName);

		
		[DispId(132)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void ReadFileBytes([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] [Out] byte[] Data, out uint BytesRead);

		
		[DispId(133)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void WriteFileBytes([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)] [In] byte[] Data, out uint BytesWritten);

		
		[DispId(134)]
		[TypeLibFunc(64)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void ReadFileBytes_cpp([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, out byte Data, out uint BytesRead);

		
		[DispId(135)]
		[TypeLibFunc(64)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void WriteFileBytes_cpp([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] uint Count, [In] ref byte Data, out uint BytesWritten);

		
		[DispId(136)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SetFileSize([MarshalAs(UnmanagedType.BStr)] [In] string Filename, [In] uint FileOffset, [In] XboxCreateDisposition CreateDisposition);

		
		[DispId(140)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		public virtual extern IXboxFile GetFileObject([MarshalAs(UnmanagedType.BStr)] [In] string Filename);

		
		[DispId(141)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void RenameFile([MarshalAs(UnmanagedType.BStr)] [In] string OldName, [MarshalAs(UnmanagedType.BStr)] [In] string NewName);

		
		[DispId(142)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void DeleteFile([MarshalAs(UnmanagedType.BStr)] [In] string Filename);

		
		[DispId(150)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void ScreenShot([MarshalAs(UnmanagedType.BStr)] string Filename);

		
		
		
		[DispId(160)]
		public virtual extern XboxDumpMode DumpMode { [DispId(160)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(160)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		[DispId(161)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void GetDumpSettings(out XBOX_DUMP_SETTINGS DumpMode);

		
		[DispId(162)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void SetDumpSettings([In] ref XBOX_DUMP_SETTINGS DumpMode);

		
		
		
		[DispId(163)]
		public virtual extern XboxEventDeferFlags EventDeferFlags { [DispId(163)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(163)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		[DispId(170)]
		public virtual extern XboxConsoleType ConsoleType { [DispId(170)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		[DispId(182)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void StartFileEventCapture();

		
		[DispId(183)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void StopFileEventCapture();

		
		
		[DispId(184)]
		public virtual extern IXboxAutomation XboxAutomation { [DispId(184)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(185)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern uint LoadDebuggerExtension([MarshalAs(UnmanagedType.BStr)] [In] string ExtensionName);

		
		[DispId(186)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public virtual extern void UnloadDebuggerExtension([In] uint ModuleHandle);

		
		
		
		public virtual extern event XboxEvents_OnStdNotifyEventHandler OnStdNotify;

		
		
		
		public virtual extern event XboxEvents_OnTextNotifyEventHandler OnTextNotify;
	}
}
