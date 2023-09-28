using System;

namespace XDevkit
{
	
	public enum XboxDumpFlags
	{
		
		Normal,
		
		WithDataSegs,
		
		WithFullMemory,
		
		WithHandleData = 4,
		
		FilterMemory = 8,
		
		ScanMemory = 16,
		
		WithUnloadedModules = 32,
		
		WithIndirectlyReferencedMemory = 64,
		
		FilterModulePaths = 128,
		
		WithProcessThreadData = 256,
		
		WithPrivateReadWriteMemory = 512
	}
}
