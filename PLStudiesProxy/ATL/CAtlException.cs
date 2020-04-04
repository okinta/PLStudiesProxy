using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ATL
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[NativeCppClass]
	[DebugInfoInPDB]
	[MiscellaneousBits(64)]
	internal struct CAtlException
	{
		private int _003Calignment_0020member_003E;
	}
}
