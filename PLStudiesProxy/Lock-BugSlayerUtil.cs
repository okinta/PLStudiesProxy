using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 40)]
[NativeCppClass]
[MiscellaneousBits(64)]
[DebugInfoInPDB]
internal struct Lock_003CBugSlayerUtil_003A_003ACComAutoCriticalSection_003E
{
	[StructLayout(LayoutKind.Sequential, Size = 8)]
	[DebugInfoInPDB]
	[CLSCompliant(false)]
	[MiscellaneousBits(64)]
	[NativeCppClass]
	public struct Guard
	{
		private long _003Calignment_0020member_003E;
	}

	private long _003Calignment_0020member_003E;
}
