using System;
using System.Runtime.InteropServices;

namespace PowerLanguage.Strategy
{
	internal sealed class CPositionImpl : IMarketPosition
	{
		private int m_position;

		private unsafe IBaseStudy* m_host;

		private ROList<ITrade> m_open_trades = null;

		private ROList<ITrade> m_closed_trades = null;

		private bool m_got_closed = false;

		public unsafe IROList<ITrade> ClosedTrades
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe IROList<ITrade> OpenTrades
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public int Value => OpenLots * (int)Side;

		public unsafe int OpenLots
		{
			get
			{
				return 0;
			}
		}

		public unsafe double MaxRunUp
		{
			get
			{
				return 0;
			}
		}

		public unsafe double MaxDrawDown
		{
			get
			{
				return 0;
			}
		}

		public unsafe double OpenProfit
		{
			get
			{
				return 0;
			}
		}

		public unsafe double ProfitPerContract
		{
			get
			{
				return 0;
			}
		}

		public unsafe double Profit
		{
			get
			{
				return 0;
			}
		}

		public unsafe EMarketPositionSide Side
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe CPositionImpl(int _pos_idx, IBaseStudy* _host)
		{
		}

		private unsafe void fill_trades_coll(ROList<ITrade> _trades_coll, IStrategyOrders* _trade_access, int _offset, [MarshalAs(UnmanagedType.U1)] bool _is_open)
		{
			throw new NotImplementedException();
		}

		private unsafe int my_offset()
		{
			//IL_0015: Expected I, but got I8
			IBaseStudy* host = m_host;
			return (int)/*OpCode not supported: CallIndirect*/ - m_position;
		}

		private OrderCategory _2_order_category(int _i)
		{
			if (_i != 1)
			{
				return (_i == 2) ? OrderCategory.Limit : OrderCategory.Market;
			}
			return OrderCategory.Stop;
		}
	}
}
