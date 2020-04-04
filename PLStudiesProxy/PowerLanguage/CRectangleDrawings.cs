using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CRectangleDrawings : RectangleCreator<RectanglesDrwImpl>, IRectangleDrawingsEx, DrawingsContainer<RectanglesDrwImpl>.IDrawingCreator
	{
		private unsafe IStdFunctions* m_host;

		public unsafe IStdFunctions* Impl => m_host;

		public unsafe sealed override IRectangleObject Active
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe CRectangleDrawings(IStdFunctions* _host)
		{
		}

		private void _007ECRectangleDrawings()
		{
		}

		public void Initialize()
		{
			clear_cache();
		}

		public RectanglesDrwImpl Create(int _id)
		{
			return new RectanglesDrwImpl(_id, this);
		}

		private unsafe IRectangleObject Create(ChartPoint P_0, ChartPoint P_1, int P_2, [MarshalAs(UnmanagedType.U1)] bool P_3)
		{
			throw new NotImplementedException();
		}

		public sealed override IRectangleObject Create(ChartPoint _point1, ChartPoint _point2, [MarshalAs(UnmanagedType.U1)] bool _on_same_subchart)
		{
			return Create(_point1, _point2, 0, _on_same_subchart);
		}

		public sealed override IRectangleObject Create(ChartPoint _point1, ChartPoint _point2, int _data_num)
		{
			return Create(_point1, _point2, _data_num, false);
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

		public override bool GetFirst(EDrawingSource drawingSource, out RectanglesDrwImpl drw)
		{
			throw new NotImplementedException();
		}

		public override bool GetNext(EDrawingSource drawingSource, RectanglesDrwImpl prev, out RectanglesDrwImpl drw)
		{
			throw new NotImplementedException();
		}

		public unsafe IRectangleDrawingsEx Create(IStdFunctions* _host)
		{
			throw new NotImplementedException();
		}
	}
}
