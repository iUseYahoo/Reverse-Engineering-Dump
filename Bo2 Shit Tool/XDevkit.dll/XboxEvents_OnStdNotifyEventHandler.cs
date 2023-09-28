using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	
	[TypeLibType(16)]
	[ComVisible(false)]
	public delegate void XboxEvents_OnStdNotifyEventHandler([In] XboxDebugEventType EventCode, [MarshalAs(UnmanagedType.Interface)] [In] IXboxEventInfo EventInfo);
}
