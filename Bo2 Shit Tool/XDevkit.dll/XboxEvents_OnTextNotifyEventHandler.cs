using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	
	[TypeLibType(16)]
	[ComVisible(false)]
	public delegate void XboxEvents_OnTextNotifyEventHandler([MarshalAs(UnmanagedType.BStr)] [In] string Source, [MarshalAs(UnmanagedType.BStr)] [In] string Notification);
}
