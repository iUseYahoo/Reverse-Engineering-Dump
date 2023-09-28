using System;

namespace XDevkit
{
	
	public enum XboxDumpReportFlags
	{
		
		PromptToReport,
		
		AlwaysReport,
		
		NeverReport,
		
		ReportGroup = 15,
		
		LocalDestination = 0,
		
		RemoteDestination = 16,
		
		DestinationGroup = 15,
		
		FormatFullHeap = 0,
		
		FormatPartialHeap = 256,
		
		FormatNoHeap = 512,
		
		FormatRetail = 1024,
		
		FormatGroup = 3840
	}
}
