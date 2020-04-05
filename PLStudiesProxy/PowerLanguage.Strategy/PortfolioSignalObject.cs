using _ELAPI_;
using ATCenterProxy.interop;
using boost;
using ManagedStudies.details;
using PowerLanguage.Strategy.implementation;
using std;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage.Strategy
{
	public abstract class PortfolioSignalObject : SignalObject, IPortfolio
	{
		private PortfolioStrategiesColl m_impl;

		private IPortfolioData m_my_data;

		public MTPA_MCSymbolCurrency PortfolioCurrency
		{
			get
			{
				//Discarded unreachable code: IL_0042
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					if (null == m_impl)
					{
						DelayInit();
					}
					return ((IPortfolio)m_impl).PortfolioCurrency;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "PortfolioCurrency"));
			}
		}

		public IPortfolioData MyPortfolioData
		{
			get
			{
				//Discarded unreachable code: IL_003d
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					if (null == m_impl)
					{
						DelayInit();
					}
					return m_my_data;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "MyPortfolioData"));
			}
		}

		public IPortfolioData CommonPortfolioData
		{
			get
			{
				//Discarded unreachable code: IL_0042
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					if (null == m_impl)
					{
						DelayInit();
					}
					return ((IPortfolio)m_impl).CommonPortfolioData;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "CommonPortfolioData"));
			}
		}

		public IROList<IPortfolioStrategy> PortfolioStrategies
		{
			get
			{
				//Discarded unreachable code: IL_0042
				EExecutionPhase phase = m_phase;
				if (phase != (EExecutionPhase)1 && phase != 0)
				{
					if (null == m_impl)
					{
						DelayInit();
					}
					return ((IPortfolio)m_impl).PortfolioStrategies;
				}
				throw new ExecuteStudyException(string.Format("Unaccessible property(method): {0}. Initialize (StartCalc method) or Execute (CalcBar method).", "PortfolioStrategies"));
			}
		}

		/// <exclude />
		protected PortfolioSignalObject(object _ctx)
			: base(_ctx)
		{
		}

		private void _007EPortfolioSignalObject()
		{
			((IDisposable)m_impl)?.Dispose();
		}

		protected sealed override void BeforeInitializeImpl()
		{
			base.BeforeInitializeImpl();
			((IDisposable)m_impl)?.Dispose();
			m_impl = null;
		}

		private void DelayInit()
		{
		}

		private IPortfolio impl()
		{
			if (null == m_impl)
			{
				DelayInit();
			}
			return m_impl;
		}

		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
			if (P_0)
			{
				try
				{
					_007EPortfolioSignalObject();
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
