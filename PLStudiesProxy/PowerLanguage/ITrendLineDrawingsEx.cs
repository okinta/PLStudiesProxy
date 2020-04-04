using System;

namespace PowerLanguage
{
	internal interface ITrendLineDrawingsEx : ITrendLineContainer, IDrawingsHost, IDisposable
	{
		unsafe ITrendLineDrawingsEx Create(IStdFunctions* _host);
	}
}
