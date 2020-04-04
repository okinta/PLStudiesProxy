using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CEnvironment : IApplicationInfo
	{
		private unsafe void* m_host;

		public unsafe CalculationReason CalcReason
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe int ScannerRow
		{
			get
			{
				return 0;
			}
		}

		public unsafe IntPtr ChartWindowHWND
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe EApplicationCode ApplicationCode
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe Color BGColor
		{
			get
			{
				return Color.Empty;
			}
		}

		public unsafe string UserName
		{
			get
			{
				return "";
			}
		}

		public unsafe long UserID
		{
			get
			{
				return 0;
			}
		}

		public unsafe bool OrderConfirmationRequired
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe bool IsAutoTradingMode
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe bool IsRealTimeCalc
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe bool IOGEnabled
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe bool Optimizing
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe DateTime RightScreenTime
		{
			get
			{
				return new DateTime();
			}
		}

		public unsafe DateTime LeftScreenTime
		{
			get
			{
				return new DateTime();
			}
		}

		public unsafe double LowestScaleValue
		{
			get
			{
				return 0;
			}
		}

		public unsafe double HighestScaleValue
		{
			get
			{
				return 0;
			}
		}

		public unsafe int ChartShiftPcnt
		{
			get
			{
				return 0;
			}
		}

		public unsafe int ChartShiftBars
		{
			get
			{
				return 0;
			}
		}

		public unsafe double BarSpacing
		{
			get
			{
				return 0;
			}
		}

		public unsafe CEnvironment(void* _host)
		{
		}

		private unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("IApplicationInfo");
			}
			return (IBaseStudy*)host;
		}
	}
}
