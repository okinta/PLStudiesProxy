using ATL;
using cli_auto_ptr;
using CritSecHelper;
using PowerLanguage.PLDataLoader;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class DataLoaderProxy : IDataLoader
	{
		private static CSingleton<CDataLoader> m_data_loader_host = new CSingleton<CDataLoader>();

		private CDataLoader m_data_loader;

		private List<IDataLoaderResult> m_pending_results = new List<IDataLoaderResult>();

		private readonly cli_auto_ptr.auto_ptr_003CATL_003A_003ACComAutoCriticalSection_003E m_pCriticalSection;

		public unsafe DataLoaderProxy()
		{
		}

		private void _007EDataLoaderProxy()
		{
		}

		public void Free()
		{
			CancelPendingResults();
			m_data_loader = null;
			m_data_loader_host.ReleaseObject();
		}

		public unsafe IDataLoaderResult BeginLoadData(InstrumentDataRequest Request, LoadDataCallback userCallback, object State)
		{
			throw new NotImplementedException();
		}

		public unsafe void EndLoadData(IDataLoaderResult Result)
		{
			throw new NotImplementedException();
		}

		private unsafe void CancelPendingResults()
		{
		}

		[HandleProcessCorruptedStateExceptions]
		protected void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
