using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[CoClass(typeof(XboxConsoleClass))]
	[Guid("75DD80A9-5A33-42D4-8A39-AB07C9B17CC3")]
	[ComImport]
	public interface XboxConsole : IXboxConsole, XboxEvents_Event
	{
	}
}
