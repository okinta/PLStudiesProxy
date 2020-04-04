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

		private unsafe uint** m_cur_ds;

		private unsafe bool* m_is_history;

		private IndexerImpl[] m_indexes;

		private List<PriceSeries> m_prices;

		private PriceSeries m_current_prices;

		private int m_max_seria_index;

		private IOutput m_output;

		private CAlerts m_alerts;

		private CStrategyInfo m_strategy_info;

		private CExecutionInfo m_exec_info;

		private CExecutionControl m_exec_control;

		private CEnvironment m_environment;

		private CExpertCommentary m_expert_commentary;

		private static CSingleton<CSymbolsStorage> m_symbols_storage_host = new CSingleton<CSymbolsStorage>();

		private CSymbolsStorage m_symbols_storage;

		private DataLoaderProxy m_data_loader;

		private CChartCustomDrawBaseStudy m_chart_cust_draw;

		private List<IVariablesControl>[] m_vars_pool;

		private readonly List<IFunctionManageEx> m_functions;

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

		private protected unsafe uint* m_calc_reason;

		private bool m_verify_licence_twice_call_detected;

		private bool m_verify_license_check_once;

		private string m_verify_name;

		private string m_verify_developer;

		private string m_verify_name_conflict;

		private string m_verify_developer_conflict;

		/// <exclude />
		protected virtual int StudyDataNumber => my_ds();

		/// <summary>
		/// Read-only property. Provides an interface for accessing current series' TPO data.
		/// </summary>
		public unsafe IInstrumentTPO TPOBars
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// This string is saved to workspace and loaded from workspace.
		/// </summary>
		public unsafe string PersistData
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
		public unsafe ICustomToolBar ChartToolBar
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
				return m_data_loader;
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
				return m_chart_cust_draw;
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
					return m_expert_commentary;
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
					return m_environment;
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
					return m_exec_control;
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
					return m_exec_info;
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
				return m_alerts;
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
		public unsafe string Name
		{
			get
			{
				return "";
			}
		}

		/// <exclude />
		protected internal IntPtr parent_host_id => m_parent_id;

		/// <exclude />
		protected internal CStudyAbstract Host => m_master;

		int IStudyControl.StudyDataNumber => throw new NotImplementedException();

		private protected unsafe CStudyControl(CStudyAbstract master, int dataStream)
		{
		}

		private void _007ECStudyControl()
		{
		}

		private protected void _CallConstruct()
		{
			List<IFunctionManageEx>.Enumerator enumerator = m_functions.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.DoConstruct();
				}
				while (enumerator.MoveNext());
			}
		}

		private protected void _CallDestroy()
		{
			int num = m_functions.Count - 1;
			if (num >= 0)
			{
				do
				{
					m_functions[num].DoDestroy();
					num += -1;
				}
				while (num >= 0);
			}
			_reset_prices();
			m_current_prices?.Dispose();
			((IDisposable)m_tm)?.Dispose();
			PowerLanguage.TradeManager.TradeManager.StudyUnsubscribeTM(m_tm_helperID);
			((IDisposable)m_chart_cust_draw)?.Dispose();
			m_rect_drawings?.Dispose();
			m_arrow_drawings?.Dispose();
			m_tl_drawings?.Dispose();
			m_text_drawings?.Dispose();
			CustomToolBar chart_tb = m_chart_tb;
			if (null != chart_tb)
			{
				CustomToolBarsPoolSingle.Instance.Free(chart_tb);
			}
			m_chart_tb = null;
			DataLoaderProxy data_loader = m_data_loader;
			if (null != data_loader)
			{
				data_loader.Free();
			}
		}

		private protected unsafe void _PreExecuteImpl()
		{
			if (*m_is_history && *m_calc_reason - 3 > 3)
			{
				return;
			}
			m_current_prices.OnBeforeRTCalc();
			List<PriceSeries>.Enumerator enumerator = m_prices.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.OnBeforeRTCalc();
				}
				while (enumerator.MoveNext());
			}
		}

		private protected void _Set_ExecState(EExecutionPhase _phase)
		{
			m_phase = _phase;
		}

		private protected unsafe void _Initialize(IInitIndexes* _indexes)
		{
		}

		private protected unsafe void _Initialize()
		{
		}

		private protected void _Call_Initialize()
		{
			verify_impl_check_errors();
			List<IFunctionManageEx>.Enumerator enumerator = m_functions.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.DoInitialize();
				}
				while (enumerator.MoveNext());
			}
		}

		private protected void _Call_BeforeCalc()
		{
			List<IFunctionManageEx>.Enumerator enumerator = m_functions.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.DoBeforeCalcInit();
				}
				while (enumerator.MoveNext());
			}
		}

		private protected void _Call_UnInitialize()
		{
			List<IFunctionManageEx>.Enumerator enumerator = m_functions.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.DoUnInitialize();
				}
				while (enumerator.MoveNext());
			}
		}

		private protected unsafe void _CloseBar(int _ds)
		{
			if ((IntPtr)0 == (IntPtr)(void*)m_vars_pool.LongLength)
			{
				return;
			}
			int num = _ds + 1;
			vars_close_bar(num);
			int ds = m_ds;
			uint num2;
			if (0 == ds)
			{
				uint** cur_ds = m_cur_ds;
				if (0 != *(long*)cur_ds)
				{
					num2 = (uint)(*(int*)(*(long*)cur_ds) + 1);
					goto IL_0037;
				}
			}
			num2 = (uint)ds;
			goto IL_0037;
			IL_0037:
			if (num2 == (uint)num)
			{
				vars_close_bar(0);
			}
		}

		private protected unsafe void vars_close_bar(int _ds)
		{
			List<IVariablesControl>[] vars_pool = m_vars_pool;
			if ((long)(IntPtr)(void*)vars_pool.LongLength <= (long)_ds)
			{
				return;
			}
			List<IVariablesControl> list = vars_pool[_ds];
			if (null == list)
			{
				return;
			}
			List<IVariablesControl>.Enumerator enumerator = list.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.CloseBar();
				}
				while (enumerator.MoveNext());
			}
		}

		private protected unsafe void _Recovery(int _ds)
		{
			if ((IntPtr)0 == (IntPtr)(void*)m_vars_pool.LongLength)
			{
				return;
			}
			int num = _ds + 1;
			vars_recovery(num);
			int ds = m_ds;
			uint num2;
			if (0 == ds)
			{
				uint** cur_ds = m_cur_ds;
				if (0 != *(long*)cur_ds)
				{
					num2 = (uint)(*(int*)(*(long*)cur_ds) + 1);
					goto IL_0037;
				}
			}
			num2 = (uint)ds;
			goto IL_0037;
			IL_0037:
			if (num2 == (uint)num)
			{
				vars_recovery(0);
			}
		}

		private protected unsafe void vars_recovery(int _ds)
		{
			List<IVariablesControl>[] vars_pool = m_vars_pool;
			if ((long)(IntPtr)(void*)vars_pool.LongLength <= (long)_ds)
			{
				return;
			}
			List<IVariablesControl> list = vars_pool[_ds];
			if (null == list)
			{
				return;
			}
			List<IVariablesControl>.Enumerator enumerator = list.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.Recovery();
				}
				while (enumerator.MoveNext());
			}
		}

		private protected void _set_parent_host_id(IntPtr _parent_id)
		{
			m_parent_id = _parent_id;
		}

		private protected void _set_tech_id(StudyID _tech_id)
		{
			m_tech_id = _tech_id;
		}

		internal unsafe int my_ds()
		{
			int ds = m_ds;
			if (0 == ds)
			{
				uint** cur_ds = m_cur_ds;
				if (0 != *(long*)cur_ds)
				{
					return *(int*)(*(long*)cur_ds) + 1;
				}
			}
			return ds;
		}

		private void _reset_prices()
		{
			List<PriceSeries>.Enumerator enumerator = m_prices.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current?.Dispose();
				}
				while (enumerator.MoveNext());
			}
			m_prices.Clear();
		}

		private unsafe List<IVariablesControl> access_vars(int _ds)
		{
			List<IVariablesControl>[] vars_pool = m_vars_pool;
			List<IVariablesControl> list;
			if ((long)(IntPtr)(void*)vars_pool.LongLength > (long)_ds)
			{
				list = vars_pool[_ds];
				if (null != list)
				{
					return list;
				}
			}
			else
			{
				Array.Resize(ref m_vars_pool, _ds + 1);
			}
			list = new List<IVariablesControl>();
			m_vars_pool[_ds] = list;
			return list;
		}

		protected void _check_for_disposed()
		{
			if (m_disposed)
			{
				throw new ObjectDisposedException("");
			}
		}

		/// <exclude />
		private protected unsafe IBaseStudy* host()
		{
			throw new NotImplementedException();
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

		private unsafe void verify_impl_check_errors()
		{
		}

		private unsafe void ScrollToBar(int dataN, int barN)
		{
		}

		void IChartCommands.ScrollToBar(int dataN, int barN)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ScrollToBar
			this.ScrollToBar(dataN, barN);
		}

		private unsafe PriceSeries seria_impl(int data_stream)
		{
			throw new NotImplementedException();
		}

		private unsafe void CommandLine(string command)
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

		private unsafe Indexator GetIndexer(int _data_stream)
		{
			uint num;
			if (0 == _data_stream)
			{
				int ds = m_ds;
				if (0 == ds)
				{
					uint** cur_ds = m_cur_ds;
					if (0 != *(long*)cur_ds)
					{
						num = (uint)(*(int*)(*(long*)cur_ds) + 1);
						goto IL_0026;
					}
				}
				num = (uint)ds;
				goto IL_0026;
			}
			return m_indexes[_data_stream];
			IL_0026:
			return m_indexes[num];
		}

		Indexator IStudyControl.GetIndexer(int _data_stream)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetIndexer
			return this.GetIndexer(_data_stream);
		}

		private void AddVariable(IVariablesControl _var, int _data_stream)
		{
			EExecutionPhase phase = m_phase;
			if (phase != (EExecutionPhase)1 && phase != 0)
			{
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Construct (Create method) only.", "AddVariable"));
			}
			access_vars(_data_stream).Add(_var);
		}

		void IStudyControl.AddVariable(IVariablesControl _var, int _data_stream)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AddVariable
			this.AddVariable(_var, _data_stream);
		}

		private void AddFunction(IFunctionAbstract _func)
		{
			EExecutionPhase phase = m_phase;
			if (phase != (EExecutionPhase)1 && phase != 0)
			{
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Construct (Create method) only.", "AddFunction"));
			}
			m_functions.Add(_func as IFunctionManageEx);
		}

		void IStudyControl.AddFunction(IFunctionAbstract _func)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AddFunction
			this.AddFunction(_func);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		internal unsafe bool IsRTCalcReason()
		{
			return (*m_calc_reason - 3 <= 3) ? true : false;
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
	}
}
