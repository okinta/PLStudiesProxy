using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;

namespace _003CCrtImplementationDetails_003E
{
	internal class ModuleUninitializer : Stack
	{
		private static object @lock = new object();

		internal static ModuleUninitializer _ModuleUninitializer = new ModuleUninitializer();

		[SecuritySafeCritical]
		internal void AddHandler(EventHandler handler)
		{
			bool lockTaken = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				Monitor.Enter(@lock, ref lockTaken);
				RuntimeHelpers.PrepareDelegate(handler);
				Push(handler);
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(@lock);
				}
			}
		}

		[SecuritySafeCritical]
		private ModuleUninitializer()
		{
			EventHandler value = SingletonDomainUnload;
			AppDomain.CurrentDomain.DomainUnload += value;
			AppDomain.CurrentDomain.ProcessExit += value;
		}

		[SecurityCritical]
		[PrePrepareMethod]
		private void SingletonDomainUnload(object source, EventArgs arguments)
		{
			bool lockTaken = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				Monitor.Enter(@lock, ref lockTaken);
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						((EventHandler)enumerator.Current)(source, arguments);
					}
				}
				finally
				{
					IEnumerator enumerator2 = enumerator;
					(enumerator as IDisposable)?.Dispose();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(@lock);
				}
			}
		}
	}
}
