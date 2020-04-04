using boost;
using ITS_MCCharting;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage.details
{
	internal class CChartCustomDraw : ChartCustomDrawRegistrator, IDisposable
	{
		protected unsafe _cust_drw_stub* m_stub = null;

		protected unsafe ICustomDrawHostProvider* m_prov;

		protected uint m_dn;

		public unsafe sealed override IDrawDataEnviroment Environment
		{
			get
			{
				//IL_0012: Expected I, but got I8
				IntPtr value = new IntPtr((void*)(*(long*)((long)(IntPtr)m_stub + 88)));
				return (IDrawDataEnviroment)((GCHandle)value).Target;
			}
		}

		public unsafe CChartCustomDraw(ICustomDrawHostProvider* _prov, uint _dn)
		{
			//IL_0008: Expected I, but got I8
			//IL_0032: Expected I, but got I8
			ICustomDrawHostProvider* prov = m_prov;
			if (prov != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
		}

		private unsafe void _007ECChartCustomDraw()
		{
			//IL_001d: Expected I, but got I8
			//IL_0026: Expected I, but got I8
			deactivate();
			ICustomDrawHostProvider* prov = m_prov;
			if (prov != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
			m_prov = null;
		}

		public void Initialize()
		{
			OnInitialize();
		}

		public void UnInitialize()
		{
			OnInitializeEx(_force_deactivate_only: true);
		}

		public void DoDraw(DrawContext context, EDrawPhases _phase)
		{
			OnDraw(context, _phase);
		}

		public unsafe sealed override void ReDraw()
		{
		}

		protected unsafe override void activate()
		{
		}

		protected unsafe sealed override void deactivate()
		{
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
