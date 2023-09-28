using System;

namespace XDevkit
{
	
	public enum XboxMemoryRegionFlags
	{
		
		NoAccess = 1,
		
		ReadOnly,
		
		ReadWrite = 4,
		
		WriteCopy = 8,
		
		Execute = 16,
		
		ExecuteRead = 32,
		
		ExecuteReadWrite = 64,
		
		ExecuteWriteCopy = 128,
		
		Guard = 256,
		
		NoCache = 512,
		
		WriteCombine = 1024,
		
		UserReadOnly = 4096,
		
		UserReadWrite = 8192
	}
}
