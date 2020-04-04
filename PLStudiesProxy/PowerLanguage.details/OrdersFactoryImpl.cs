using System;

namespace PowerLanguage.details
{
	internal sealed class OrdersFactoryImpl : OrderCreator
	{
		private COrdersHost m_host;

		public OrdersFactoryImpl(COrdersHost _host)
		{
		}

		protected sealed override IOrderObject CreateOrder(Order _info)
		{
			switch (_info.Category)
			{
			default:
				throw new NotSupportedException("Not supported order category!");
			case OrderCategory.StopLimit:
				return new COrderStopLimit(_info, m_host);
			case OrderCategory.Stop:
				return new COrderPriced(_info, m_host);
			case OrderCategory.Limit:
				return new COrderPriced(_info, m_host);
			case OrderCategory.Market:
				return new COrderMarket(_info, m_host);
			}
		}
	}
}
