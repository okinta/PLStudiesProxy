using ATCenterProxy.interop;
using PowerLanguage.Strategy.implementation;
using System;

namespace PowerLanguage.Strategy
{
	internal sealed class PortfolioStrategiesCollImpl : PortfolioStrategiesColl
	{
		public unsafe PortfolioStrategiesCollImpl(IBaseStudy* _st)
		{
		}

		public unsafe IPortfolioData find_my_data(IBaseStudy* _st)
		{
			throw new NotImplementedException();
		}
	}
}
