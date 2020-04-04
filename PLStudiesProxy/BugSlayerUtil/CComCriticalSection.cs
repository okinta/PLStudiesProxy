using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BugSlayerUtil
{
	[StructLayout(LayoutKind.Sequential, Size = 40)]
	[NativeCppClass]
	[DebugInfoInPDB]
	[MiscellaneousBits(64)]
	internal struct CComCriticalSection
	{
		private long _003Calignment_0020member_003E;
	}
}
