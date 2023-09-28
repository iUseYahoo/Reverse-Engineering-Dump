using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[TypeLibType(4288)]
	[Guid("D81F3E2E-8304-4024-8997-BB1C893516B0")]
	[ComImport]
	public interface IXboxAutomation
	{
		
		[DispId(100)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetInputProcess([In] uint UserIndex, out bool SystemProcess);

		
		[DispId(101)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void BindController([In] uint UserIndex, [In] uint QueueLength);

		
		[DispId(102)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void UnbindController([In] uint UserIndex);

		
		[DispId(103)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ConnectController([In] uint UserIndex);

		
		[DispId(104)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void DisconnectController([In] uint UserIndex);

		
		[DispId(105)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetGamepadState([In] uint UserIndex, [In] ref XBOX_AUTOMATION_GAMEPAD Gamepad);

		
		[DispId(106)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void QueueGamepadState_cpp([In] uint UserIndex, [In] ref XBOX_AUTOMATION_GAMEPAD GamepadArray, [In] ref uint TimedDurationArray, [In] ref uint CountDurationArray, [In] uint ItemCount, out uint ItemsAddedToQueue);

		
		[DispId(107)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool QueueGamepadState([In] uint UserIndex, [In] ref XBOX_AUTOMATION_GAMEPAD Gamepad, [In] uint TimedDuration, [In] uint CountDuration);

		
		[DispId(108)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void ClearGamepadQueue([In] uint UserIndex);

		
		[DispId(109)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void QueryGamepadQueue([In] uint UserIndex, out uint QueueLength, out uint ItemsInQueue, out uint TimedDurationRemaining, out uint CountDurationRemaining);

		
		[DispId(110)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetUserDefaultProfile(out long Xuid);

		
		[DispId(111)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetUserDefaultProfile([In] long Xuid);
	}
}
