using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("4F882A21-7F2A-4BEA-A0A3-A3710A93DEEA")]
	[TypeLibType(4288)]
	[ComImport]
	public interface IXboxMemoryRegion
	{
		
		
		[DispId(1)]
		int BaseAddress { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(2)]
		int RegionSize { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(3)]
		XboxMemoryRegionFlags Flags { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
