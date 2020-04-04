using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CStatusLine : IStatusLine
	{
		private unsafe void* m_host;

		private uint m_dn;

		public unsafe double LastVolume
		{
			get
			{
				return 0;
			}
		}

		public unsafe double DailyVolume
		{
			get
			{
				return 0;
			}
		}

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

		public unsafe CStatusLine(void* _host, uint _dn)
		{
		}

		private unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("CStatusLine");
			}
			return (IBaseStudy*)host;
		}
	}
}
