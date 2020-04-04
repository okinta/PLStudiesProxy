using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class CTextDrawings : TextCreator<TextDrwImpl>, ITextDrawingsEx, DrawingsContainer<TextDrwImpl>.IDrawingCreator
	{
		private unsafe IStdFunctions* m_host;

		public unsafe IStdFunctions* Impl => m_host;

		public unsafe sealed override ITextObject Active
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public unsafe CTextDrawings(IStdFunctions* _host)
		{
		}

		private void _007ECTextDrawings()
		{
		}

		public void Initialize()
		{
			clear_cache();
		}

		public TextDrwImpl Create(int _id)
		{
			return new TextDrwImpl(_id, this);
		}

		private unsafe ITextObject Create(ChartPoint _point, string _text, int _data_stream, [MarshalAs(UnmanagedType.U1)] bool _on_same_subchart)
		{
			throw new NotImplementedException();
		}

		public sealed override ITextObject Create(ChartPoint _point, string _text, [MarshalAs(UnmanagedType.U1)] bool _on_same_subchart)
		{
			return Create(_point, _text, 0, _on_same_subchart);
		}

		public sealed override ITextObject Create(ChartPoint _point, string _text, int _data_stream)
		{
			return Create(_point, _text, _data_stream, _on_same_subchart: false);
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

		public override bool GetFirst(EDrawingSource drawingSource, out TextDrwImpl drw)
		{
			throw new NotImplementedException();
		}

		public override bool GetNext(EDrawingSource drawingSource, TextDrwImpl prev, out TextDrwImpl drw)
		{
			throw new NotImplementedException();
		}

		public unsafe ITextDrawingsEx Create(IStdFunctions* _host)
		{
			throw new NotImplementedException();
		}
	}
}
