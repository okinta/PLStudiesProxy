namespace PowerLanguage
{
	/// <summary>Base class for studies.
	/// </summary>
	public abstract class CStudyAbstract : CStudyControl
	{
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
	}
}
