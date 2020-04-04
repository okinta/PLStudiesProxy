using _ELAPI_.variables;
using ManagedStudies.details;
using System;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	/// <summary>
	/// Class that describes a function object.
	/// </summary>
	public abstract class FunctionObject<T> : CStudyControl, IFunctionObject<T>, IStudy, IFunctionManageEx
	{
		/// <exclude />
		protected bool m_calculated;

		/// <exclude />
		private IStrategy m_strategy_site;

		/// <summary>
		/// Read-only property. Returns a reference to the current strategy.
		/// </summary>
		protected IStrategy MyStrategy
		{
			get
			{
				IStrategy strategy_site = m_strategy_site;
				if (null == strategy_site)
				{
					throw new StrategyOnlyKeywordException();
				}
				return strategy_site;
			}
		}

		/// <summary>
		/// Read-only property. Returns a reference to the curent bar.
		/// </summary>
		public virtual T Value => this[0];

		/// <summary>
		/// Read-only property. Returns a reference to a bar located a specified number of bars back from the current bar.
		/// </summary>
		public abstract T this[int bars_ago]
		{
			get;
		}

		/// <summary>
		/// Initializes a new instance of the FunctionObject class.
		/// </summary>
		public unsafe FunctionObject(CStudyControl _master, [MarshalAs(UnmanagedType.U1)] bool _is_series, int _ds) : base(null, 0)
		{
		}

		public void DoInitialize()
		{
			throw new NotImplementedException();
		}

		public void DoBeforeCalcInit()
		{
			throw new NotImplementedException();
		}

		public void DoUnInitialize()
		{
			throw new NotImplementedException();
		}

		public void DoFakeExecute()
		{
			throw new NotImplementedException();
		}

		public void DoCloseBarVars(int _ds)
		{
			throw new NotImplementedException();
		}

		public void DoRecoveryVars(int _ds)
		{
			throw new NotImplementedException();
		}

		public void DoConstruct()
		{
			throw new NotImplementedException();
		}

		public void DoDestroy()
		{
			throw new NotImplementedException();
		}

		private unsafe void _007EFunctionObject_00601()
		{
		}

		/// <summary>
		/// Returns a reference to the curent bar.
		/// </summary>
		public T Call()
		{
			return Value;
		}

		/// <summary>
		/// Returns a reference to a bar located a specified number of bars back from the current bar.
		/// </summary>
		public T Call(int bars_ago)
		{
			return this[bars_ago];
		}

		/// <exclude />
		protected abstract T CalcBar();

		/// <exclude />
		protected virtual void Create()
		{
		}

		/// <exclude />
		protected virtual void StartCalc()
		{
		}

		/// <exclude />
		protected virtual void StopCalc()
		{
		}

		/// <exclude />
		protected virtual void Destroy()
		{
		}

		/// <exclude />
		protected void BeforeConstructImpl()
		{
			m_phase = (EExecutionPhase)1;
		}

		/// <exclude />
		protected virtual void DestroyImpl()
		{
		}

		/// <exclude />
		protected void _recover()
		{
		}

		/// <exclude />
		public void DoFinishCalc()
		{
			StopCalc();
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
			if (P_0)
			{
				try
				{
					_007EFunctionObject_00601();
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

		internal unsafe void DoInitializeVars(IInitIndexes* _indexes)
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoInitialize()
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoBeforeCalcInit()
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoUnInitialize()
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoFakeExecute()
		{
			throw new NotImplementedException();
		}

		unsafe void IFunctionManageEx.DoInitializeVars(IInitIndexes* _indexes)
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoCloseBarVars(int _ds)
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoRecoveryVars(int _ds)
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoConstruct()
		{
			throw new NotImplementedException();
		}

		void IFunctionManageEx.DoDestroy()
		{
			throw new NotImplementedException();
		}
	}
}
