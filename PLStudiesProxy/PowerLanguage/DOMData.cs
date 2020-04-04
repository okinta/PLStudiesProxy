using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class DOMData : IDOMData
	{
		private uint m_dn;

		private unsafe void* m_host;

		public unsafe bool Connected
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe DOMPrice[] Bid
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe DOMPrice[] Ask
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe DOMData(void* _host, uint _dn)
		{
		}

		private unsafe static DOMPrice[] make_dom(IDOMDATA* _src)
		{
			throw new NotImplementedException();
		}

		private unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("DOMData");
			}
			return (IBaseStudy*)host;
		}
	}
}
