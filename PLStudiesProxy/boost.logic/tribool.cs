using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace boost.logic
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[MiscellaneousBits(64)]
	[NativeCppClass]
	[DebugInfoInPDB]
	internal struct tribool
	{
		[DebugInfoInPDB]
		[CLSCompliant(false)]
		[MiscellaneousBits(64)]
		public enum value_t
		{

		}

		private int _003Calignment_0020member_003E;
	}
}
