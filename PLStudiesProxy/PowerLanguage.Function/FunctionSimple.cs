using System;
using System.Runtime.InteropServices;

namespace PowerLanguage.Function
{
	/// <summary>
	/// Simple function’s base class. 
	/// Its peculiarity is that it doesn’t keep the history of its values, 
	/// but rather calculates them each time in the context of calling an execution 
	/// (on the bar, shifted relative to the current one for a specified number of bars).
	/// </summary>
	public abstract class FunctionSimple<T> : FunctionObject<T>
	{
		/// <summary>Returns the function calculation result at the specified bar.
		/// </summary>
		/// <param name="barsAgo">Function calling context.</param>
		public sealed override T this[int barsAgo]
		{
			get
			{
				if (m_calculated)
				{
					DoRecoveryVars(my_ds());
				}
				return _calculate(barsAgo);
			}
		}

		/// <summary>Initializes a new instance of the FunctionSimple class. 
		/// </summary>
		/// <param name="master">Study object which manages this FunctionSimple object.</param>
		public FunctionSimple(CStudyControl master)
			: base(master, _is_series: true, 0)
		{
		}

		/// <summary>Initializes a new instance of the FunctionSimple class. 
		/// </summary>
		/// <param name="master">Study object which manages this FunctionSimple object.</param>
		/// <param name="dataStream">This object base data stream number.</param>
		public FunctionSimple(CStudyControl master, int dataStream)
			: base(master, _is_series: true, dataStream)
		{
		}

		private void _007EFunctionSimple_00601()
		{
		}

		private unsafe T _calculate(int bars_ago)
		{
			throw new NotImplementedException();
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
