using _ELAPI_.variables;
using System;

namespace PowerLanguage
{
	internal interface ITechniqueEEService : IDisposable
	{
		/// <exclude />
		void DoExecute();

		/// <exclude />
		void DoConstruct();

		/// <exclude />
		void DoInitialize();

		/// <exclude />
		void DoBeforeCalcInit();

		/// <exclude />
		void DoFinishCalc();

		/// <exclude />
		void DoDestroy();

		/// <exclude />
		void DoCloseBar(int _ds);

		/// <exclude />
		void DoRecovery(int _ds);

		unsafe void DoInitializeVars(IInitIndexes* _indexes);
	}
}
