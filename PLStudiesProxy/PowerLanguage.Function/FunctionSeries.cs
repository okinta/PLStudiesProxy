using System.Runtime.InteropServices;

namespace PowerLanguage.Function
{
	/// <summary>
	/// A series function’s  base class. 
	/// Feature of a series function is that its body is always calculated 
	/// in the current context of execution (at the currently calculating bar), 
	/// and the function always keeps its previous values.
	/// </summary>
	public abstract class FunctionSeries<T> : FunctionObject<T>
	{
		private VariableSeries<T> m_var = null;

		private bool m_calculating;

		/// <summary>Returns the function calculation result at the specified bar.
		/// </summary>
		/// <param name="barsAgo">The bar shift value from the current bar of calculation.</param>
		public sealed override T this[int barsAgo]
		{
			get
			{
				if (!m_calculating)
				{
					bool recover_first = false;
					if (m_calculated)
					{
						m_calculated = false;
						recover_first = true;
					}
					_calculate(recover_first);
				}
				return m_var[barsAgo];
			}
		}

		/// <summary>Initializes a new instance of the FunctionSeries class.
		/// </summary>
		/// <param name="master">Study object which manages this FunctionSimple object.</param>
		public FunctionSeries(CStudyControl master)
			: base(master, _is_series: true, 0)
		{
		}

		/// <summary>Initializes a new instance of the FunctionSeries class. 
		/// </summary>
		/// <param name="master">Study object which manages this FunctionSimple object.</param>
		/// <param name="dataStream">This object base data stream number.</param>
		public FunctionSeries(CStudyControl master, int dataStream)
			: base(master, _is_series: true, dataStream)
		{
		}

		private void _007EFunctionSeries_00601()
		{
		}

		private unsafe void _calculate([MarshalAs(UnmanagedType.U1)] bool _recover_first)
		{
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
			if (P_0)
			{
				try
				{
				}
				finally
				{
					base.Dispose(true);
				}
			}
			else
			{
				base.Dispose(false);
			}
		}
	}
}
