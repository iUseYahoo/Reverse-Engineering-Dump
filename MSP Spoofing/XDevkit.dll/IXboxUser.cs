using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4288)]
	[Guid("6BB90673-5C3C-4B63-8D3C-479A5EDE82C3")]
	[DefaultMember("Name")]
	[ComImport]
	public interface IXboxUser
	{
		
		
		
		[DispId(0)]
		[IndexerName("Name")]
		string Name { [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(0)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		
		
		
		[DispId(1)]
		bool HasReadAccess { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(2)]
		bool HasWriteAccess { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(3)]
		bool HasControlAccess { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(4)]
		bool HasConfigureAccess { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		
		
		
		[DispId(5)]
		bool HasManageAccess { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
