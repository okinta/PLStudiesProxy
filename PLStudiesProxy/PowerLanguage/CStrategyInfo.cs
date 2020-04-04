using _ELAPI_;
using ATCenterProxy.interop;
using ManagedStudies.details;
using std;
using STLLight;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CStrategyInfo : IStrategyPerformance
	{
		private unsafe void* m_host;

		public unsafe IStrategy[] Signals
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe double AvgEntryPriceAtBrokerForTheStrategy
		{
			get
			{
				return 0;
			}
		}

		public unsafe double AvgEntryPriceAtBroker
		{
			get
			{
				return 0;
			}
		}

		public unsafe int MarketPositionAtBrokerForTheStrategy
		{
			get
			{
				return 0;
			}
		}

		public unsafe int MarketPositionAtBroker
		{
			get
			{
				return 0;
			}
		}

		public unsafe int MarketPosition
		{
			get
			{
				return 0;
			}
		}

		public unsafe double ClosedEquity
		{
			get
			{
				return 0;
			}
		}

		public unsafe double OpenEquity
		{
			get
			{
				return 0;
			}
		}

		public unsafe double AvgEntryPrice
		{
			get
			{
				return 0;
			}
		}

		public unsafe CStrategyInfo(void* _host)
		{
		}

		public unsafe double GetPlotValue(int plot_num)
		{
			return 0;
		}

		public unsafe void SetPlotValue(int plot_num, double _value)
		{
		}

		public unsafe double ConvertCurrency(DateTime when, MTPA_MCSymbolCurrency from, MTPA_MCSymbolCurrency to, double val)
		{
			return 0;
		}

		private unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("IStrategyPerformance");
			}
			return (IBaseStudy*)host;
		}
	}
}
