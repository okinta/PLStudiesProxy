using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class PlotImpl : IPlotObject, IPlotObjectStr
	{
		private abstract class PlotSeriesBase<T> : IPlotAttributesArray<T>
		{
			protected unsafe IPlot* m_plot;

			protected ulong m_idx;

			public virtual T Value => this[0];

			public abstract T this[int P_0]
			{
				get;
				set;
			}

			protected unsafe PlotSeriesBase(IPlot* _plot, ulong _idx)
			{
			}
		}

		private sealed class PlotSeriesValues : PlotSeriesBase<double>
		{
			public unsafe sealed override double this[int bars_ago]
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public unsafe PlotSeriesValues(IPlot* _plot, ulong _idx)
				: base(_plot, _idx)
			{
			}
		}

		private sealed class PlotSeriesWidths : PlotSeriesBase<int>
		{
			public unsafe sealed override int this[int bars_ago]
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public unsafe PlotSeriesWidths(IPlot* _plot, ulong _idx)
				: base(_plot, _idx)
			{
			}
		}

		private sealed class PlotSeriesColors : PlotSeriesBase<Color>
		{
			public unsafe sealed override Color this[int bars_ago]
			{
				get
				{
					return Color.Empty;
				}
				set
				{
				}
			}

			public unsafe PlotSeriesColors(IPlot* _plot, ulong _idx)
				: base(_plot, _idx)
			{
			}
		}

		private unsafe void* m_host;

		private unsafe IPlot* m_plot;

		private ulong m_idx;

		private string m_plot_name;

		private IPlotAttributesArray<double> m_plot_values;

		private IPlotAttributesArray<Color> m_plot_colors;

		private IPlotAttributesArray<int> m_plot_widths;

		public unsafe Color BGColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		IPlotAttributesArray<double> IPlotObject.Values => throw new NotImplementedException();

		IPlotAttributesArray<Color> IPlotObject.Colors => throw new NotImplementedException();

		IPlotAttributesArray<int> IPlotObject.Widths => throw new NotImplementedException();

		string IPlotObjectBase<double>.Name => throw new NotImplementedException();

		string IPlotObjectBase<string>.Name => throw new NotImplementedException();

		public string Name;

		public IPlotAttributesArray<int> Widths;

		public IPlotAttributesArray<Color> Colors;

		public IPlotAttributesArray<double> Values;

		public unsafe PlotImpl(ulong _idx, void* _host, string _name)
		{
		}

		public unsafe void Set(int bars_ago, double val, Color color, int width)
		{
		}

		public unsafe void Set(string val, Color color)
		{
		}

		public void Set(string val, KnownColor color)
		{
			Color color2 = Color.FromKnownColor(color);
			Set(val, color2);
		}

		public void Set(string val)
		{
			Set(val, Color.Empty);
		}

		public void Set(int bars_ago, double val, KnownColor color, int width)
		{
			Color color2 = Color.FromKnownColor(color);
			Set(bars_ago, val, color2, width);
		}

		public void Set(int bars_ago, double val, KnownColor color)
		{
			Set(bars_ago, val, color, -1);
		}

		public void Set(int bars_ago, double val, Color color)
		{
			Set(bars_ago, val, color, -1);
		}

		public void Set(int bars_ago, double val)
		{
			Set(bars_ago, val, Color.Empty);
		}

		public void Set(double val, KnownColor color, int width)
		{
			Set(0, val, color, width);
		}

		public void Set(double val, Color color, int width)
		{
			Set(0, val, color, width);
		}

		public void Set(double val, KnownColor color)
		{
			Set(0, val, color);
		}

		public void Set(double val, Color color)
		{
			Set(0, val, color);
		}

		public void Set(double val)
		{
			Set(0, val);
		}

		public unsafe void Reset(int bars_ago)
		{
		}

		public unsafe void Reset()
		{
		}

		private unsafe IBaseStudy* host()
		{
			return (IBaseStudy*)m_host;
		}
	}
}
