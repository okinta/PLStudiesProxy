using ITS_MCCharting;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PowerLanguage.details
{
	internal sealed class CustomToolBarImpl : CustomToolBar, IDisposable
	{
		private unsafe ITS_MCCharting.ICustomToolBar* m_tb_p = null;

		public unsafe CustomToolBarImpl(IntPtr _h)
			: base(_h)
		{
		}

		private unsafe void _007ECustomToolBarImpl()
		{
			//IL_0008: Expected I, but got I8
			m_tb_p = null;
		}

		protected unsafe sealed override void on_create_control(IntPtr _handle)
		{
			//IL_0024: Expected I, but got I8
			//IL_0039: Expected I, but got I8
			ITS_MCCharting.ICustomToolBar* tb_p = m_tb_p;
			if (tb_p != null)
			{
				long num = *(long*)tb_p + 32;
				/*OpCode not supported: CallIndirect*/;
				tb_p = m_tb_p;
				ITS_MCCharting.ICustomToolBar* intPtr = tb_p;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		protected unsafe sealed override void hide_control()
		{
			//IL_0017: Expected I, but got I8
			ITS_MCCharting.ICustomToolBar* tb_p = m_tb_p;
			if (tb_p != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
		}

		protected unsafe sealed override void show_control()
		{
			//IL_0017: Expected I, but got I8
			ITS_MCCharting.ICustomToolBar* tb_p = m_tb_p;
			if (tb_p != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
		}

		protected sealed override void on_destroy_control(IntPtr _handle)
		{
		}

		protected unsafe sealed override void on_dock_changed(DockStyle _style, [MarshalAs(UnmanagedType.U1)] bool _before_or_after)
		{
			//IL_0031: Expected I, but got I8
			ITS_MCCharting.ICustomToolBar.Docking docking = (ITS_MCCharting.ICustomToolBar.Docking)0;
			switch (_style)
			{
			case DockStyle.Right:
				docking = (ITS_MCCharting.ICustomToolBar.Docking)3;
				break;
			case DockStyle.Left:
				docking = (ITS_MCCharting.ICustomToolBar.Docking)2;
				break;
			case DockStyle.Bottom:
				docking = (ITS_MCCharting.ICustomToolBar.Docking)1;
				break;
			}
			ITS_MCCharting.ICustomToolBar* tb_p = m_tb_p;
			if (tb_p != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
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
