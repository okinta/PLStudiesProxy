using ITS_DataSeriesBuffer;
using ITS_MCCharting;
using ITS_MCDataStorage;
using PowerLanguage.ITS_mcdam;
using std;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using tsDateTime;

namespace PowerLanguage.details
{
	internal class DrawDataEnviroment : IDrawDataEnviroment, IDrawSymbolBars, IDisposable
	{
		private unsafe ICustomDrawContextData* m_ctx;

		private unsafe IDataPriceSeries* m_ps;

		private unsafe IDataPriceSeriesBuffer* m_ps_buff;

		private unsafe ImcSeriaDataAccess* m_mc_sda;

		private uint m_dn;

		private IStatusLine m_sl = null;

		public Bar[] All
		{
			get
			{
				Bar[] bars = null;
				Get(0u, out bars);
				return bars;
			}
		}

		public unsafe Bar this[uint i]
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe uint PureCount
		{
			get
			{
				return 0;
			}
		}

		public unsafe uint Count
		{
			get
			{
				return 0;
			}
		}

		public unsafe int ChartBarCloseDistance
		{
			get
			{
				//IL_001e: Expected I, but got I8
				int result = 0;
				ICustomDrawContextData* ctx = m_ctx;
				/*OpCode not supported: CallIndirect*/;
				return result;
			}
		}

		public unsafe IStatusLine StatusLine
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IDrawSymbolBars Bars => this;

		public unsafe DrawDataEnviroment(ICustomDrawContextData* _ctx, uint _dn)
		{
		}

		private unsafe void _007EDrawDataEnviroment()
		{
			//IL_002c: Expected I, but got I8
			//IL_003f: Expected I, but got I8
			//IL_0052: Expected I, but got I8
			//IL_0065: Expected I, but got I8
			(m_sl as IDisposable)?.Dispose();
			ImcSeriaDataAccess* mc_sda = m_mc_sda;
			if (mc_sda != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
			IDataPriceSeriesBuffer* ps_buff = m_ps_buff;
			/*OpCode not supported: CallIndirect*/;
			IDataPriceSeries* ps = m_ps;
			/*OpCode not supported: CallIndirect*/;
			ICustomDrawContextData* ctx = m_ctx;
			/*OpCode not supported: CallIndirect*/;
		}

		public unsafe virtual ChartPoint Point2ChartPoint(PointF p)
		{
			return new ChartPoint();
		}

		public unsafe virtual PointF ChartPoint2Point(ChartPoint p)
		{
			throw new NotImplementedException();
		}

		public unsafe int BarIndex2PointX(uint index)
		{
			return 0;
		}

		public unsafe uint PointX2BarIndex(int X)
		{
			return 0;
		}

		private static EBarState make_state(uint _status)
		{
			if (1 == (_status & 1))
			{
				return EBarState.Open;
			}
			return (8 != (_status & 8)) ? EBarState.Inside : EBarState.Close;
		}

		private static ETickTradedSide make_tick_traded_side(uint _status)
		{
			if ((_status & 0x10000) != 0)
			{
				return ETickTradedSide.AskTraded;
			}
			return (ETickTradedSide)((_status >> 16) & 2);
		}

		private static ETickTradedSideEx make_tick_traded_side_ex(uint _status)
		{
			if ((_status & 0x800) != 0)
			{
				return ETickTradedSideEx.Ask;
			}
			if ((_status & 0x1000) != 0)
			{
				return ETickTradedSideEx.Bid;
			}
			if ((_status & 0x2000) != 0)
			{
				return ETickTradedSideEx.AboveAsk;
			}
			if ((_status & 0x4000) != 0)
			{
				return ETickTradedSideEx.BellowBid;
			}
			return ((_status & 0x8000) != 0) ? ETickTradedSideEx.BetweenAskBid : ETickTradedSideEx.Undefined;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private static bool make_eos(uint _status)
		{
			return (byte)((_status >> 4) & 1) != 0;
		}

		private unsafe static Bar make_bar(ITS_DataSeriesBuffer.SBar* _bar)
		{
			DateTime time = new DateTime(*(long*)_bar);
			uint num = (uint)(*(int*)((long)(IntPtr)_bar + 80));
			byte eos = (byte)((num >> 4) & 1);
			uint num2 = num;
			ETickTradedSideEx exside = ((num2 & 0x800) != 0) ? ETickTradedSideEx.Ask : (((num2 & 0x1000) != 0) ? ETickTradedSideEx.Bid : (((num2 & 0x2000) != 0) ? ETickTradedSideEx.AboveAsk : (((num2 & 0x4000) == 0) ? (((num2 & 0x8000) != 0) ? ETickTradedSideEx.BetweenAskBid : ETickTradedSideEx.Undefined) : ETickTradedSideEx.BellowBid)));
			uint num3 = num;
			ETickTradedSide side = (ETickTradedSide)(((num3 & 0x10000) != 0) ? 1 : ((int)((num3 >> 16) & 2)));
			uint num4 = num;
			EBarState state = (1 != (num4 & 1)) ? ((8 != (num4 & 8)) ? EBarState.Inside : EBarState.Close) : EBarState.Open;
			return new Bar(time, *(double*)((long)(IntPtr)_bar + 8), *(double*)((long)(IntPtr)_bar + 16), *(double*)((long)(IntPtr)_bar + 24), *(double*)((long)(IntPtr)_bar + 32), (float)(double)(ulong)(*(long*)((long)(IntPtr)_bar + 40)), (float)(double)(ulong)(*(long*)((long)(IntPtr)_bar + 48)), (float)(double)(ulong)(*(long*)((long)(IntPtr)_bar + 56)), (float)(double)(ulong)(*(long*)((long)(IntPtr)_bar + 64)), (uint)(*(int*)((long)(IntPtr)_bar + 92)), (float)(double)(ulong)(*(long*)((long)(IntPtr)_bar + 72)), state, side, exside, eos != 0, (uint)(*(int*)((long)(IntPtr)_bar + 88)));
		}

		private unsafe uint index_by_dt(DateTime val)
		{
			return 0;
		}

		public uint GetIndexByTime(DateTime dt)
		{
			return index_by_dt(dt);
		}

		public unsafe virtual void Get(uint from, uint to, out Bar[] bars)
		{
			throw new NotImplementedException();
		}

		public virtual void Get(uint from, out Bar[] bars)
		{
			Get(from, Count, out bars);
		}

		public void Get(DateTime from, DateTime to, out Bar[] bars)
		{
			Get(index_by_dt(from), index_by_dt(to), out bars);
		}

		private unsafe IDataPriceSeries* ps()
		{
			return m_ps;
		}

		private unsafe IDataPriceSeriesBuffer* ps_buff()
		{
			return m_ps_buff;
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
