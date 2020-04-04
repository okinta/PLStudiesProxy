using System;

namespace PowerLanguage
{
	internal interface ITextDrawingsEx : ITextContainer, IDrawingsHost, IDisposable
	{
		unsafe ITextDrawingsEx Create(IStdFunctions* _host);
	}
}
