using ATL;
using System;
using System.Runtime.InteropServices;

namespace cli_auto_ptr
{
	internal class auto_ptr_003CATL_003A_003ACComAutoCriticalSection_003E : IDisposable
	{
		private unsafe ATL.CComAutoCriticalSection* _Myptr;

		private unsafe void _007Eauto_ptr_003CATL_003A_003ACComAutoCriticalSection_003E()
		{
		}

		public unsafe void reset(ATL.CComAutoCriticalSection* _Ptr)
		{
		}

		public unsafe void reset()
		{
		}

		protected unsafe virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public unsafe auto_ptr_003CATL_003A_003ACComAutoCriticalSection_003E(ATL.CComAutoCriticalSection* _Ptr)
		{
		}

		public unsafe static ATL.CComAutoCriticalSection* op_PointerDereference(auto_ptr_003CATL_003A_003ACComAutoCriticalSection_003E _val)
		{
			ATL.CComAutoCriticalSection* myptr = _val._Myptr;
			if (0L == (long)(IntPtr)myptr)
			{
				throw new NullReferenceException("");
			}
			return myptr;
		}
	}
}
