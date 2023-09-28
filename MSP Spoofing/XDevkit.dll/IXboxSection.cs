using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4160)]
	[Guid("D6DF8112-0326-4D29-A6B8-CFB0D89C358A")]
	[ComImport]
	public interface IXboxSection
	{
		
		
		[DispId(100)]
		XBOX_SECTION_INFO SectionInfo { [DispId(100)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
