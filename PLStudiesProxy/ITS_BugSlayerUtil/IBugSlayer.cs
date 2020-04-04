using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ITS_BugSlayerUtil
{
	[StructLayout(LayoutKind.Sequential, Size = 8)]
	[NativeCppClass]
	[DebugInfoInPDB]
	[MiscellaneousBits(65)]
	internal struct IBugSlayer
	{
		private long _003Calignment_0020member_003E;
	}
}
