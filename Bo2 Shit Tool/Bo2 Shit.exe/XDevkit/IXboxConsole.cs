using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[CompilerGenerated]
	[Guid("75DD80A9-5A33-42D4-8A39-AB07C9B17CC3")]
	[DefaultMember("Name")]
	[TypeIdentifier]
	[ComImport]
	public interface IXboxConsole
	{
		
		
		
		[DispId(0)]
		[IndexerName("Name")]
		string Name { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }
	}
}
