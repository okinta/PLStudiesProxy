using _ELAPI_;
using _ELAPI_.variables;
using BugSlayerUtil;
using ManagedStudies.details;
using PowerLanguage.Common;
using PowerLanguage.PLDataLoader;
using PowerLanguage.TradeManager;
using PowerLanguage.VolumeProfile;
using std;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	/// <summary>Base class for studies.
	/// </summary>
	public class CStudyControl : IStudyControl, IStudy, IChartCommands, IDisposable
	{
		private volatile bool m_disposed = false;

		private CStudyAbstract m_master;

		private IntPtr m_parent_id;

		private protected StudyID m_tech_id;

		private int m_ds;

		private List<PriceSeries> m_prices;

		private PriceSeries m_current_prices;

		private int m_max_seria_index;

		private IOutput m_output;

		private IStrategyPerformance m_strategy_info;

		private static CSingleton<CSymbolsStorage> m_symbols_storage_host = new CSingleton<CSymbolsStorage>();

		private CSymbolsStorage m_symbols_storage;

		private List<IVariablesControl>[] m_vars_pool;

		private ITextDrawingsEx m_text_drawings;

		private ITrendLineDrawingsEx m_tl_drawings;

		private IArrowDrawingsEx m_arrow_drawings;

		private IRectangleDrawingsEx m_rect_drawings;

		private int m_tm_helperID;

		private PowerLanguage.TradeManager.TradeManager m_tm;

		private CustomToolBar m_chart_tb;

		private volatile int m_calc_thread_id;

		/// <exclude />
		private protected EExecutionPhase m_phase;

		private bool m_verify_licence_twice_call_detected;

		private bool m_verify_license_check_once;

		private string m_verify_name;

		private string m_verify_developer;

		private string m_verify_name_conflict;

		private string m_verify_developer_conflict;

		/// <summary>
		/// Read-only property. Provides an interface for accessing current series' TPO data.
		/// </summary>
		public IInstrumentTPO TPOBars
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// This string is saved to workspace and loaded from workspace.
		/// </summary>
		public string PersistData
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		public IChartCommands ChartCommands
		{
			get
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				return this;
			}
		}

		/// <summary>
		/// Returns interface for accessing volume profile.
		/// </summary>
		public IProfilesCollection VolumeProfile
		{
			get
			{
				//Discarded unreachable code: IL_0048
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					return m_current_prices.VolumeProfile;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "VolumeProfile"));
			}
		}

		/// <summary>
		/// Returns interface for accessing trading functionality.
		/// </summary>
		public ITradeManager TradeManager
		{
			get
			{
				//Discarded unreachable code: IL_0067
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					if (null == m_tm)
					{
						m_tm = PowerLanguage.TradeManager.TradeManager.TMForStudiesInstance(m_tm_helperID = (int)PowerLanguage.TradeManager.TradeManager.GetUniqueID);
					}
					return m_tm;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "TradeManager"));
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for accessing the toolbar for the chart that has the study applied.
		/// Gives access to toolbar <see cref="T:System.Windows.Forms.ToolStrip" />  and lets you set its visibility.
		/// </summary>
		public ICustomToolBar ChartToolBar
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for accessing symbol storage. 
		/// </summary>
		public ISymbolsStorage SymbolStorage
		{
			get
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				return m_symbols_storage;
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for data loading.
		/// </summary>
		public IDataLoader DataLoader
		{
			get
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Read-only property. Allows registering your own custom "drawer" for customizing drawing on chart using GDI+ (<see cref="N:System.Drawing" />).			
		/// </summary>
		public IChartCustomDrawRegistrator ChartCustomDraw
		{
			get
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for controlling expert commentary.
		/// </summary>
		public IExpertCommentary ExpertCommentary
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					throw new NotImplementedException();
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "ExpertCommentary"));
			}
		}

		/// <summary>
		/// Read-only property. Returns environment access interface.
		/// </summary>
		public IApplicationInfo Environment
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					throw new NotImplementedException();
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "Environment"));
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for controlling strategy calculation.
		/// </summary>
		public ICalculationControl ExecControl
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					throw new NotImplementedException();
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "ExecControl"));
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for accessing current execution context.
		/// </summary>
		public ICalculationInfo ExecInfo
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					throw new NotImplementedException();
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "ExecInfo"));
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for accessing strategy information.
		/// </summary>
		public IStrategyPerformance StrategyInfo
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					return m_strategy_info;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "StrategyInfo"));
			}
			protected set
			{
				m_strategy_info = value;
			}
		}

		/// <summary>
		/// Read-only property. Returns a container for IRectangleObject collection.
		/// </summary>
		public IRectangleContainer DrwRectangle
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					return m_rect_drawings;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "DrwRectangle"));
			}
		}

		/// <summary>
		/// Read-only property. Returns a container for collection of specific IArrowObject.
		/// </summary>
		public IArrowContainer DrwArrow
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					return m_arrow_drawings;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "DrwArrow"));
			}
		}

		/// <summary>
		/// Read-only property. Returns a container for ITrendLineObject collection.
		/// </summary>
		public ITrendLineContainer DrwTrendLine
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					return m_tl_drawings;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "DrwTrendLine"));
			}
		}

		/// <summary>
		/// Read-only property. Returns a container for ITextObject collection.
		/// </summary>
		public ITextContainer DrwText
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					return m_text_drawings;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "DrwText"));
			}
		}

		/// <summary>
		/// Read-only property. Returns an interface for working with Alerts. 
		/// </summary>
		public IAlert Alerts
		{
			get
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Returns an interface to access Output Window.
		/// </summary>
		public IOutput Output
		{
			get
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				return m_output;
			}
			protected set
			{
				m_output = value;
			}
		}

		/// <summary>
		/// Read-only property. Returns max data stream.
		/// </summary>
		public int MaxDataStream
		{
			get
			{
				//Discarded unreachable code: IL_0043
				if (m_disposed)
				{
					throw new ObjectDisposedException("");
				}
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					return m_max_seria_index;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "MaxDataStream"));
			}
		}

		/// <summary>
		/// Returns base instrument.
		/// </summary>
		public IInstrument Bars { get; protected set; }

		/// <summary>
		/// Read-only property. Returns name. 
		/// </summary>
		public string Name
		{
			get
			{
				return "";
			}
		}

		/// <exclude />
		protected internal IntPtr parent_host_id => m_parent_id;

		public int StudyDataNumber => throw new NotImplementedException();

		protected void _check_for_disposed()
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException("");
			}
		}

		/// <summary>
		/// Returns instrument for specified data stream number. 
		/// </summary>
		public IInstrument BarsOfData(int data_stream)
		{
			return seria_impl(data_stream);
		}

		/// <summary>
		/// Returns whether there is data at a specified data stream number.
		/// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		public bool IsExist(int data_stream)
		{
			//Discarded unreachable code: IL_0076
			if (m_disposed)
			{
				throw new ObjectDisposedException("");
			}
			EExecutionPhase phase = m_phase;
			if (phase != (EExecutionPhase)1 && phase != 0)
			{
				int num = (0 < data_stream && m_prices.Count >= data_stream) ? 1 : 0;
				if ((byte)num != 0)
				{
					return m_prices[_calc_data_stream_index(data_stream)].IsExist;
				}
				return false;
			}
			throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "IsExist"));
		}

		/// <summary>
		/// Returns interface for accessing volume profile for specified instrument.
		/// </summary>
		public IProfilesCollection VolumeProfileByDataStream(int data_stream)
		{
			//Discarded unreachable code: IL_0054
			if (m_disposed)
			{
				throw new ObjectDisposedException("");
			}
			EExecutionPhase phase = m_phase;
			if (phase != (EExecutionPhase)1 && phase != 0)
			{
				return m_prices[_calc_data_stream_index(data_stream)].VolumeProfile;
			}
			throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "VolumeProfileByDataStream"));
		}

		/// <summary>
		/// Allows study developers to use MultiCharts .NET Special Edition authorization services. 
		/// </summary>
		public void VerifyLicense(string sName, string sDevID)
		{
			EExecutionPhase phase = m_phase;
			if (phase != (EExecutionPhase)1 && phase != 0)
			{
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Construct (Create method) only.", "VerifyLicense"));
			}
			if (m_verify_license_check_once && (sName != m_verify_name || sDevID != m_verify_developer))
			{
				m_verify_licence_twice_call_detected = true;
				m_verify_name_conflict = sName;
				m_verify_developer_conflict = sDevID;
			}
			else
			{
				m_verify_name = sName;
				m_verify_developer = sDevID;
				m_verify_license_check_once = true;
			}
		}

		/// <summary>
		/// Read-only property. Provides an interface for accessing TPO's data series on a particular datastream.
		/// Datastream number is provided in the parameter.
		/// </summary>
		public IInstrumentTPO TPOBarsOfData(int data_stream)
		{
			return seria_impl(data_stream);
		}

		private void verify_impl_check_errors()
		{
		}

		private void ScrollToBar(int dataN, int barN)
		{
		}

		void IChartCommands.ScrollToBar(int dataN, int barN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ScrollToBar
			this.ScrollToBar(dataN, barN);
		}

		private PriceSeries seria_impl(int data_stream)
		{
			throw new NotImplementedException();
		}

		private void CommandLine(string command)
		{
		}

		void IChartCommands.CommandLine(string command)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CommandLine
			this.CommandLine(command);
		}

		private int _calc_data_stream_index(int data_stream)
		{
			int num = (0 < data_stream && m_prices.Count >= data_stream) ? 1 : 0;
			if ((byte)num == 0)
			{
				throw new WrongDataNumberException(data_stream - 1);
			}
			return data_stream - 1;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool _is_valid_data_stream(int data_stream)
		{
			int num = (0 < data_stream && m_prices.Count >= data_stream) ? 1 : 0;
			return (byte)num != 0;
		}

		/// <param name="defaultVal">Simple variable default value.</param>
		/// <param name="dataStream">Simple variable base datastream number.</param>
		/// <summary>
		/// Creates VariableObject object.
		/// </summary>
		protected internal IVar<T> CreateSimpleVar<T>(T defaultVal, int dataStream)
		{
			EExecutionPhase phase = m_phase;
			if (phase != (EExecutionPhase)1 && phase != 0)
			{
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Construct (Create method) only.", "CreateSimpleVar"));
			}
			return new VariableObject<T>(this, defaultVal, dataStream);
		}

		/// <summary>
		/// Creates VariableObject object.
		/// </summary>
		protected internal IVar<T> CreateSimpleVar<T>(T defaultVal)
		{
			return CreateSimpleVar(defaultVal, 0);
		}

		/// <summary>
		/// Creates VariableObject object.
		/// </summary>
		protected internal IVar<T> CreateSimpleVar<T>()
		{
			return CreateSimpleVar(default(T), 0);
		}

		/// <param name="defaultVal">Series variable default value.</param>
		/// <param name="dataStream">Series variable base datastream number.</param>
		/// <summary>
		/// Creates VariableSeries object.
		/// </summary>
		protected internal IVar<T> CreateSeriesVar<T>(T defaultVal, int dataStream)
		{
			EExecutionPhase phase = m_phase;
			if (phase != (EExecutionPhase)1 && phase != 0)
			{
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Construct (Create method) only.", "CreateSeriesVar"));
			}
			return new VariableSeries<T>(this, defaultVal, dataStream);
		}

		protected internal IVar<T> CreateSeriesVar<T>(T defaultVal)
		{
			return CreateSeriesVar(defaultVal, 0);
		}

		protected internal IVar<T> CreateSeriesVar<T>()
		{
			return CreateSeriesVar(default(T), 0);
		}

		Indexator IStudyControl.GetIndexer(int _data_stream)
		{
			throw new NotImplementedException();
		}

		void IStudyControl.AddVariable(IVariablesControl _var, int _data_stream)
		{
			throw new NotImplementedException();
		}

		protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		/// <exclude />
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void AddFunction(IFunctionAbstract func)
		{
			throw new NotImplementedException();
		}
	}
}
