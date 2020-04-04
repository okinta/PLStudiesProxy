using ITS_MCDataStorage;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage.details
{
	internal sealed class CStatusLineDraw : IStatusLine, IDisposable
	{
		private unsafe IDataPriceSeries* m_data;

		public unsafe double BidSize
		{
			get
			{
				return 0;
			}
		}

		public unsafe double AskSize
		{
			get
			{
				return 0;
			}
		}

		public unsafe double LastVolume
		{
			get
			{
				return 0;
			}
		}

		public double DailyVolume => TotalVolume;

		public unsafe double OpenInt
		{
			get
			{
				return 0;
			}
		}

		public unsafe double TotalVolume
		{
			get
			{
				return 0;
			}
		}

		public unsafe double Last
		{
			get
			{
				return 0;
			}
		}

		public unsafe double Bid
		{
			get
			{
				return 0;
			}
		}

		public unsafe double Ask
		{
			get
			{
				return 0;
			}
		}

		public unsafe double PrevClose
		{
			get
			{
				return 0;
			}
		}

		public unsafe double Close
		{
			get
			{
				return 0;
			}
		}

		public unsafe double Open
		{
			get
			{
				return 0;
			}
		}

		public unsafe double Low
		{
			get
			{
				return 0;
			}
		}

		public unsafe double High
		{
			get
			{
				return 0;
			}
		}

		public unsafe DateTime Time
		{
			get
			{
				return new DateTime();
			}
		}

		public unsafe CStatusLineDraw(_com_ptr_t_003C_com_IIID_003CITS_MCDataStorage_003A_003AIDataPriceSeries_002C_0026_GUID_5be1326a_8069_43bd_be2d_739c5660a689_003E_0020_003E* _data)
		{
		}

		private unsafe void _007ECStatusLineDraw()
		{
			//IL_0017: Expected I, but got I8
			//IL_0020: Expected I, but got I8
			IDataPriceSeries* data = m_data;
			if (data != null)
			{
				/*OpCode not supported: CallIndirect*/;
			}
			m_data = null;
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
