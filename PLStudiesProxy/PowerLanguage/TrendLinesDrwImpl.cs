using _003CCppImplementationDetails_003E;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class TrendLinesDrwImpl : TrendLine, IDisposable
	{
		private IDrawingsHost m_host;

		public unsafe sealed override bool AnchorToBars
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 2416;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool Locked
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 2176;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool ExtRight
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 720;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool ExtLeft
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 712;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override EAlertType Alert
		{
			get
			{
				return EAlertType.BreakoutIntrabar;
			}
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 920;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ETLStyle Style
		{
			get
			{
				return ETLStyle.ToolDashed;
			}
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 792;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override int Size
		{
			get
			{
				return 0;
			}
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 888;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override Color Color
		{
			get
			{
				return Color.Empty;
			}
			set
			{
				//IL_0025: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 768;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ChartPoint End
		{
			get
			{
				return new ChartPoint();
			}
			set
			{
			}
		}

		public unsafe sealed override ChartPoint Begin
		{
			get
			{
				return new ChartPoint();
			}
			set
			{
			}
		}

		public unsafe sealed override bool Exist
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		private unsafe IStdFunctions* Impl
		{
			get
			{
				IDrawingsHost host = m_host;
				if (host == null)
				{
					throw new ObjectDisposedException("TrendLinesDrwImpl");
				}
				return host.Impl;
			}
		}

		public TrendLinesDrwImpl(int _id, IDrawingsHost _host)
			: base(_id)
		{
		}

		private void _007ETrendLinesDrwImpl()
		{
			m_host = null;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe sealed override bool Delete()
		{
			return false;
		}

		public unsafe sealed override double PriceValue(DateTime DateTime)
		{
			return 0;
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
