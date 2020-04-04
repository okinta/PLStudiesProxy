using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CExpertCommentary : IExpertCommentary
	{
		private unsafe void* m_host;

		public unsafe bool AtCommentaryBar
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

		public unsafe CExpertCommentary(void* _host)
		{
		}

		public unsafe void Write(string format, object[] _args)
		{
		}

		public unsafe void WriteLine(string format, object[] _args)
		{
		}

		private unsafe IStdFunctions* host()
		{
			throw new NotImplementedException();
		}
	}
}
