using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
[MiscellaneousBits(64)]
[DebugInfoInPDB]
internal struct _bstr_t
{
	[StructLayout(LayoutKind.Sequential, Size = 24)]
	[MiscellaneousBits(64)]
	[NativeCppClass]
	[DebugInfoInPDB]
	internal struct Data_t
	{
		private long _003Calignment_0020member_003E;
	}

	private long _003Calignment_0020member_003E;

	public unsafe static void _003CMarshalCopy_003E(_bstr_t* P_0, _bstr_t* P_1)
	{
		long num = *(long*)P_0 = *(long*)P_1;
		if (num != 0L)
		{
			Interlocked.Increment(ref *(int*)(num + 16));
		}
	}

	public unsafe static void _003CMarshalDestroy_003E(_bstr_t* P_0)
	{
	}
}
