using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CExecutionControl : ICalculationControl
	{
		private unsafe void* m_host;

		public unsafe CExecutionControl(void* _host)
		{
		}

		public void Abort(string _format_str, object[] _args)
		{
			Abort(string.Format(_format_str, _args));
		}

		public unsafe void Abort(string _error_message)
		{
		}

		public void Abort()
		{
			Abort(null);
		}

		public unsafe void Recalculate()
		{
		}

		public unsafe void RecalcLastBarAfter(TimeSpan interval)
		{
		}

		private unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("ICalculationControl");
			}
			return (IBaseStudy*)host;
		}
	}
}
