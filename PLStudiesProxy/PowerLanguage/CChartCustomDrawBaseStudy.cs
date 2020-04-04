using ITS_MCCharting;
using PowerLanguage.details;

namespace PowerLanguage
{
	internal sealed class CChartCustomDrawBaseStudy : CChartCustomDraw
	{
		private unsafe IBaseStudy* m_host;

		public unsafe CChartCustomDrawBaseStudy(IBaseStudy* _host)
			: base(null, 0u)
		{
		}//IL_0010: Expected I, but got I8

		protected unsafe sealed override void activate()
		{
		}
	}
}
