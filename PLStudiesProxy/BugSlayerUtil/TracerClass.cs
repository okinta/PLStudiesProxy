using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BugSlayerUtil
{
	[StructLayout(LayoutKind.Sequential, Size = 96)]
	[MiscellaneousBits(64)]
	[DebugInfoInPDB]
	[NativeCppClass]
	internal struct TracerClass
	{
		private long _003Calignment_0020member_003E;
	}
}
