using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage.Strategy
{
	internal sealed class PortfolioPerformance : IPortfolioPerformance, IDisposable
	{
		private unsafe IBaseStudy* m_host;

		public unsafe Lambda<double> PortfolioEntriesPriority
		{
			set
			{
			}
		}

		public unsafe double MinAcceptableRate
		{
			get
			{
				return 0;
			}
		}

		public unsafe double InterestRate
		{
			get
			{
				return 0;
			}
		}

		public unsafe int TotalTrades
		{
			get
			{
				return 0;
			}
		}

		public unsafe double TotalMaxRiskEquityPercent
		{
			get
			{
				return 0;
			}
		}

		public unsafe double StrategyDrawdown
		{
			get
			{
				return 0;
			}
		}

		public unsafe double PercentProfit
		{
			get
			{
				return 0;
			}
		}

		public unsafe int ProfitTradesNumber
		{
			get
			{
				return 0;
			}
		}

		public unsafe double OpenPositionProfit
		{
			get
			{
				return 0;
			}
		}

		public unsafe double NetProfit
		{
			get
			{
				return 0;
			}
		}

		public unsafe double MaxRiskEquityPerPosPercent
		{
			get
			{
				return 0;
			}
		}

		public unsafe double MaxPotentialLossPerContract
		{
			get
			{
				return 0;
			}
		}

		public unsafe double MaxOpenPositionPotentialLoss
		{
			get
			{
				return 0;
			}
		}

		public unsafe double MaxIDDrawdown
		{
			get
			{
				return 0;
			}
		}

		public unsafe double MarginPerContract
		{
			get
			{
				return 0;
			}
		}

		public unsafe int LossTradesNumber
		{
			get
			{
				return 0;
			}
		}

		public unsafe double InvestedCapital
		{
			get
			{
				return 0;
			}
		}

		public unsafe double GrossProfit
		{
			get
			{
				return 0;
			}
		}

		public unsafe double GrossLoss
		{
			get
			{
				return 0;
			}
		}

		public unsafe int CurrentEntries
		{
			get
			{
				return 0;
			}
		}

		public unsafe PortfolioPerformance(IBaseStudy* host)
		{
			//IL_0022: Expected I, but got I8
			IBaseStudy* host2 = m_host;
			/*OpCode not supported: CallIndirect*/;
		}

		private unsafe void _007EPortfolioPerformance()
		{
			//IL_0008: Expected I, but got I8
			m_host = null;
		}

		public double CalcMaxPotentialLossForEntry(int side)
		{
			return CalcMaxPotentialLossForEntry(side, 0, 0.0);
		}

		public double CalcMaxPotentialLossForEntry(int side, int contracts)
		{
			return CalcMaxPotentialLossForEntry(side, contracts, 0.0);
		}

		public unsafe double CalcMaxPotentialLossForEntry(int side, int contracts, double price)
		{
			return 0;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool SetMaxPotentialLossPerContract(double newValue)
		{
			return false;
		}

		private unsafe IBaseStudy* host()
		{
			IBaseStudy* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("Portfolio");
			}
			return host;
		}

		protected unsafe void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
