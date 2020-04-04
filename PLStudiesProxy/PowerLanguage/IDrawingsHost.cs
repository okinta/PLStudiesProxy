using System;

namespace PowerLanguage
{
	internal interface IDrawingsHost : IDisposable
	{
		unsafe IStdFunctions* Impl
		{
			get;
		}

		void Initialize();
	}
}
