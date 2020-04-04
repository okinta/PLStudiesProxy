using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ATL
{
	[StructLayout(LayoutKind.Sequential, Size = 40)]
	[NativeCppClass]
	[DebugInfoInPDB]
	[MiscellaneousBits(64)]
	internal struct CComAutoCriticalSection
	{
		private long _003Calignment_0020member_003E;
	}
}
