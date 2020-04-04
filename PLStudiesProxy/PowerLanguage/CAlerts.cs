using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CAlerts : IAlert
	{
		private unsafe void* m_host;

		private bool m_enabled = false;

		public unsafe bool CheckAlertLastBar
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe bool Enabled
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe CAlerts(void* _host)
		{
		}

		public void Initialize()
		{
			m_enabled = Enabled;
		}

		public void Alert()
		{
			Alert(string.Empty);
		}

		public void Alert(string _format, object[] _args)
		{
			Alert(string.Format(_format, _args));
		}

		public unsafe void Alert(string _string)
		{
		}

		public unsafe void Cancel()
		{
		}

		private unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("CAlerts");
			}
			return (IBaseStudy*)host;
		}
	}
}
