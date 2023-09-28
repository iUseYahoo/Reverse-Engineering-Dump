using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class XboxEvents_SinkHelper : XboxEvents
	{
		
		public void OnTextNotify(string A_1, string A_2)
		{
			if (this.m_OnTextNotifyDelegate != null)
			{
				this.m_OnTextNotifyDelegate(A_1, A_2);
				return;
			}
		}

		
		public void OnStdNotify(XboxDebugEventType A_1, IXboxEventInfo A_2)
		{
			if (this.m_OnStdNotifyDelegate != null)
			{
				this.m_OnStdNotifyDelegate(A_1, A_2);
				return;
			}
		}

		
		internal XboxEvents_SinkHelper()
		{
			this.m_dwCookie = 0;
			this.m_OnTextNotifyDelegate = null;
			this.m_OnStdNotifyDelegate = null;
		}

		
		public XboxEvents_OnTextNotifyEventHandler m_OnTextNotifyDelegate;

		
		public XboxEvents_OnStdNotifyEventHandler m_OnStdNotifyDelegate;

		
		public int m_dwCookie;
	}
}
