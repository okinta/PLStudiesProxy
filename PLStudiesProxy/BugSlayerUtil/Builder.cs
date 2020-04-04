using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BugSlayerUtil
{
	[StructLayout(LayoutKind.Sequential, Size = 40)]
	[DebugInfoInPDB]
	[NativeCppClass]
	[MiscellaneousBits(64)]
	internal struct Builder
	{
		private long _003Calignment_0020member_003E;
	}
}
