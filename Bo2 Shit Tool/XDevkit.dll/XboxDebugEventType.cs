using System;

namespace XDevkit
{
	
	public enum XboxDebugEventType
	{
		
		NoEvent,
		
		ExecutionBreak,
		
		DebugString,
		
		ExecStateChange,
		
		SingleStep,
		
		ModuleLoad,
		
		ModuleUnload,
		
		ThreadCreate,
		
		ThreadDestroy,
		
		Exception,
		
		AssertionFailed,
		
		AssertionFailedEx,
		
		DataBreak,
		
		RIP,
		
		SectionLoad,
		
		SectionUnload,
		
		StackTrace,
		
		FiberCreate,
		
		FiberDestroy,
		
		BugCheck,
		
		PgoModuleStartup
	}
}
