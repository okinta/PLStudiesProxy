using _003CCppImplementationDetails_003E;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class ArrowDrwImpl : Arrow, IDisposable
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
				long num = *(long*)impl + 2424;
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
				long num = *(long*)impl + 2184;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override string Text
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		public unsafe sealed override string FontName
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		public unsafe sealed override int TextSize
		{
			get
			{
				return 0;
			}
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 1568;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override Color TextBGColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
				//IL_0025: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 1504;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override Color TextColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
				//IL_0025: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 1480;
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
				long num = *(long*)impl + 1432;
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
				long num = *(long*)impl + 1456;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool Direction
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe sealed override EArrowForms Style
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				//IL_0020: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 1448;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ChartPoint Location
		{
			get
			{
				throw new NotImplementedException();
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
					throw new ObjectDisposedException("ArrowDrwImpl");
				}
				return host.Impl;
			}
		}

		public ArrowDrwImpl(int _id, IDrawingsHost _host)
			: base(_id)
		{
		}

		private void _007EArrowDrwImpl()
		{
			m_host = null;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe sealed override bool Delete()
		{
			return false;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe sealed override bool HaveFont(FontStyle _style)
		{
			return false;
		}

		public unsafe sealed override void SetFont(FontStyle _style, [MarshalAs(UnmanagedType.U1)] bool _val)
		{
			//IL_0026: Expected I, but got I8
			IStdFunctions* impl = Impl;
			long num = *(long*)impl + 1536;
			/*OpCode not supported: CallIndirect*/;
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
