using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace custom_params
{
	[StructLayout(LayoutKind.Sequential, Size = 32)]
	[MiscellaneousBits(64)]
	[DebugInfoInPDB]
	[NativeCppClass]
	internal struct CCustomParams
	{
		private long _003Calignment_0020member_003E;
	}
}
