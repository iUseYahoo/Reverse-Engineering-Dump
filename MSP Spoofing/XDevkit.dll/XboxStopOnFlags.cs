using System;

namespace XDevkit
{
	
	public enum XboxStopOnFlags
	{
		
		OnThreadCreate = 1,
		
		OnFirstChanceException,
		
		OnDebugString = 4,
		
		OnStackTrace = 8,
		
		OnModuleLoad = 16,
		
		OnTitleLaunch = 32,
		
		OnPgoModuleStartup = 64
	}
}
