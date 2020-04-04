using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ATL
{
	[StructLayout(LayoutKind.Sequential, Size = 48)]
	[MiscellaneousBits(64)]
	[NativeCppClass]
	[DebugInfoInPDB]
	internal struct CComAutoDeleteCriticalSection
	{
		private long _003Calignment_0020member_003E;
	}
}
