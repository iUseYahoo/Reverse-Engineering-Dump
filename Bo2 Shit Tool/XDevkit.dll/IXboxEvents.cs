using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("E3C9D73F-9DF0-4B57-8CEE-05F9CA6823BE")]
	[InterfaceType(1)]
	[TypeLibType(256)]
	[ComImport]
	public interface IXboxEvents
	{
		
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnStdNotify([In] XboxDebugEventType EventCode, [MarshalAs(UnmanagedType.Interface)] [In] IXboxEventInfo EventInfo);

		
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnTextNotify([MarshalAs(UnmanagedType.BStr)] [In] string Source, [MarshalAs(UnmanagedType.BStr)] [In] string Notification);
	}
}
