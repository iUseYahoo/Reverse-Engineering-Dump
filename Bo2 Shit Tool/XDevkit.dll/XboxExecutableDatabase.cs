using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[CoClass(typeof(XboxExecutableDatabaseClass))]
	[Guid("CB8E47BA-2673-48AF-B0C5-FD5738FFCC6B")]
	[ComImport]
	public interface XboxExecutableDatabase : IXboxExecutableDatabase
	{
	}
}
