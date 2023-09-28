using System;

namespace XDevkit
{
	
	public enum XboxSectionInfoFlags
	{
		
		Loaded = 1,
		
		Readable,
		
		Writeable = 4,
		
		Executable = 8,
		
		Uninitialized = 16
	}
}
