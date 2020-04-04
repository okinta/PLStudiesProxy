using PowerLanguage.VolumeProfile;

namespace PowerLanguage
{
	internal interface PriceSeries : IPriceSeriesData, IInstrument, IInstrumentTPO
	{
		IProfilesCollection VolumeProfile
		{
			get;
		}

		void OnBeforeRTCalc();
	}
}
