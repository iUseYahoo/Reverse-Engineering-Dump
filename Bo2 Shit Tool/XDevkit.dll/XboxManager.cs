using System;
using System.Runtime.InteropServices;

namespace XDevkit
{
	
	[CoClass(typeof(XboxManagerClass))]
	[Guid("C4C077E9-BF83-4657-AD8B-1E5ABB9BB9A8")]
	[ComImport]
	public interface XboxManager : IXboxManager
	{
	}
}
