using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[Guid("EABF8976-1A2F-4AAA-BBBB-3ECAB03B2EE9")]
	[TypeLibType(4160)]
	[ComImport]
	public interface IXboxStackFrame
	{
		
		
		[DispId(1)]
		bool TopOfStack { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(2)]
		bool Dirty { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(3)]
		IXboxStackFrame NextStackFrame { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		
		[DispId(100)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GetRegister32([In] XboxRegisters32 Register, out int Value);

		
		[DispId(101)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRegister32([In] XboxRegisters32 Register, [In] int Value);

		
		[DispId(102)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GetRegister64([In] XboxRegisters64 Register, out long Value);

		
		[DispId(103)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRegister64([In] XboxRegisters64 Register, [In] long Value);

		
		[DispId(104)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GetRegisterDouble([In] XboxRegistersDouble Register, out double Value);

		
		[DispId(105)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRegisterDouble([In] XboxRegistersDouble Register, [In] double Value);

		
		[TypeLibFunc(64)]
		[DispId(106)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GetRegisterVector_cpp([In] XboxRegistersVector Register, out float Value);

		
		[DispId(107)]
		[TypeLibFunc(64)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRegisterVector_cpp([In] XboxRegistersVector Register, [In] ref float Value);

		
		[DispId(108)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool GetRegisterVector([In] XboxRegistersVector Register, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R4)] float[] Value);

		
		[DispId(109)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetRegisterVector([In] XboxRegistersVector Register, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R4)] float[] Value);

		
		[DispId(110)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void FlushRegisterChanges();

		
		
		[DispId(111)]
		XBOX_FUNCTION_INFO FunctionInfo { [DispId(111)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(112)]
		uint StackPointer { [DispId(112)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		
		
		[DispId(113)]
		uint ReturnAddress { [DispId(113)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
