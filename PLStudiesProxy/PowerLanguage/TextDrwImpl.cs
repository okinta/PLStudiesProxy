using _003CCppImplementationDetails_003E;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class TextDrwImpl : TextObject, IDisposable
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
				long num = *(long*)impl + 2432;
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
				long num = *(long*)impl + 2192;
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
				long num = *(long*)impl + 1200;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool Border
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
				long num = *(long*)impl + 1216;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ETextStyleV VStyle
		{
			get
			{
				return ETextStyleV.Above;
			}
			set
			{
				//IL_0026: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 1080;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ETextStyleH HStyle
		{
			get
			{
				return ETextStyleH.Center;
			}
			set
			{
				//IL_0026: Expected I, but got I8
				IStdFunctions* impl = Impl;
				long num = *(long*)impl + 1080;
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override ChartPoint Location
		{
			get
			{
				return new ChartPoint();
			}
			set
			{
			}
		}

		public unsafe sealed override Color BGColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
				//IL_002d: Expected I, but got I8
				//IL_0055: Expected I, but got I8
				if (Color.Transparent == value)
				{
					IStdFunctions* impl = Impl;
					long num = *(long*)impl + 2384;
					/*OpCode not supported: CallIndirect*/;
				}
				else
				{
					IStdFunctions* impl2 = Impl;
					long num2 = *(long*)impl2 + 1192;
					/*OpCode not supported: CallIndirect*/;
				}
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
				long num = *(long*)impl + 1056;
				/*OpCode not supported: CallIndirect*/;
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
					throw new ObjectDisposedException("TextDrwImpl");
				}
				return host.Impl;
			}
		}

		public TextDrwImpl(int _id, IDrawingsHost _host)
			: base(_id)
		{
		}

		private void _007ETextDrwImpl()
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
			long num = *(long*)impl + 1256;
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
