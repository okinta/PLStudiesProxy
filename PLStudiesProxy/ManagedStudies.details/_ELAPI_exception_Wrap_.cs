using _ELAPI_;
using System;
using System.Runtime.InteropServices;

namespace ManagedStudies.details
{
	internal class _ELAPI_exception_Wrap_ : ApplicationException, IDisposable
	{
		private unsafe _ELAPI_exception_base* m_unmanaged_exc;

		public unsafe _ELAPI_exception_Wrap_(_ELAPI_exception_base* _unmanaged_exc)
		{
		}

		private unsafe void _007E_ELAPI_exception_Wrap_()
		{
			//IL_0018: Expected I, but got I8
			_ELAPI_exception_base* unmanaged_exc = m_unmanaged_exc;
			if (unmanaged_exc != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe void reraise()
		{
			//IL_0012: Expected I, but got I8
			_ELAPI_exception_base* unmanaged_exc = m_unmanaged_exc;
			/*OpCode not supported: CallIndirect*/;
		}

		protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
