namespace PowerLanguage
{
	internal class TPOSeriesDataRand : PriceSeriesDataRand, ITPODataRand
	{
		public unsafe int CountTPO
		{
			get
			{
				return 0;
			}
		}

		public unsafe int CurrentTPO
		{
			get
			{
				return 0;
			}
		}

		public unsafe TPOSeriesDataRand(void* _host, int _dn)
			: base(_host, _dn)
		{
		}
	}
}
