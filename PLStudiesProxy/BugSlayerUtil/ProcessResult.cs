using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BugSlayerUtil
{
	[StructLayout(LayoutKind.Sequential, Size = 8)]
	[MiscellaneousBits(64)]
	[NativeCppClass]
	[DebugInfoInPDB]
	internal struct ProcessResult
	{
		private long _003Calignment_0020member_003E;
	}
}
