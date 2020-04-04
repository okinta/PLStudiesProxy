using _ELAPI_;
using _003CCppImplementationDetails_003E;
using BugSlayerUtil;
using ManagedStudies.details;
using PowerLanguage.VolumeProfile;
using std;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal sealed class PriceSeriesImpl : PriceSeriesData, PriceSeries
	{
		private sealed class TPODynamicSettingsHelper : ITPODynamicSettings
		{
			private unsafe IBaseStudy* m_host;

			public unsafe bool ShowBlocksWithZeroTrades
			{
				[return: MarshalAs(UnmanagedType.U1)]
				get
				{
					return false;
				}
			}

			public unsafe int InitialBalanceRange
			{
				get
				{
					return 0;
				}
			}

			public unsafe int ValueArea2
			{
				get
				{
					return 0;
				}
			}

			public unsafe int ValueArea
			{
				get
				{
					return 0;
				}
			}

			public unsafe long PriceIncrement
			{
				get
				{
					return 0;
				}
			}

			public unsafe TPODynamicSettingsHelper(void* _host)
			{
			}
		}

		private unsafe CStatusLine m_status_line;

		private Instrument m_sym_info;

		private IROList<SessionObject> m_sessions;

		private unsafe TPOSeriesDataRand m_full_sym_data;

		private DOMData m_dom;

		private unsafe ulong* m_cur_bar_ptr;

		private IProfilesCollection m_vp;

		private unsafe TPODynamicSettingsHelper m_TPO_dyn_settings;

		public ITPODataRand FullTPOData => m_full_sym_data;

		public ITPODynamicSettings DynamicSettings => m_TPO_dyn_settings;

		public ITPOSettings Settings => m_sym_info;

		public unsafe IProfilesCollection VolumeProfile
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public InstrumentDataRequest Request => new InstrumentDataRequest(Info);

		public unsafe IDOMData DOM
		{
			get
			{
				if (null == m_dom)
				{
					m_dom = new DOMData(host(), (uint)m_dn);
				}
				return m_dom;
			}
		}

		public ISeriesSymbolDataRand FullSymbolData => m_full_sym_data;

		public IROList<SessionObject> Sessions => m_sessions;

		public IStatusLine StatusLine => m_status_line;

		public IInstrumentSettings Info => m_sym_info;

		public unsafe EBarState Status
		{
			get
			{
				return EBarState.None;
			}
		}

		public unsafe double Point
		{
			get
			{
				return 0;
			}
		}

		public unsafe bool LastBarInSession
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public bool LastBarOnChart
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				DateTime timeValue = TimeValue;
				return LastBarTime == timeValue;
			}
		}

		public unsafe DateTime LastBarTime
		{
			get
			{
				return new DateTime();
			}
		}

		public unsafe int CurrentBar => (int)(*m_cur_bar_ptr);

		public unsafe PriceSeriesImpl(void* _host, int _dn) : base(null, 0, new _0024PTMType_0024P8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z())
		{
		}

		private void _007EPriceSeriesImpl()
		{
			((IDisposable)m_full_sym_data)?.Dispose();
			free_vp();
		}

		private void free_vp()
		{
			IProfilesCollection vp = m_vp;
			if (null != vp)
			{
				((IProfilesCollectionService)vp).ENeedSync -= _VPENeedSync;
				m_vp?.Dispose();
			}
			m_vp = null;
		}

		public unsafe sealed override void ReBind()
		{
		}

		private unsafe ulong correct_data_number(ulong dn)
		{
			return 0;
		}

		public void OnBeforeRTCalc()
		{
			IProfilesCollection vp = m_vp;
			if (null != vp)
			{
				((IProfilesCollectionService)vp).Syncronize();
			}
		}

		private void _VPENeedSync(object P_0, EventArgs P_1)
		{
		}

		private unsafe void _VPCreate()
		{
		}

		private InstrumentDataRequest generate_request()
		{
			return new InstrumentDataRequest(Info);
		}

		[HandleProcessCorruptedStateExceptions]
		protected sealed override void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
			if (P_0)
			{
				try
				{
					_007EPriceSeriesImpl();
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
