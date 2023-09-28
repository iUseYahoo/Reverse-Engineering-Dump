using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("85C9127A-11ED-47F2-9E87-A83058FC264A")]
	[TypeLibType(4160)]
	[DefaultMember("Info")]
	[ComImport]
	public interface IXboxEventInfo
	{
		
		
		[DispId(0)]
		[IndexerName("Info")]
		XBOX_EVENT_INFO Info { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
