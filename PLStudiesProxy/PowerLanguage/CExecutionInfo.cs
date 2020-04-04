using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CExecutionInfo : ICalculationInfo
	{
		private unsafe void* m_host;

		public unsafe int MaxBarsForward
		{
			get
			{
				return 0;
			}
		}

		public unsafe int MaxBarsBack
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public unsafe int ExecOffset
		{
			get
			{
				return 0;
			}
		}

		public unsafe int CurrentDataNumber
		{
			get
			{
				return 0;
			}
		}

		public unsafe int BaseDataNumber
		{
			get
			{
				return 0;
			}
		}

		public unsafe CExecutionInfo(void* _host)
		{
		}

		private unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("ICalculationInfo");
			}
			return (IBaseStudy*)host;
		}
	}
}
