using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal interface IPriceSeriesData : ISeriesSymbolData, ITPOData, IDisposable
	{
		DateTime BarUpdateTime
		{
			get;
		}

		bool IsExist
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get;
		}

		void EnsureReBinded();

		void ReBind();
	}
}
