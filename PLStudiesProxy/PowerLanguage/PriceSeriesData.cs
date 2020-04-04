using _ELAPI_;
using _ELAPI_.variables;
using _003CCppImplementationDetails_003E;
using ManagedStudies.details;
using std;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PowerLanguage
{
	internal class PriceSeriesData : IPriceSeriesData
	{
		private abstract class SeriaBase<T> : ISeries<T>
		{
			private unsafe IBaseStudy* m_host;

			private _0024PTMType_0024Q8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z m_accessor_func;

			private eELPriceSeriesMD m_price_id;

			private ulong m_dn;

			private unsafe IVariable_003Cdouble_003E* m_var;

			private IndexerImpl m_indexer;

			private unsafe double* m_data_ptr;

			public virtual T Value => this[0];

			public abstract T this[int P_0]
			{
				get;
			}

			protected unsafe SeriaBase(eELPriceSeriesMD _price_id, IBaseStudy* _host, ulong _dn, _0024PTMType_0024Q8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z _accessor_func)
			{
			}

			public unsafe void ReBind()
			{
			}

			protected unsafe double get_value(int bars_ago)
			{
				return 0;
			}
		}

		private sealed class Seria_double : SeriaBase<double>
		{
			public sealed override double this[int bars_ago] => get_value(bars_ago);

			public unsafe Seria_double(eELPriceSeriesMD _price_id, IBaseStudy* _host, ulong _dn, _0024PTMType_0024Q8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z _accessor_func)
				: base(_price_id, _host, _dn, _accessor_func)
			{
			}
		}

		private sealed class Seria_System_DateTime : SeriaBase<DateTime>
		{
			public sealed override DateTime this[int bars_ago] => DateTime.FromOADate(get_value(bars_ago));

			public unsafe Seria_System_DateTime(eELPriceSeriesMD _price_id, IBaseStudy* _host, ulong _dn, _0024PTMType_0024Q8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z _accessor_func)
				: base(_price_id, _host, _dn, _accessor_func)
			{
			}
		}

		private sealed class Seria_uint : SeriaBase<uint>
		{
			public sealed override uint this[int bars_ago] => (uint)get_value(bars_ago);

			public unsafe Seria_uint(eELPriceSeriesMD _price_id, IBaseStudy* _host, ulong _dn, _0024PTMType_0024Q8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z _accessor_func)
				: base(_price_id, _host, _dn, _accessor_func)
			{
			}
		}

		private sealed class Seria_int : SeriaBase<int>
		{
			public sealed override int this[int bars_ago] => (int)get_value(bars_ago);

			public unsafe Seria_int(eELPriceSeriesMD _price_id, IBaseStudy* _host, ulong _dn, _0024PTMType_0024Q8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z _accessor_func)
				: base(_price_id, _host, _dn, _accessor_func)
			{
			}
		}

		private _0024PTMType_0024Q8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z m_accessor_func;

		private bool m_rebinded;

		protected ulong m_dn;

		private unsafe void* m_host;

		private unsafe IVariable_003Cdouble_003E* m_Open;

		private Seria_double m_seriaOpen;

		private unsafe IVariable_003Cdouble_003E* m_Close;

		private Seria_double m_seriaClose;

		private unsafe IVariable_003Cdouble_003E* m_Low;

		private Seria_double m_seriaLow;

		private unsafe IVariable_003Cdouble_003E* m_High;

		private Seria_double m_seriaHigh;

		private unsafe IVariable_003Cdouble_003E* m_Volume;

		private Seria_double m_seriaVolume;

		private unsafe IVariable_003Cdouble_003E* m_OpenInt;

		private Seria_double m_seriaOpenInt;

		private unsafe IVariable_003Cdouble_003E* m_UpTicks;

		private Seria_double m_seriaUpTicks;

		private unsafe IVariable_003Cdouble_003E* m_DownTicks;

		private Seria_double m_seriaDownTicks;

		private unsafe IVariable_003Cdouble_003E* m_Ticks;

		private Seria_double m_seriaTicks;

		private unsafe IVariable_003Cdouble_003E* m_TickID;

		private Seria_uint m_seriaTickID;

		private unsafe IVariable_003Cdouble_003E* m_LevelsCount;

		private Seria_int m_seriaLevelsCount;

		private unsafe IVariable_003Cdouble_003E* m_LevelHigh;

		private Seria_double m_seriaLevelHigh;

		private unsafe IVariable_003Cdouble_003E* m_LevelLow;

		private Seria_double m_seriaLevelLow;

		private unsafe IVariable_003Cdouble_003E* m_POCPrice;

		private Seria_double m_seriaPOCPrice;

		private unsafe IVariable_003Cdouble_003E* m_POCBlocks;

		private Seria_int m_seriaPOCBlocks;

		private unsafe IVariable_003C__int64_003E* m_TimeTicks;

		private Seria_System_DateTime m_seriaTime;

		public ISeries<DateTime> Time => m_seriaTime;

		public unsafe DateTime TimeValue
		{
			get
			{
				return new DateTime();
			}
		}

		public ISeries<int> POCBlocks => m_seriaPOCBlocks;

		public unsafe int POCBlocksValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> POCPrice => m_seriaPOCPrice;

		public unsafe double POCPriceValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> LevelLow => m_seriaLevelLow;

		public unsafe double LevelLowValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> LevelHigh => m_seriaLevelHigh;

		public unsafe double LevelHighValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<int> LevelsCount => m_seriaLevelsCount;

		public unsafe int LevelsCountValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<uint> TickID => m_seriaTickID;

		public unsafe uint TickIDValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> Ticks => m_seriaTicks;

		public unsafe double TicksValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> DownTicks => m_seriaDownTicks;

		public unsafe double DownTicksValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> UpTicks => m_seriaUpTicks;

		public unsafe double UpTicksValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> OpenInt => m_seriaOpenInt;

		public unsafe double OpenIntValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> Volume => m_seriaVolume;

		public unsafe double VolumeValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> High => m_seriaHigh;

		public unsafe double HighValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> Low => m_seriaLow;

		public unsafe double LowValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> Close => m_seriaClose;

		public unsafe double CloseValue
		{
			get
			{
				return 0;
			}
		}

		public ISeries<double> Open => m_seriaOpen;

		public unsafe double OpenValue
		{
			get
			{
				return 0;
			}
		}

		public unsafe virtual DateTime BarUpdateTime
		{
			get
			{
				return new DateTime();
			}
		}

		public unsafe virtual bool IsExist
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return false;
			}
		}

		public unsafe PriceSeriesData(void* _host, int _dn, _0024PTMType_0024P8IBaseStudy_0040_0040EAAAEAU_003F_0024IVariable_0040N_0040_0040W4eELPriceSeriesMD_0040_0040I_0040Z _accessor)
		{
		}

		private unsafe void _007EPriceSeriesData()
		{
			//IL_0008: Expected I, but got I8
			m_host = null;
		}

		public virtual void EnsureReBinded()
		{
			if (!m_rebinded)
			{
				ReBind();
			}
		}

		public unsafe virtual void ReBind()
		{
		}

		public unsafe int BlocksByPrice(double price, int barsback, int dataNum)
		{
			return 0;
		}

		public unsafe int BlocksByPrice(double price, int barsback)
		{
			return 0;
		}

		public unsafe int SymbolBlocksByPrice(double price, int barNum, int dataNum)
		{
			return 0;
		}

		public unsafe int SymbolBlocksByPrice(double price, int barNum)
		{
			return 0;
		}

		protected unsafe IBaseStudy* host()
		{
			void* host = m_host;
			if (host == null)
			{
				throw new ObjectDisposedException("PriceSeriesData");
			}
			return (IBaseStudy*)host;
		}

		protected unsafe virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
