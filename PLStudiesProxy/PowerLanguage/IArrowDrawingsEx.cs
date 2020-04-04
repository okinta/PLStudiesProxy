using System;

namespace PowerLanguage
{
	internal interface IArrowDrawingsEx : IArrowContainer, IDrawingsHost, IDisposable
	{
		unsafe IArrowDrawingsEx Create(IStdFunctions* _host);
	}
}
