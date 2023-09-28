using System;

namespace XDevkit
{
	
	public enum XboxEventDeferFlags
	{
		
		CanDeferExecutionBreak = 1,
		
		CanDeferDebugString,
		
		CanDeferSingleStep = 4,
		
		CanDeferAssertionFailed = 8,
		
		CanDeferAssertionFailedEx = 16,
		
		CanDeferDataBreak = 32,
		
		CanDeferRIP = 64
	}
}
