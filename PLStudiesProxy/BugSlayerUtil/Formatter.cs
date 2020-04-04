using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BugSlayerUtil
{
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	[MiscellaneousBits(64)]
	[NativeCppClass]
	[DebugInfoInPDB]
	internal struct Formatter
	{
		private long _003Calignment_0020member_003E;
	}
}
