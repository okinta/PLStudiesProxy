using _ELAPI_.variables;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal class IndexerImpl : Indexator, IDisposable
	{
		private unsafe ISerIndex* m_impl;

		private unsafe ISerIndex._index_ctx* m_index_ctx;

		public unsafe virtual int BufferSize
		{
			get
			{
				return 0;
			}
		}

		public unsafe virtual int this[int bars_ago] => 0;

		public unsafe IndexerImpl(ISerIndex* _index)
		{
		}//IL_001a: Expected I, but got I8


		private unsafe void _007EIndexerImpl()
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

		public void RecoveryIndexes(out int src, out int dst)
		{
			throw new NotImplementedException();
		}

		public void CloseBarIndexes(out int src, out int dst)
		{
			throw new NotImplementedException();
		}
	}
}
