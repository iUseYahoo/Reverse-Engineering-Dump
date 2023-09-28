using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("420208DF-C38C-4EFB-9FC3-ACD50350941E")]
	[InterfaceType(2)]
	[TypeLibType(4096)]
	[ComImport]
	public interface XboxEvents
	{
		
		[DispId(1)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnStdNotify([In] XboxDebugEventType EventCode, [MarshalAs(UnmanagedType.Interface)] [In] IXboxEventInfo EventInfo);

		
		[DispId(2)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnTextNotify([MarshalAs(UnmanagedType.BStr)] [In] string Source, [MarshalAs(UnmanagedType.BStr)] [In] string Notification);
	}
}
