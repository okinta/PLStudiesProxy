using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace node_attributes
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[MiscellaneousBits(64)]
	[NativeCppClass]
	[DebugInfoInPDB]
	internal struct CNodeAttributes
	{
		private int _003Calignment_0020member_003E;
	}
}
