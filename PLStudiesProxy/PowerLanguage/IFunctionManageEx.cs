using _ELAPI_.variables;

namespace PowerLanguage
{
	internal interface IFunctionManageEx : IFunctionAbstract
	{
		void DoInitialize();

		void DoBeforeCalcInit();

		void DoUnInitialize();

		void DoFakeExecute();

		internal unsafe void DoInitializeVars(IInitIndexes* _indexes);

		void DoCloseBarVars(int _ds);

		void DoRecoveryVars(int _ds);

		void DoConstruct();

		void DoDestroy();
	}
}
