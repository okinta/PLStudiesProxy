using _003CCppImplementationDetails_003E;
using System;

namespace PowerLanguage
{
	internal class PriceSeriesDataRand : PriceSeriesData, ISeriesSymbolDataRand
	{
		private unsafe ILLSymbolData* m_ll;

		public unsafe int Count
		{
			get
			{
				return 0;
			}
		}

		public unsafe int Current
		{
			get
			{
				return 0;
			}
		}

		public unsafe PriceSeriesDataRand(void* _host, int _dn) : base(null, 0, new _0024PTMType_0024P8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z())
		{
		}
	}
}
