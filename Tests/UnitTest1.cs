using PowerLanguage.Strategy;
using Xunit;

namespace Tests
{
    class MyStrategy : SignalObject
    {
        public bool IsAlive { get; private set; }

        public MyStrategy(object _ctx) : base(_ctx)
        {
            IsAlive = true;
        }

        protected override void CalcBar()
        {
        }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var strategy = new MyStrategy("");
            Assert.True(strategy.IsAlive);
        }
    }
}
