using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("0EEE2AA0-60F0-4C18-B4ED-E3933E659847")]
	[DefaultMember("ModuleInfo")]
	[TypeLibType(4288)]
	[ComImport]
	public interface IXboxModule
	{
		
		
		[DispId(0)]
		[IndexerName("ModuleInfo")]
		XBOX_MODULE_INFO ModuleInfo { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(1)]
		IXboxSections Sections { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetFunctionInfo([In] uint Address, out XBOX_FUNCTION_INFO FunctionInfo);

		
		
		[DispId(3)]
		uint OriginalSize { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(4)]
		IXboxExecutable Executable { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint GetEntryPointAddress();
	}
}
