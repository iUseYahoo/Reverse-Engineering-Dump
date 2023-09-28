using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(16)]
	[ComVisible(false)]
	[ComEventInterface(typeof(XboxEvents\u0000), typeof(XboxEvents_EventProvider\u0000))]
	public interface XboxEvents_Event
	{
		
		
		
		event XboxEvents_OnStdNotifyEventHandler OnStdNotify;

		
		
		
		event XboxEvents_OnTextNotifyEventHandler OnTextNotify;
	}
}
