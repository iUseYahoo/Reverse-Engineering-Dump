using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct XBOX_AUTOMATION_GAMEPAD
	{
		
		public XboxAutomationButtonFlags Buttons;

		
		public uint LeftTrigger;

		
		public uint RightTrigger;

		
		public int LeftThumbX;

		
		public int LeftThumbY;

		
		public int RightThumbX;

		
		public int RightThumbY;
	}
}
