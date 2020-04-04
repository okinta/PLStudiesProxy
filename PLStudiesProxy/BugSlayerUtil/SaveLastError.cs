using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BugSlayerUtil
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[NativeCppClass]
	[MiscellaneousBits(64)]
	[DebugInfoInPDB]
	internal struct SaveLastError
	{
		private int _003Calignment_0020member_003E;
	}
}
