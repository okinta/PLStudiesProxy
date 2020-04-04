using _ELAPI_;
using ManagedStudies.details;
using std;
using STLLight;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage.Indicator
{
	/// <summary>
	/// Indicator’s base class (inherit from this class to create an indicator).
	/// </summary>
	public abstract class IndicatorObject : CStudyAbstract
	{
		/// <exclude />
		private List<IPlotObject> m_plots = new List<IPlotObject>();

		/// <summary>
		/// Read-only property. 
		/// Returns indicator’s existing plots list.
		/// </summary>
		/// <returns> Plots Collection </returns>
		public IList<IPlotObject> Plots
		{
			get
			{
				_check_for_disposed();
				return m_plots;
			}
		}

		/// <summary>
		/// Initializes a new instance of the IndicatorObject class.
		/// </summary>
		protected IndicatorObject(object _ctx)
			: base(_ctx)
		{
		}

		private void _007EIndicatorObject()
		{
		}

		/// <exclude />
		protected sealed override void BeforeConstructImpl()
		{
			base.BeforeConstructImpl();
		}

		/// <exclude />
		protected sealed override void AfterConstructImpl()
		{
		}

		/// <exclude />
		protected sealed override void BeforeInitializeImpl()
		{
			base.BeforeInitializeImpl();
		}

		/// <exclude />
		protected sealed override void AfterInitializeImpl()
		{
			base.AfterInitializeImpl();
		}

		/// <exclude />
		protected sealed override void DestroyImpl()
		{
		}

		/// <summary>A method for a string plot adding with 'info' parameters.
		/// <seealso cref="T:PowerLanguage.StringPlotAttributes" /></summary>
		/// <param name="info">Specifies attributes for the new plot object.</param>
		protected unsafe IPlotObjectStr AddPlot(StringPlotAttributes info)
		{
			throw new NotImplementedException();
		}

		/// <summary>A method for a plot adding with 'info' parameters.
		/// <seealso cref="T:PowerLanguage.PlotAttributes" /></summary>
		/// <param name="info">Specifies attributes for the new plot object.</param>
		protected unsafe IPlotObject AddPlot(PlotAttributes info)
		{
			throw new NotImplementedException();
		}

		/// <summary>A method for a plot adding.
		/// </summary>
		protected IPlotObject AddPlot()
		{
			PlotAttributes info = new PlotAttributes(m_plots.Count + 1);
			return AddPlot(info);
		}

		private unsafe static SPlotDeclareInfo* PlotInfo2DeclarePlotInfo(SPlotDeclareInfo* P_0, ref StringPlotAttributes info)
		{
			throw new NotImplementedException();
		}

		private unsafe static SPlotDeclareInfo* PlotInfo2DeclarePlotInfo(SPlotDeclareInfo* P_0, ref PlotAttributes info)
		{
			throw new NotImplementedException();
		}

		[HandleProcessCorruptedStateExceptions]
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
