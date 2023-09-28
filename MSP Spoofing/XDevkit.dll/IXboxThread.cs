using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("8F1E63F5-85BA-4B2D-AD9C-1FA6B750D57F")]
	[DefaultMember("ThreadId")]
	[TypeLibType(4160)]
	[ComImport]
	public interface IXboxThread
	{
		
		
		[DispId(0)]
		[IndexerName("ThreadId")]
		uint ThreadId { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(100)]
		XBOX_THREAD_INFO ThreadInfo { [DispId(100)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(101)]
		XBOX_EVENT_INFO StopEventInfo { [DispId(101)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(102)]
		IXboxStackFrame TopOfStack { [DispId(102)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(103)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Halt();

		
		[DispId(104)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Continue([In] bool Exception);

		
		[DispId(105)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Suspend();

		
		[DispId(106)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Resume();

		
		
		[DispId(107)]
		uint CurrentProcessor { [DispId(107)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(108)]
		uint LastError { [DispId(108)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
