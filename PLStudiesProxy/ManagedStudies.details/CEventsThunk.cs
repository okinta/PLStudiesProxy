using PowerLanguage.Common;
using PowerLanguage.Server;
using System;
using System.Runtime.InteropServices;

namespace ManagedStudies.details
{
	internal class CEventsThunk : IDisposable
	{
		private EEServerProxy m_proxy;

		private unsafe CSimpleCServ* m_master;

		public unsafe CEventsThunk(CSimpleCServ* _master, EEServerProxy _proxy)
		{
			m_proxy.EQueryForChange += _QueryTechForChange;
			m_proxy.EChange += _Changed;
			m_proxy.ECompiled += _CompileEvent;
		}

		private void _007ECEventsThunk()
		{
			m_proxy.ECompiled -= _CompileEvent;
			m_proxy.EChange -= _Changed;
			m_proxy.EQueryForChange -= _QueryTechForChange;
		}

		private unsafe void _Changed(IStudy[] _techs, EStudyChangeAttributes _type)
		{
		}

		private unsafe void _QueryTechForChange(StudyID[] _techs, EStudyChangeAttributes _type, IAnswer4StudyChangeRequest _answer)
		{
		}

		private unsafe void _CompileEvent(AssemblyCompileResults _final, AssemblyCompileResults __unnamed001)
		{
		}

		protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
