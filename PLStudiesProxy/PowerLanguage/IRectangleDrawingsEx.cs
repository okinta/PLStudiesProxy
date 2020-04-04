using System;

namespace PowerLanguage
{
	internal interface IRectangleDrawingsEx : IRectangleContainer, IDrawingsHost, IDisposable
	{
		unsafe IRectangleDrawingsEx Create(IStdFunctions* _host);
	}
}
