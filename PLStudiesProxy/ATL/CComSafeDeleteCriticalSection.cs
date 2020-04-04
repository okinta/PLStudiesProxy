using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ATL
{
	[StructLayout(LayoutKind.Sequential, Size = 48)]
	[NativeCppClass]
	[MiscellaneousBits(64)]
	[DebugInfoInPDB]
	internal struct CComSafeDeleteCriticalSection
	{
		private long _003Calignment_0020member_003E;
	}
}
