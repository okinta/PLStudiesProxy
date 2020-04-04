using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace std
{
	[StructLayout(LayoutKind.Sequential, Size = 72)]
	[NativeCppClass]
	[DebugInfoInPDB]
	[MiscellaneousBits(64)]
	internal struct ios_base
	{
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		[MiscellaneousBits(64)]
		[CLSCompliant(false)]
		[NativeCppClass]
		[DebugInfoInPDB]
		public struct failure
		{
			private long _003Calignment_0020member_003E;
		}

		private long _003Calignment_0020member_003E;
	}
}
