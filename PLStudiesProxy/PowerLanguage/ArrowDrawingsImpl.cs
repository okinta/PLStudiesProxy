using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class ArrowDrawingsImpl : ArrowCreator<ArrowDrwImpl>, IArrowDrawingsEx, DrawingsContainer<ArrowDrwImpl>.IDrawingCreator
	{
		private unsafe IStdFunctions* m_host;

		public unsafe IStdFunctions* Impl => m_host;

		public unsafe sealed override IArrowObject Active
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe ArrowDrawingsImpl(IStdFunctions* _host)
		{
		}

		private void _007EArrowDrawingsImpl()
		{
		}

		public void Initialize()
		{
			clear_cache();
		}

		public ArrowDrwImpl Create(int _id)
		{
			return new ArrowDrwImpl(_id, this);
		}

		private unsafe IArrowObject Create(ChartPoint _point, [MarshalAs(UnmanagedType.U1)] bool _direction, int _data_stream, [MarshalAs(UnmanagedType.U1)] bool _on_same_subchart)
		{
			throw new NotImplementedException();
		}

		public sealed override IArrowObject Create(ChartPoint _point, [MarshalAs(UnmanagedType.U1)] bool _direction, [MarshalAs(UnmanagedType.U1)] bool _on_same_subchart)
		{
			return Create(_point, _direction, 0, _on_same_subchart);
		}

		public sealed override IArrowObject Create(ChartPoint _point, [MarshalAs(UnmanagedType.U1)] bool _direction, int _data_stream)
		{
			return Create(_point, _direction, _data_stream, _on_same_subchart: false);
		}

		[HandleProcessCorruptedStateExceptions]
		protected void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public sealed override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public override bool GetFirst(EDrawingSource drawingSource, out ArrowDrwImpl drw)
		{
			throw new NotImplementedException();
		}

		public override bool GetNext(EDrawingSource drawingSource, ArrowDrwImpl prev, out ArrowDrwImpl drw)
		{
			throw new NotImplementedException();
		}

		public unsafe IArrowDrawingsEx Create(IStdFunctions* _host)
		{
			throw new NotImplementedException();
		}
	}
}
