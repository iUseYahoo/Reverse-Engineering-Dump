using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	internal sealed class XboxEvents_EventProvider : XboxEvents_Event, IDisposable
	{
		
		private void Init()
		{
			UCOMIConnectionPoint ucomiconnectionPoint = null;
			Guid guid = new Guid(new byte[]
			{
				223,
				8,
				2,
				66,
				140,
				195,
				251,
				78,
				159,
				195,
				172,
				213,
				3,
				80,
				148,
				30
			});
			this.m_ConnectionPointContainer.FindConnectionPoint(ref guid, out ucomiconnectionPoint);
			this.m_ConnectionPoint = (UCOMIConnectionPoint)ucomiconnectionPoint;
			this.m_aEventSinkHelpers = new ArrayList();
		}

		
		public void add_OnTextNotify(XboxEvents_OnTextNotifyEventHandler A_1)
		{
			lock (this)
			{
				if (this.m_ConnectionPoint == null)
				{
					this.Init();
				}
				XboxEvents_SinkHelper xboxEvents_SinkHelper = new XboxEvents_SinkHelper();
				int dwCookie = 0;
				this.m_ConnectionPoint.Advise((object)xboxEvents_SinkHelper, out dwCookie);
				xboxEvents_SinkHelper.m_dwCookie = dwCookie;
				xboxEvents_SinkHelper.m_OnTextNotifyDelegate = A_1;
				this.m_aEventSinkHelpers.Add((object)xboxEvents_SinkHelper);
			}
		}

		
		public void remove_OnTextNotify(XboxEvents_OnTextNotifyEventHandler A_1)
		{
			lock (this)
			{
				int count = this.m_aEventSinkHelpers.Count;
				int num = 0;
				if (0 < count)
				{
					XboxEvents_SinkHelper xboxEvents_SinkHelper;
					for (;;)
					{
						xboxEvents_SinkHelper = (XboxEvents_SinkHelper)this.m_aEventSinkHelpers[num];
						if (xboxEvents_SinkHelper.m_OnTextNotifyDelegate != null && ((xboxEvents_SinkHelper.m_OnTextNotifyDelegate.Equals((object)A_1) ? 1 : 0) & 255) != 0)
						{
							break;
						}
						num++;
						if (num >= count)
						{
							goto IL_D3;
						}
					}
					this.m_aEventSinkHelpers.RemoveAt(num);
					this.m_ConnectionPoint.Unadvise(xboxEvents_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(this.m_ConnectionPoint);
						this.m_ConnectionPoint = null;
						this.m_aEventSinkHelpers = null;
					}
				}
				IL_D3:;
			}
		}

		
		public void add_OnStdNotify(XboxEvents_OnStdNotifyEventHandler A_1)
		{
			lock (this)
			{
				if (this.m_ConnectionPoint == null)
				{
					this.Init();
				}
				XboxEvents_SinkHelper xboxEvents_SinkHelper = new XboxEvents_SinkHelper();
				int dwCookie = 0;
				this.m_ConnectionPoint.Advise((object)xboxEvents_SinkHelper, out dwCookie);
				xboxEvents_SinkHelper.m_dwCookie = dwCookie;
				xboxEvents_SinkHelper.m_OnStdNotifyDelegate = A_1;
				this.m_aEventSinkHelpers.Add((object)xboxEvents_SinkHelper);
			}
		}

		
		public void remove_OnStdNotify(XboxEvents_OnStdNotifyEventHandler A_1)
		{
			lock (this)
			{
				int count = this.m_aEventSinkHelpers.Count;
				int num = 0;
				if (0 < count)
				{
					XboxEvents_SinkHelper xboxEvents_SinkHelper;
					for (;;)
					{
						xboxEvents_SinkHelper = (XboxEvents_SinkHelper)this.m_aEventSinkHelpers[num];
						if (xboxEvents_SinkHelper.m_OnStdNotifyDelegate != null && ((xboxEvents_SinkHelper.m_OnStdNotifyDelegate.Equals((object)A_1) ? 1 : 0) & 255) != 0)
						{
							break;
						}
						num++;
						if (num >= count)
						{
							goto IL_D3;
						}
					}
					this.m_aEventSinkHelpers.RemoveAt(num);
					this.m_ConnectionPoint.Unadvise(xboxEvents_SinkHelper.m_dwCookie);
					if (count <= 1)
					{
						Marshal.ReleaseComObject(this.m_ConnectionPoint);
						this.m_ConnectionPoint = null;
						this.m_aEventSinkHelpers = null;
					}
				}
				IL_D3:;
			}
		}

		
		public XboxEvents_EventProvider(object A_1)
		{
			this.m_ConnectionPointContainer = (UCOMIConnectionPointContainer)A_1;
		}

		
		public override void Finalize()
		{
			lock (this)
			{
				try
				{
					if (this.m_ConnectionPoint != null)
					{
						int count = this.m_aEventSinkHelpers.Count;
						int num = 0;
						if (0 < count)
						{
							do
							{
								XboxEvents_SinkHelper xboxEvents_SinkHelper = (XboxEvents_SinkHelper)this.m_aEventSinkHelpers[num];
								this.m_ConnectionPoint.Unadvise(xboxEvents_SinkHelper.m_dwCookie);
								num++;
							}
							while (num < count);
						}
						Marshal.ReleaseComObject(this.m_ConnectionPoint);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		
		public void Dispose()
		{
			this.Finalize();
			GC.SuppressFinalize(this);
		}

		
		private UCOMIConnectionPointContainer m_ConnectionPointContainer;

		
		private ArrayList m_aEventSinkHelpers;

		
		private UCOMIConnectionPoint m_ConnectionPoint;
	}
}
