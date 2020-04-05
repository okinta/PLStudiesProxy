using PowerLanguage.TradeManager;
using PowerLanguage.VolumeProfile;
using System.Collections.Generic;
using System;

namespace PowerLanguage
{
	/// <summary>Base class for studies.
	/// </summary>
	public class CStudyControl : IStudyControl, IStudy, IChartCommands
	{
		/// <summary>
		/// Read-only property. Returns name. 
		/// </summary>
		public string Name { get; protected set; }

		protected List<IInstrument> BarsData { get; set; }

		/// <summary>
		/// Read-only property. Returns base instrument. 
		/// </summary>
		public IInstrument Bars
		{
			get
			{
				return BarsData[0];
			}
		}

		/// <summary>
		/// Returns instrument for specified data stream number. 
		/// </summary>
		public IInstrument BarsOfData(int data_stream)
		{
			return BarsData[data_stream];
		}

		/// <summary>
		/// Read-only property. Returns max data stream.
		/// </summary>
		public int MaxDataStream
		{
			get
			{
				return BarsData.Count - 1;
			}
		}

		/// <summary>
		/// Returns whether there is data at a specified data stream number.
		/// </summary>
		public bool IsExist(int data_stream)
		{
			return data_stream < BarsData.Count;
		}

		/// <summary>
		/// Read-only property. Returns an interface to access Output Window.
		/// </summary>
		public IOutput Output { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for working with Alerts. 
		/// </summary>
		public IAlert Alerts { get; protected set; }

		/// <summary>
		/// Read-only property. Returns a container for ITextObject collection.
		/// </summary>
		public ITextContainer DrwText { get; protected set; }

		/// <summary>
		/// Read-only property. Returns a container for ITrendLineObject collection.
		/// </summary>
		public ITrendLineContainer DrwTrendLine { get; protected set; }

		/// <summary>
		/// Read-only property. Returns a container for collection of specific IArrowObject.
		/// </summary>
		public IArrowContainer DrwArrow { get; protected set; }

		/// <summary>
		/// Read-only property. Returns a container for IRectangleObject collection.
		/// </summary>
		public IRectangleContainer DrwRectangle { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for accessing strategy information.
		/// </summary>
		public IStrategyPerformance StrategyInfo { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for accessing current execution context.
		/// </summary>
		public ICalculationInfo ExecInfo { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for controlling strategy calculation.
		/// </summary>
		public ICalculationControl ExecControl { get; protected set; }

		/// <summary>
		/// Read-only property. Returns environment access interface.
		/// </summary>
		public IApplicationInfo Environment { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for controlling expert commentary.
		/// </summary>
		public IExpertCommentary ExpertCommentary { get; protected set; }

		/// <summary>
		/// Read-only property. Allows registering your own custom "drawer" for customizing drawing on chart using GDI+ (<see cref="N:System.Drawing" />).			
		/// </summary>
		public IChartCustomDrawRegistrator ChartCustomDraw { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for data loading.
		/// </summary>
		public IDataLoader DataLoader { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for accessing symbol storage. 
		/// </summary>
		public ISymbolsStorage SymbolStorage { get; protected set; }

		/// <summary>
		/// Read-only property. Returns an interface for accessing the toolbar for the chart that has the study applied.
		/// Gives access to toolbar <see cref="T:System.Windows.Forms.ToolStrip" />  and lets you set its visibility.
		/// </summary>
		public ICustomToolBar ChartToolBar { get; protected set; }

		/// <summary>
		/// Returns interface for accessing trading functionality.
		/// </summary>
		public ITradeManager TradeManager { get; protected set; }

		/// <summary>
		/// Returns interface for accessing volume profile.
		/// </summary>
		public IProfilesCollection VolumeProfile { get; protected set; }

		public IChartCommands ChartCommands { get; protected set; }

		/// <summary>
		/// This string is saved to workspace and loaded from workspace.
		/// </summary>
		public string PersistData { get; set; }

		/// <summary>
		/// Returns interface for accessing volume profile for specified instrument.
		/// </summary>
		public IProfilesCollection VolumeProfileByDataStream(int data_stream)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Allows study developers to use MultiCharts .NET Special Edition authorization services. 
		/// </summary>
		public void VerifyLicense(string sName, string sDevID)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Read-only property. Provides an interface for accessing current series' TPO data.
		/// </summary>
		public IInstrumentTPO TPOBars { get; protected set; }

		public int StudyDataNumber => throw new NotImplementedException();

		/// <summary>
		/// Read-only property. Provides an interface for accessing TPO's data series on a particular datastream.
		/// Datastream number is provided in the parameter.
		/// </summary>
		public IInstrumentTPO TPOBarsOfData(int data_stream)
		{
			throw new NotImplementedException();
		}

		public void ScrollToBar(int dataN, int barN)
		{
			throw new NotImplementedException();
		}

		public void CommandLine(string command)
		{
			throw new NotImplementedException();
		}

		public Indexator GetIndexer(int dataStream)
		{
			throw new NotImplementedException();
		}

		public void AddVariable(IVariablesControl var, int dataStream)
		{
			throw new NotImplementedException();
		}

		public void AddFunction(IFunctionAbstract func)
		{
			throw new NotImplementedException();
		}
	}
}
