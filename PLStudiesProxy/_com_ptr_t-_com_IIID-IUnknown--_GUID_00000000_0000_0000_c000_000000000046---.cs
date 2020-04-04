using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[MiscellaneousBits(64)]
[DebugInfoInPDB]
[NativeCppClass]
internal struct _com_ptr_t_003C_com_IIID_003CIUnknown_002C_0026_GUID_00000000_0000_0000_c000_000000000046_003E_0020_003E
{
	private long _003Calignment_0020member_003E;

	public unsafe static void _003CMarshalCopy_003E(_com_ptr_t_003C_com_IIID_003CIUnknown_002C_0026_GUID_00000000_0000_0000_c000_000000000046_003E_0020_003E* P_0, _com_ptr_t_003C_com_IIID_003CIUnknown_002C_0026_GUID_00000000_0000_0000_c000_000000000046_003E_0020_003E* P_1)
	{
		//IL_0015: Expected I, but got I8
		//IL_0015: Expected I, but got I8
		long num = *(long*)P_0 = *(long*)P_1;
		if (num != 0L)
		{
			/*OpCode not supported: CallIndirect*/;
		}
	}

	public unsafe static void _003CMarshalDestroy_003E(_com_ptr_t_003C_com_IIID_003CIUnknown_002C_0026_GUID_00000000_0000_0000_c000_000000000046_003E_0020_003E* P_0)
	{
		//IL_0013: Expected I, but got I8
		//IL_0013: Expected I, but got I8
		ulong num = (ulong)(*(long*)P_0);
		if (num != 0L)
		{
			/*OpCode not supported: CallIndirect*/;
		}
	}
}
