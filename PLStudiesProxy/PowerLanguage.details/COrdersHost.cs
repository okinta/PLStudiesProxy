using _ELAPI_;
using ManagedStudies.details;
using std;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PowerLanguage.details
{
	internal sealed class COrdersHost : IOrderControl, IDisposable
	{
		private sealed class COrdersFromEntryColl
		{
			private Dictionary<int, string> m_entryID_vs_entryName;

			private Dictionary<int, int> m_exitID_vs_fromEntryID;

			public COrdersFromEntryColl()
			{
				m_entryID_vs_entryName = new Dictionary<int, string>();
				m_exitID_vs_fromEntryID = new Dictionary<int, int>();
			}

			public void AddOrderToCollection(int ID, Order info)
			{
				if (info.IsEntry)
				{
					string name = info.Name;
					m_entryID_vs_entryName[ID] = name;
				}
				else if (info.OrderExit.ExitType == OrderExit.EExitType.FromOne || info.OrderExit.ExitType == OrderExit.EExitType.FromOneTotal)
				{
					int entryID = info.OrderExit.EntryID;
					m_exitID_vs_fromEntryID[ID] = entryID;
				}
			}

			public void CheckNameForID(int ID, string name)
			{
				m_entryID_vs_entryName[ID] = name;
			}

			public void AddEntryOrder(int id, string name)
			{
				m_entryID_vs_entryName[id] = name;
			}

			public void AddExitFromEntry(int exitID, int entryID)
			{
				m_exitID_vs_fromEntryID[exitID] = entryID;
			}

			public unsafe _bstr_t* FromEntryName(_bstr_t* P_0, int id)
			{
				throw new NotImplementedException();
			}
		}

		private COrdersFromEntryColl m_order_fromentry_coll;

		private unsafe IStrategyOrders* m_impl;

		private EExecutionPhase m_phase = (EExecutionPhase)1;

		private static EOrderCategory Cat2Cat(OrderCategory order_cat, [MarshalAs(UnmanagedType.U1)] bool on_close)
		{
			switch (order_cat)
			{
			default:
				throw new NotSupportedException("unknown order category!");
			case OrderCategory.StopLimit:
				return (EOrderCategory)8;
			case OrderCategory.Stop:
				return (EOrderCategory)1;
			case OrderCategory.Limit:
				return (EOrderCategory)2;
			case OrderCategory.Market:
				return on_close ? ((EOrderCategory)4) : ((EOrderCategory)3);
			}
		}

		private unsafe static SContractNumber* MakeContractNum(SContractNumber* P_0, Order _info)
		{
			*(int*)P_0 = 0;
			*(sbyte*)((long)(IntPtr)P_0 + 4) = 0;
			if (_info.Contracts.IsUserSpecified)
			{
				*(int*)P_0 = -1;
			}
			if (_info.OrderExit.IsTotal)
			{
				*(sbyte*)((long)(IntPtr)P_0 + 4) = 1;
			}
			return P_0;
		}

		private unsafe static CExitType* MakeExitType(CExitType* P_0, Order info)
		{
			*(int*)P_0 = 0;
			*(int*)((long)(IntPtr)P_0 + 4) = -1;
			OrderExit.EExitType exitType = info.OrderExit.ExitType;
			if ((uint)(exitType - 2) <= 1u)
			{
				*(int*)P_0 = 1;
				*(int*)((long)(IntPtr)P_0 + 4) = info.OrderExit.EntryID;
			}
			return P_0;
		}

		private unsafe static SOrderWordInfoImpl* CreateFrom(SOrderWordInfoImpl* P_0, Order info)
		{
			throw new NotImplementedException();
		}

		public unsafe COrdersHost(IStrategyOrders* impl)
		{
			m_order_fromentry_coll = new COrdersFromEntryColl();
		}

		private unsafe void _007ECOrdersHost()
		{
			//IL_0008: Expected I, but got I8
			m_impl = null;
		}

		public unsafe int RegisterOrder(Order info)
		{
			return 0;
		}

		public unsafe void GenerateOrder(SOrder order)
		{
		}

		public void SetExecutablePhase()
		{
			m_phase = (EExecutionPhase)3;
		}

		public void SetConstructPhase()
		{
			m_phase = (EExecutionPhase)1;
		}

		private unsafe void check_strategy_orders()
		{
			if (m_impl == null)
			{
				throw new ObjectDisposedException("Trying handle the object already disposed.");
			}
		}

		protected unsafe void Dispose([MarshalAs(UnmanagedType.U1)] bool P_0)
		{
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
