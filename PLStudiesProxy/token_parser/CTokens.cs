using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace token_parser
{
	[StructLayout(LayoutKind.Sequential, Size = 72)]
	[UnsafeValueType]
	[NativeCppClass]
	[MiscellaneousBits(64)]
	[DebugInfoInPDB]
	internal struct CTokens
	{
		private long _003Calignment_0020member_003E;
	}
}
