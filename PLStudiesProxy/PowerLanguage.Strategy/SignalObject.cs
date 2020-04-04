using _ELAPI_;
using ATCenterProxy.interop;
using ManagedStudies.details;
using PowerLanguage.details;
using std;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage.Strategy
{
	/// <summary>
	/// Base class for strategies 
	/// (inherit from SignalObject to create this kind of study).
	/// </summary>
	public abstract class SignalObject : CStudyAbstract, IStrategy
	{
		private unsafe IStrategyOrders* m_impl;

		private COrdersHost m_orders_host;

		private OrdersFactoryImpl m_factory;

		private ROList<IMarketPosition> m_pos_collection;

		private ESpecOrdersMode m_cur_order_mode;

		private IPortfolioPerformance m_portfolio;

		private bool m_need_actualize_positions;

		/// <summary>
		/// Property for requesting or setting special orders mode:
		/// perLot,
		/// perPosition.
		/// </summary>
		protected unsafe ESpecOrdersMode CurSpecOrdersMode
		{
			get
			{
				if (m_phase != (EExecutionPhase)3)
				{
					throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Execute (CalcBar method) only.", "CurSpecOrdersMode"));
				}
				return m_cur_order_mode;
			}
			set
			{
				//IL_0035: Expected I, but got I8
				//IL_004b: Expected I, but got I8
				if (m_phase != (EExecutionPhase)3)
				{
					throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Execute (CalcBar method) only.", "CurSpecOrdersMode"));
				}
				if (value == ESpecOrdersMode.PerContract)
				{
					IStrategyOrders* impl = m_impl;
					IStrategyOrders* intPtr = impl;
					/*OpCode not supported: CallIndirect*/;
				}
				else
				{
					IStrategyOrders* impl = m_impl;
					IStrategyOrders* intPtr2 = impl;
					/*OpCode not supported: CallIndirect*/;
				}
				m_cur_order_mode = value;
			}
		}

		/// <summary>				
		/// Returns the order generation interface (IOrderCreator).
		/// </summary>
		protected IOrderCreator OrderCreator
		{
			get
			{
				_check_for_disposed();
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Construct (Create method) only.", "OrderCreator"));
				}
				return m_factory;
			}
		}

		/// <summary>
		/// Set calculated fitness value. This method may be used during strategy optimization
		/// to pass custom calculated optimization criteria value.
		/// </summary>
		protected unsafe double CustomFitnessValue
		{
			set
			{
				//IL_0030: Expected I, but got I8
				_check_for_disposed();
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					IStrategyOrders* impl = m_impl;
					/*OpCode not supported: CallIndirect*/;
					return;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "CustomFitnessValue"));
			}
		}

		/// <summary>
		/// Returns current trading profile name.
		/// </summary>
		public unsafe string Profile
		{
			get
			{
				return "";
			}
		}

		/// <summary>
		/// Returns current account name.
		/// </summary>
		public unsafe string Account
		{
			get
			{
				return "";
			}
		}

		/// <summary>
		/// Returns currency code from Strategy settings (Base Currency)
		/// </summary>
		public unsafe MTPA_MCSymbolCurrency StrategyCurrencyCode
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Returns 'Interest Rate' from the Strategy Properties window.
		/// </summary>
		public unsafe double InterestRate
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns 'Initial Capital' from the Strategy Properties window.
		/// </summary>
		public unsafe double InitialCapital
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns 'Slippage' from the Strategy Properties window.
		/// </summary>
		public unsafe double Slippage
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns 'Commission' from the Strategy Properties window.
		/// </summary>
		public unsafe double Commission
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Return total number of trades.
		/// </summary>
		public unsafe int TotalTrades
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns the total number of bars during which winning trades were open.
		/// </summary>
		public unsafe int TotalBarsWinTrades
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns the total number of bars during which losing trades were open.
		/// </summary>
		public unsafe int TotalBarsLosTrades
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns the total number of bars during which even trades (without profit and loss) were open.
		/// </summary>
		public unsafe int TotalBarsEvenTrades
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns a ratio of profitable trades to total number of trades expressed in percent 
		/// ( 100*(NumWinTrades/TotalTrades)).
		/// </summary>
		public unsafe double PercentProfit
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns total number or profitable trades.
		/// </summary>
		public unsafe int NumWinTrades
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns total number or losing trades.
		/// </summary>
		public unsafe int NumLosTrades
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns total number of trades that did not bring any profit or loss.
		/// </summary>
		public unsafe int NumEvenTrades
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns maximum potential loss (drawdown) during entire trading period.
		/// </summary>
		public unsafe double MaxDrawDown
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns maximal number of sequential unprofitable trades.
		/// </summary>
		public unsafe int MaxLotsHeld
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns maximum number of sequential profitable trades.
		/// </summary>
		public unsafe int MaxConsecWinners
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns maximum number of sequential unprofitable trades.
		/// </summary>
		public unsafe int MaxConsecLosers
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns non-negative number with maximum profit of a single trade.
		/// </summary>
		public unsafe double LargestWinTrade
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns non-positive number with the maximum loss of a single trade.
		/// </summary>
		public unsafe double LargestLosTrade
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns non-negative number that indicates total strategy profit. 
		/// </summary>
		public unsafe double GrossProfit
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns a non-positive number that indicates total strategy loss.
		/// </summary>
		public unsafe double GrossLoss
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns the average length of winning trades in terms of bars.
		/// </summary>
		public unsafe double AvgBarsWinTrade
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns the average length of losing trades in terms of bars.
		/// </summary>
		public unsafe double AvgBarsLosTrade
		{
			get
			{
				return 0;
			}
		}

		/// <summary>				
		/// Returns the average length of even trades (without profit and loss) in terms of bars.
		/// </summary>
		public unsafe double AvgBarsEvenTrade
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns strategy's fixed net profit.
		/// </summary>
		public unsafe double NetProfit
		{
			get
			{
				return 0;
			}
		}

		/// <summary>
		/// Returns the interface which provides Portfolio Perfomance.
		/// </summary>
		public unsafe IPortfolioPerformance Portfolio
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Returns strategy's current position.
		/// </summary>
		public IMarketPosition CurrentPosition
		{
			get
			{
				_check_for_disposed();
				if (m_phase != (EExecutionPhase)3)
				{
					throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Execute (CalcBar method) only.", "CurrentPosition"));
				}
				actualize_positions();
				if (m_pos_collection.Count == 0)
				{
					return null;
				}
				return m_pos_collection[0];
			}
		}

		/// <summary>
		/// Returns a read-only collection of all strategy positions.
		/// </summary>
		public IROList<IMarketPosition> Positions
		{
			get
			{
				_check_for_disposed();
				if (m_phase != (EExecutionPhase)3)
				{
					throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Execute (CalcBar method) only.", "Positions"));
				}
				actualize_positions();
				return m_pos_collection;
			}
		}

		/// <summary>
		/// Returns strategy's market position.
		/// </summary>
		public unsafe int PositionSide
		{
			get
			{
				return 0;
			}
		}

		/// <exclude />
		protected unsafe SignalObject(object _ctx) : base(_ctx)
		{
		}

		private void _007ESignalObject()
		{
			((IDisposable)m_orders_host)?.Dispose();
			(m_portfolio as IDisposable)?.Dispose();
		}

		/// <exclude />
		protected sealed override void BeforeConstructImpl()
		{
			m_orders_host.SetConstructPhase();
			base.BeforeConstructImpl();
		}

		/// <exclude />
		protected sealed override void AfterConstructImpl()
		{
		}

		/// <exclude />
		protected override void BeforeInitializeImpl()
		{
			base.BeforeInitializeImpl();
			m_pos_collection.Items.Clear();
		}

		/// <exclude />
		protected sealed override void AfterInitializeImpl()
		{
			base.AfterInitializeImpl();
		}

		/// <exclude />
		protected sealed override void PreExecuteImpl()
		{
			m_orders_host.SetExecutablePhase();
			_PreExecuteImpl();
			m_need_actualize_positions = true;
		}

		/// <exclude />
		protected sealed override void DestroyImpl()
		{
		}

		private unsafe void actualize_positions()
		{
		}

		/// <exclude />
		protected void ChangeMarketPosition(int mp_delta, double fill_price)
		{
			ChangeMarketPosition(mp_delta, fill_price, string.Empty);
		}

		/// <exclude />
		protected unsafe void ChangeMarketPosition(int mp_delta, double fill_price, string _name)
		{
		}

		/// <summary>
		/// Assign initial market position at broker for the strategy.
		/// </summary>
		protected void SetInitialBrokerPosition(int market_pos, double avg_price, double max_op)
		{
			SetInitialBrokerPosition(null, market_pos, avg_price, max_op);
		}

		/// <summary>
		/// Assign initial market position at broker for the strategy.
		/// </summary>
		protected unsafe void SetInitialBrokerPosition(IOrderObject _entry, int market_pos, double avg_price, double max_op)
		{
		}

		/// <summary>
		/// StopLoss order generation.
		/// Closes out the entire position or the entry if the loss reaches the specified currency value; generates the appropriate Stop order depending on whether the position is long or short.
		/// Use <see cref="P:PowerLanguage.Strategy.SignalObject.CurSpecOrdersMode" /> property to determine whether the stop loss will be applied to the entire position or to each contract or share individually; by default, stop loss is applied to the entire position.
		/// GenerateStopLoss function is evaluated intra-bar and not only on close of a bar, and can exit within the same bar as the entry.
		///
		/// Note: Amount can be set either in the currency of the symbol or in the currecy of the strategy, depending on the key set in Windows Registry.
		/// Go to HKEY_CURRENT_USER\Software\TS Support\[ProductName]\StrategyProp and create a key DWORD Value: SpecOrdersAmountIsStrategyCurr.
		/// 0 - calculate Amount in the currency of the symbol.
		/// 1 - calculate Amount in the currency of the strategy/Portfolio (by default).
		/// [ProductName] is name of product, for example, "MultiCharts .NET", "MultiCharts .NET64" etc.
		/// If there is no such a key, Amount is calculated in the currency of the strategy/Portfolio. 
		/// </summary>
		protected unsafe void GenerateStopLoss(double amount)
		{
		}

		/// <summary>
		/// ProfitTarget order generation.
		/// Closes out the entire position or the entry if profit reaches the specified currency value; generates the appropriate Limit exit order depending on whether the position is long or short.
		/// Use <see cref="P:PowerLanguage.Strategy.SignalObject.CurSpecOrdersMode" /> property to determine whether the profit target will be applied to the entire position or to each contract or share individualy; by default, profit target is applied to the entire position.
		/// GenerateProfitTarget function is evaluated intra-bar and not only on close of a bar, and can exit within the same bar as the entry. 
		///
		/// Note: Amount can be set either in the currency of the symbol or in the currecy of the strategy, depending on the key set in Windows Registry.
		/// Go to HKEY_CURRENT_USER\Software\TS Support\[ProductName]\StrategyProp and create a key DWORD Value: SpecOrdersAmountIsStrategyCurr.
		/// 0 - calculate Amount in the currency of the symbol.
		/// 1 - calculate Amount in the currency of the strategy/Portfolio (by default).
		/// [ProductName] is name of product, for example, "MultiCharts .NET", "MultiCharts .NET64" etc.
		/// If there is no such a key, Amount is calculated in the currency of the strategy/Portfolio. 
		/// </summary>
		protected unsafe void GenerateProfitTarget(double amount)
		{
		}

		/// <summary>
		/// ExitOnClose order generation.
		/// </summary>
		protected unsafe void GenerateExitOnClose()
		{
		}

		/// <summary>
		/// BreakEven order generation.
		/// Closes out the entire position or the entry if it is at the breakeven point after the profit has reached the specified value; generates the appropriate Stop order depending on whether the position is long or short.
		/// Use <see cref="P:PowerLanguage.Strategy.SignalObject.CurSpecOrdersMode" /> property to determine whether SetBreakEven will be applied to the entire position or to each contract or share individually; by default, SetBreakEven is applied to the entire position.
		/// GenerateBreakEven function is evaluated intra-bar and not only on close of a bar, and can exit within the same bar as the entry. 
		///
		/// Note: Amount can be set either in the currency of the symbol or in the currecy of the strategy, depending on the key set in Windows Registry.
		/// Go to HKEY_CURRENT_USER\Software\TS Support\[ProductName]\StrategyProp and create a key DWORD Value: SpecOrdersAmountIsStrategyCurr.
		/// 0 - calculate Amount in the currency of the symbol.
		/// 1 - calculate Amount in the currency of the strategy/Portfolio (by default).
		/// [ProductName] is name of product, for example, "MultiCharts .NET", "MultiCharts .NET64" etc.
		/// If there is no such a key, Amount is calculated in the currency of the strategy/Portfolio. 
		/// </summary>
		protected unsafe void GenerateBreakEven(double profit)
		{
		}

		/// <summary>
		/// DollarTrailing order generation.
		/// Closes out the entire position or the entry if the current profit is less than the maximum profit by the specified amount; generates the appropriate Stop order depending on whether the position is long or short.
		/// For example, if the specified ammount is ¤50 and the profit has reached the maximum of ¤120, the position will be closed once the profit drops to ¤70.
		/// Use <see cref="P:PowerLanguage.Strategy.SignalObject.CurSpecOrdersMode" /> property to determine whether SetDollarTrailing will be applied to the entire position or to each contract or share individually; by default, SetDollarTrailing is applied to the entire position.
		/// GenerateDollarTrailing function is evaluated intra-bar and not only on close of a bar, and can exit within the same bar as the entry. 
		///
		/// Note: Amount can be set either in the currency of the symbol or in the currecy of the strategy, depending on the key set in Windows Registry.
		/// Go to HKEY_CURRENT_USER\Software\TS Support\[ProductName]\StrategyProp and create a key DWORD Value: SpecOrdersAmountIsStrategyCurr.
		/// 0 - calculate Amount in the currency of the symbol.
		/// 1 - calculate Amount in the currency of the strategy/Portfolio (by default).
		/// [ProductName] is name of product, for example, "MultiCharts .NET", "MultiCharts .NET64" etc.
		/// If there is no such a key, Amount is calculated in the currency of the strategy/Portfolio. 
		/// </summary>
		protected unsafe void GenerateDollarTrailing(double profit)
		{
		}

		/// <summary>
		/// PercentTrailing order generation.
		/// Closes out the entire position or the entry if the specified percentage of the maximum profit is lost after the profit has reached the specified value; generates the appropriate Stop order depending on whether the position is long or short.
		/// For example, if the specified profit is ¤100 and the specified percentage is 50, and the profit has reached the maximum of ¤120, the position will be closed once the profit falls back to ¤60.
		/// Use <see cref="P:PowerLanguage.Strategy.SignalObject.CurSpecOrdersMode" /> property to determine whether SetPercentTrailing will be applied to the entire position or each contract or share individually; by default, SetPercentTrailing is applied to the entire position.
		/// GeneratePercentTrailing function is evaluated intra-bar and not only on close of a bar, and can exit within the same bar as the entry.
		///
		/// Note: Amount can be set either in the currency of the symbol or in the currecy of the strategy, depending on the key set in Windows Registry.
		/// Go to HKEY_CURRENT_USER\Software\TS Support\[ProductName]\StrategyProp and create a key DWORD Value: SpecOrdersAmountIsStrategyCurr.
		/// 0 - calculate Amount in the currency of the symbol.
		/// 1 - calculate Amount in the currency of the strategy/Portfolio (by default).
		/// [ProductName] is name of product, for example, "MultiCharts .NET", "MultiCharts .NET64" etc.
		/// If there is no such a key, Amount is calculated in the currency of the strategy/Portfolio. 
		/// </summary>
		protected unsafe void GeneratePercentTrailing(double profit, double percentage)
		{
		}

		/// <summary>
		/// Market order generation.
		/// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		protected unsafe bool GenerateATMarketOrder([MarshalAs(UnmanagedType.U1)] bool buy, [MarshalAs(UnmanagedType.U1)] bool entry, int lots)
		{
			return false;
		}

		/// <summary>
		/// StopLoss order generation.
		/// Same as <see cref="M:PowerLanguage.Strategy.SignalObject.GenerateStopLoss(System.Double)" />, but amount in points.
		/// </summary>
		protected unsafe void GenerateStopLossPt(double amount)
		{
		}

		/// <summary>
		/// ProfitTarget order generation.
		/// Same as <see cref="M:PowerLanguage.Strategy.SignalObject.GenerateProfitTarget(System.Double)" />, but amount in points.
		/// </summary>
		protected unsafe void GenerateProfitTargetPt(double amount)
		{
		}

		/// <summary>
		/// BreakEven order generation.
		/// Same as <see cref="M:PowerLanguage.Strategy.SignalObject.GenerateBreakEven(System.Double)" />, but amount in points.
		/// </summary>
		protected unsafe void GenerateBreakEvenPt(double amount)
		{
		}

		/// <summary>
		/// TrailingStop order generation.
		/// Same as <see cref="M:PowerLanguage.Strategy.SignalObject.GenerateDollarTrailing(System.Double)" />, but amount in points.
		/// </summary>
		protected unsafe void GenerateTrailingStopPt(double amount)
		{
		}

		/// <summary>
		/// PercentTrailing order generation.
		/// Same as <see cref="M:PowerLanguage.Strategy.SignalObject.GeneratePercentTrailing(System.Double,System.Double)" />, but amount in points.
		/// </summary>
		protected unsafe void GeneratePercentTrailingPt(double amount, double percentage)
		{
		}

		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
			if (P_0)
			{
				try
				{
					_007ESignalObject();
				}
				finally
				{
					base.Dispose(true);
				}
			}
			else
			{
				base.Dispose(false);
			}
		}
	}
}
