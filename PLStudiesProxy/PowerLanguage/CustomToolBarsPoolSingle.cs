using PowerLanguage.details;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CustomToolBarsPoolSingle : CustomToolBarsPool, IDisposable
	{
		private static readonly CustomToolBarsPoolSingle s_this = new CustomToolBarsPoolSingle();

		public static CustomToolBarsPoolSingle Instance => s_this;

		protected sealed override CustomToolBar create_tb(IntPtr _h)
		{
			return new CustomToolBarImpl(_h);
		}

		private CustomToolBarsPoolSingle()
		{
		}

		private void _007ECustomToolBarsPoolSingle()
		{
		}

		protected void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
