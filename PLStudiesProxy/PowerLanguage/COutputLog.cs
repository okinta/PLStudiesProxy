using PowerLanguage.Server;

namespace PowerLanguage
{
	/// <exclude />
	internal sealed class COutputLog : IOutput
	{
		private readonly Output m_output;

		public COutputLog()
		{
			m_output = Output.Instance;
		}

		public void Write(string _format, object[] _args)
		{
			m_output.Write(_format, _args);
		}

		public void WriteLine(string _format, object[] _args)
		{
			m_output.WriteLine(_format, _args);
		}

		public void Clear()
		{
			m_output.Clear();
		}
	}
}
