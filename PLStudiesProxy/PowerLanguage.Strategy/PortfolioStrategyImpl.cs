using PowerLanguage.Strategy.implementation;
using std;
using STLLight;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage.Strategy
{
	internal sealed class PortfolioStrategyImpl : PortfolioStrategyBase, IDisposable
	{
		private int m_myIdx;

		private unsafe IPortfStrategyEx* m_impl;

		private IStrategy[] m_signals;

		public unsafe sealed override bool AllowExitsShort
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0018: Expected I, but got I8
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool AllowExitsLong
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0018: Expected I, but got I8
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool AllowExits
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0018: Expected I, but got I8
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool AllowEntriesShort
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0018: Expected I, but got I8
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool AllowEntriesLong
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0018: Expected I, but got I8
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override bool AllowEntries
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0018: Expected I, but got I8
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override int EntryContracts
		{
			get
			{
				return 0;
			}
			set
			{
				//IL_0019: Expected I, but got I8
				double num = value;
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public sealed override int MyIndex => m_myIdx;

		public unsafe sealed override string Status
		{
			set
			{
			}
		}

		public unsafe sealed override double RiskCapital
		{
			get
			{
				return 0;
			}
		}

		public unsafe sealed override bool Paused
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				//IL_0015: Expected I, but got I8
				IPortfStrategyEx* ptr = impl();
				/*OpCode not supported: CallIndirect*/;
			}
		}

		public unsafe sealed override IStrategy[] Signals
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe PortfolioStrategyImpl(int myIdx, IPortfStrategyEx* _impl)
		{
		}

		private unsafe void _007EPortfolioStrategyImpl()
		{
			//IL_0008: Expected I, but got I8
			m_impl = null;
		}

		public unsafe sealed override void ForceClosePosition()
		{
			//IL_0012: Expected I, but got I8
			IPortfStrategyEx* intPtr = impl();
			/*OpCode not supported: CallIndirect*/;
		}

		public unsafe sealed override void PartialClosePosition([MarshalAs(UnmanagedType.U1)] bool isNextBar, int contracts)
		{
			//IL_0019: Expected I, but got I8
			IPortfStrategyEx* ptr = impl();
			/*OpCode not supported: CallIndirect*/;
		}

		private unsafe IPortfStrategyEx* impl()
		{
			IPortfStrategyEx* impl = m_impl;
			if (impl == null)
			{
				throw new ObjectDisposedException("IPortfolioStrategy");
			}
			return impl;
		}

		[HandleProcessCorruptedStateExceptions]
		protected void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public sealed override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
