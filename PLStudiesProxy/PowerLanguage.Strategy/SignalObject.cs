using ATCenterProxy.interop;
using System;

namespace PowerLanguage.Strategy
{
	/// <summary>
	/// Base class for strategies 
	/// (inherit from SignalObject to create this kind of study).
	/// </summary>
	public abstract class SignalObject : CStudyAbstract, IStrategy
	{
		protected SignalObject(object _)
		{
		}

		/// <summary>
		/// Returns strategy's market position.
		/// </summary>
		public int PositionSide { get; protected set; }

		/// <summary>
		/// Returns a read-only collection of all strategy positions.
		/// </summary>
		public IROList<IMarketPosition> Positions { get; protected set; }

		/// <summary>
		/// Returns strategy's current position.
		/// </summary>
		public IMarketPosition CurrentPosition { get; protected set; }

		/// <summary>
		/// Returns the interface which provides Portfolio Perfomance.
		/// </summary>
		public IPortfolioPerformance Portfolio { get; protected set; }

		/// <summary>
		/// Returns strategy's fixed net profit.
		/// </summary>
		public double NetProfit { get; protected set; }

		/// <summary>				
		/// Returns the average length of even trades (without profit and loss) in terms of bars.
		/// </summary>
		public double AvgBarsEvenTrade { get; protected set; }

		/// <summary>
		/// Returns the average length of losing trades in terms of bars.
		/// </summary>
		// Token: 0x17000057 RID: 87
		public double AvgBarsLosTrade { get; protected set; }

		/// <summary>
		/// Returns the average length of winning trades in terms of bars.
		/// </summary>
		public double AvgBarsWinTrade { get; protected set; }

		/// <summary>				
		/// Returns a non-positive number that indicates total strategy loss.
		/// </summary>
		public double GrossLoss { get; protected set; }

		/// <summary>				
		/// Returns non-negative number that indicates total strategy profit. 
		/// </summary>
		public double GrossProfit { get; protected set; }

		/// <summary>				
		/// Returns non-positive number with the maximum loss of a single trade.
		/// </summary>
		public double LargestLosTrade { get; protected set; }

		/// <summary>				
		/// Returns non-negative number with maximum profit of a single trade.
		/// </summary>
		public double LargestWinTrade { get; protected set; }

		/// <summary>
		/// Returns maximum number of sequential unprofitable trades.
		/// </summary>
		public int MaxConsecLosers { get; protected set; }

		/// <summary>				
		/// Returns maximum number of sequential profitable trades.
		/// </summary>
		public int MaxConsecWinners { get; protected set; }

		/// <summary>				
		/// Returns maximal number of sequential unprofitable trades.
		/// </summary>
		public int MaxLotsHeld { get; protected set; }

		/// <summary>				
		/// Returns maximum potential loss (drawdown) during entire trading period.
		/// </summary>
		public double MaxDrawDown { get; protected set; }

		/// <summary>				
		/// Returns total number of trades that did not bring any profit or loss.
		/// </summary>
		public int NumEvenTrades { get; protected set; }

		/// <summary>
		/// Returns total number or losing trades.
		/// </summary>
		public int NumLosTrades { get; protected set; }

		/// <summary>
		/// Returns total number or profitable trades.
		/// </summary>
		public int NumWinTrades { get; protected set; }

		/// <summary>
		/// Returns a ratio of profitable trades to total number of trades expressed in percent 
		/// ( 100*(NumWinTrades/TotalTrades)).
		/// </summary>
		public double PercentProfit { get; protected set; }

		/// <summary>				
		/// Returns the total number of bars during which even trades (without profit and loss) were open.
		/// </summary>
		public int TotalBarsEvenTrades { get; protected set; }

		/// <summary>				
		/// Returns the total number of bars during which losing trades were open.
		/// </summary>
		public int TotalBarsLosTrades { get; protected set; }

		/// <summary>
		/// Returns the total number of bars during which winning trades were open.
		/// </summary>
		public int TotalBarsWinTrades { get; protected set; }

		/// <summary>
		/// Return total number of trades.
		/// </summary>
		public int TotalTrades { get; protected set; }

		/// <summary>
		/// Returns 'Commission' from the Strategy Properties window.
		/// </summary>
		public double Commission { get; protected set; }

		/// <summary>
		/// Returns 'Slippage' from the Strategy Properties window.
		/// </summary>
		public double Slippage { get; protected set; }

		/// <summary>
		/// Returns 'Initial Capital' from the Strategy Properties window.
		/// </summary>
		public double InitialCapital { get; protected set; }

		/// <summary>
		/// Returns 'Interest Rate' from the Strategy Properties window.
		/// </summary>
		public double InterestRate { get; protected set; }

		/// <summary>
		/// Returns currency code from Strategy settings (Base Currency)
		/// </summary>
		public MTPA_MCSymbolCurrency StrategyCurrencyCode { get; protected set; }

		/// <summary>
		/// Returns current account name.
		/// </summary>
		public string Account { get; protected set; }

		/// <summary>
		/// Returns current trading profile name.
		/// </summary>
		public string Profile { get; protected set; }

		/// <summary>				
		/// Returns the order generation interface (IOrderCreator).
		/// </summary>
		protected IOrderCreator OrderCreator { get; set; }

		/// <summary>
		/// Property for requesting or setting special orders mode:
		/// perLot,
		/// perPosition.
		/// </summary>
		protected ESpecOrdersMode CurSpecOrdersMode { get; set; }

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
		protected void GenerateStopLoss(double amount)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// ExitOnClose order generation.
		/// </summary>
		protected void GenerateExitOnClose()
		{
			throw new NotImplementedException();
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
		protected void GenerateDollarTrailing(double profit)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Market order generation.
		/// </summary>
		protected bool GenerateATMarketOrder(bool buy, bool entry, int lots)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// ProfitTarget order generation.
		/// Same as <see cref="M:PowerLanguage.Strategy.SignalObject.GenerateProfitTarget(System.Double)" />, but amount in points.
		/// </summary>
		protected void GenerateProfitTargetPt(double amount)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// TrailingStop order generation.
		/// Same as <see cref="M:PowerLanguage.Strategy.SignalObject.GenerateDollarTrailing(System.Double)" />, but amount in points.
		/// </summary>
		protected void GenerateTrailingStopPt(double amount)
		{
			throw new NotImplementedException();
		}
	}
}
