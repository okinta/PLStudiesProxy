#define TRACE
using _ELAPI_;
using _ELAPI_.variables;
using ManagedStudies.details;
using PowerLanguage.Common;
using std;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PowerLanguage
{
	/// <summary>Base class for studies.
	/// </summary>
	public abstract class CStudyAbstract : CStudyControl, ITechniqueEEService
	{
		private readonly TechCreateContext m_create_ctx;

		private unsafe void* m_host;

		private unsafe DepIndicatorsHolder* m_deps_holder;

		private List<object> m_deps;

		/// <exclude />
		protected internal int ui_thread_id => m_create_ctx.ui_thread_id;

		/// <exclude />
		protected internal unsafe IntPtr host_id => new IntPtr(m_host);

		/// <exclude />
		protected unsafe sealed override int StudyDataNumber
		{
			get
			{
				return 0;
			}
		}

		/// <exclude />
		protected unsafe CStudyAbstract(object _ctx) : base(null, 0)
		{
		}

		private void _007ECStudyAbstract()
		{
		}

		protected object AddIndicator(Type type_of_indicator, int data_stream)
		{
			return AddIndicator(type_of_indicator.Name, data_stream);
		}

		protected object AddIndicator(Type type_of_indicator)
		{
			string name = type_of_indicator.Name;
			return AddIndicator(name, -1);
		}

		protected unsafe object AddIndicator(string name, int data_stream)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// This method allows to add any indicator and use it later. 
		/// The indicator will be calculated every time before this study calculation.
		/// The goal is to use the indicator's algorithm in signals or other indicators.
		/// </summary>
		protected object AddIndicator(string name)
		{
			return AddIndicator(name, -1);
		}

		/// <summary>Method which is called once when the study object is created. Here, and only here, access the following:
		/// <para>1) add plot objects (for indicator objects only) <seealso cref="!:PowerLanguage::Indicator::IndicatorObject" />, </para><para>2) create order objects <see cref="T:PowerLanguage.OrderCreator" /> (for signal objects only) <seealso cref="!:PowerLanguage::Strategy::SignalObject" />, </para><para>3) create function objects, </para><para>4) add variable objects <see cref="M:PowerLanguage.CStudyControl.CreateSimpleVar``1" /><see cref="M:PowerLanguage.CStudyControl.CreateSeriesVar``1" /></para></summary>
		/// <example>Create method in the MomentumLE signal.
		/// <code>
		/// private PowerLanguage.Function.Momentum m_momentum1;
		/// private PowerLanguage.Function.Momentum m_momentum2;
		/// private VariableSeries&lt;double&gt; m_mom;
		/// private IOrderPriced m_Order0;
		///
		/// protected override void Create() {
		/// 	m_momentum1 = new PowerLanguage.Function.Momentum(this);
		/// 	m_momentum2 = new PowerLanguage.Function.Momentum(this);
		/// 	m_mom = new VariableSeries&lt;double&gt;(this);
		/// 	m_Order0 = OrderCreator.Stop(new SOrderParameters(Contracts.Default, "MomLE", EOrderAction.Buy));
		/// }
		/// </code></example>
		protected virtual void Create()
		{
		}

		/// <summary>Method which is called once at the start of the calculation process.
		/// <para>Here you can initialize study variables.</para></summary>
		/// <example>StartCalc method in the MomentumLE signal.
		/// <code>
		/// private PowerLanguage.Function.Momentum m_momentum1;
		/// private PowerLanguage.Function.Momentum m_momentum2;
		/// private VariableSeries&lt;double&gt; m_mom;
		/// private IOrderPriced m_Order0;
		///
		/// private ISeries&lt;double&gt; m_price;
		///
		/// private ISeries&lt;double&gt; price {
		/// 	get { return m_price; }
		/// }
		///
		/// private int m_length = 12;
		///
		/// [Input]
		/// public int length {
		/// 	get { return m_length; }
		/// 	set { m_length = value; }
		/// }
		///
		/// protected override void StartCalc() {
		/// 	m_price = Bars.Close;
		/// 	m_momentum1.price = price;
		/// 	m_momentum1.length = new Lambda&lt;int&gt;(delegate { return length; });
		/// 	m_momentum2.price = m_mom;
		/// 	m_momentum2.length = new ConstantObject&lt;int&gt;(1);
		/// 	m_mom.DefaultValue = 0;
		/// }
		/// </code></example>
		protected virtual void StartCalc()
		{
		}

		/// <summary>
		/// Method which is called once at the end of the calculation process when technique was switched off or removed.
		/// IMPORTANT! This method may be called in main thread (UI) or in working thread (calculation).
		/// </summary>
		protected virtual void StopCalc()
		{
		}

		/// <summary>This method is called every tick from the calculation's beginning bar until the last historical bar.
		/// <para>Every real-time tick (or bar close, optionally) after the historical calculation.</para></summary>
		/// <example>CalcBar method in the MomentumLE signal.
		/// <code>
		/// private PowerLanguage.Function.Momentum m_momentum1;
		/// private PowerLanguage.Function.Momentum m_momentum2;
		/// private IOrderPriced m_Order0;
		///
		/// protected override void CalcBar() {
		/// 	const double momentum1 = m_momentum1[0];
		/// 	const double momentum2 = m_momentum2[0];
		/// 	if ( momentum1 &gt; 0 &amp;&amp; momentum2 &gt; 0 ) {
		/// 		m_Order0.Send(Bars.High[0] + Bars.Point);
		/// 	}
		/// }
		/// </code></example>
		protected abstract void CalcBar();

		/// <param name="arg">Specifies the mouse-click parameters. Keyboard button code, mouse button code, chart point, bar number and data stream number parameters are passed.</param>
		/// <summary>Allows control of mouse-click events on the chart.
		/// </summary>
		/// <example> This example shows how to recalculate script on Shift + MouseLeftButton pressed event.
		/// <code>
		/// protected override void CalcBar() {
		/// 	if (Bars.CurrentBar &gt;= start_calc_bar_number) {
		/// 		// execute script from the specified bar
		/// 	}
		/// }
		///
		/// private static int start_calc_bar_number = 1;
		///
		/// protected override void OnMouseEvent(MouseClickArgs args) {
		/// 	if (Keys.ShiftKey == args.keys &amp;&amp; MouseButtons.Left == args.buttons) {
		/// 		start_calc_bar_number = args.bar_number;
		/// 		ExecControl.Recalculate();
		/// 	}
		/// }
		/// </code></example>
		protected virtual void OnMouseEvent(MouseClickArgs arg)
		{
			CalcBar();
		}

		/// <summary>Event that occurs after strategy Order has been Filled at broker. 
		/// This method can be used only for automated trading, not for manual trading.
		/// </summary>
		protected virtual void OnBrokerStategyOrderFilled([MarshalAs(UnmanagedType.U1)] bool is_buy, int quantity, double avg_fill_price)
		{
			CalcBar();
		}

		/// <summary>Event that occurs after MarketPosition and/or average Entry Price changed at broker. 
		/// </summary>
		protected virtual void OnBrokerPositionChange()
		{
			CalcBar();
		}

		/// <summary>Event that happens after timeout in RecalcLastBarAfter function occurs.
		/// </summary>
		protected virtual void OnRecalcLastBarAfterEvent()
		{
			CalcBar();
		}

		/// <summary>This method is called once when the study is removed from the chart(scanner).
		/// </summary>
		protected virtual void Destroy()
		{
		}

		/// <summary>Event that occurs after strategy Order has been Rejected at broker. 
		/// This method can be used only for automated trading, not for manual trading.
		/// </summary>
		protected virtual void OnOrderRejected(EOrderAction RejectedOrderAction, OrderCategory RejectedOrderCategory, int RejectedOrderQuantity, double RejectedOrderStopPrice, double RejectedOrderLimitPrice)
		{
			CalcBar();
		}

		/// <exclude />
		protected virtual void BeforeConstructImpl()
		{
			m_phase = (EExecutionPhase)1;
		}

		/// <exclude />
		protected virtual void AfterConstructImpl()
		{
		}

		/// <exclude />
		protected virtual void BeforeInitializeImpl()
		{
			m_phase = (EExecutionPhase)2;
		}

		/// <exclude />
		protected virtual void AfterInitializeImpl()
		{
			m_phase = (EExecutionPhase)3;
		}

		/// <exclude />
		protected virtual void PreExecuteImpl()
		{
			_PreExecuteImpl();
		}

		/// <exclude />
		protected virtual void DestroyImpl()
		{
		}

		private unsafe void DoExecute()
		{
		}

		void ITechniqueEEService.DoExecute()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoExecute
			this.DoExecute();
		}

		private void DoConstruct()
		{
			BeforeConstructImpl();
			Create();
			_CallConstruct();
			AfterConstructImpl();
		}

		void ITechniqueEEService.DoConstruct()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoConstruct
			this.DoConstruct();
		}

		private void DoInitialize()
		{
			_Initialize();
			BeforeInitializeImpl();
			StartCalc();
			_Call_Initialize();
			_BeforeCalc_DependentIndicators();
			AfterInitializeImpl();
		}

		void ITechniqueEEService.DoInitialize()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoInitialize
			this.DoInitialize();
		}

		private void DoBeforeCalcInit()
		{
			StartCalc();
			_Call_BeforeCalc();
		}

		void ITechniqueEEService.DoBeforeCalcInit()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoBeforeCalcInit
			this.DoBeforeCalcInit();
		}

		private unsafe void DoDestroy()
		{
		}

		void ITechniqueEEService.DoDestroy()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoDestroy
			this.DoDestroy();
		}

		private void DoCloseBar(int _ds)
		{
			_CloseBar(_ds);
		}

		void ITechniqueEEService.DoCloseBar(int _ds)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoCloseBar
			this.DoCloseBar(_ds);
		}

		private void DoRecovery(int _ds)
		{
			_Recovery(_ds);
		}

		void ITechniqueEEService.DoRecovery(int _ds)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoRecovery
			this.DoRecovery(_ds);
		}

		private void DoFinishCalc()
		{
			try
			{
				StopCalc();
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
			}
			_Call_UnInitialize();
		}

		void ITechniqueEEService.DoFinishCalc()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoFinishCalc
			this.DoFinishCalc();
		}

		private unsafe void DoInitializeVars(IInitIndexes* _indexes)
		{
			_Initialize(_indexes);
		}

		unsafe void ITechniqueEEService.DoInitializeVars(IInitIndexes* _indexes)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DoInitializeVars
			this.DoInitializeVars(_indexes);
		}

		private void _BeforeCalc_DependentIndicators()
		{
			List<object>.Enumerator enumerator = m_deps.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return;
			}
			do
			{
				CStudyAbstract cStudyAbstract = (CStudyAbstract)enumerator.Current;
				if (cStudyAbstract != null)
				{
					cStudyAbstract.DoFinishCalc();
					cStudyAbstract.DoBeforeCalcInit();
				}
			}
			while (enumerator.MoveNext());
		}

		/// <exclude />
		protected unsafe void* host_void_ptr()
		{
			return m_host;
		}

		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
			if (P_0)
			{
				try
				{
					_007ECStudyAbstract();
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
