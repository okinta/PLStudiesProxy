using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class RectanglesDrwImpl : RectangleObject, IDisposable
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
				long num = *(long*)impl + 2752;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ERectPattern Pattern
		{
			get
			{
				return ERectPattern.Solid;
			}
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 2736;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ETLStyle BorderStyle
		{
			get
			{
				return ETLStyle.ToolDashed;
			}
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 2720;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override Color FillColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
				//IL_0025: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 2704;
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
				long num = *(long*)impl + 2688;
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
					throw new ObjectDisposedException("RectanglesDrwImpl");
				}
				return host.Impl;
			}
		}

		public RectanglesDrwImpl(int _id, IDrawingsHost _host)
			: base(_id)
		{
		}

		private void _007ERectanglesDrwImpl()
		{
			m_host = null;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe sealed override bool Delete()
		{
			return false;
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
