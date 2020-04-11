using PowerLanguage.Strategy;
using PowerLanguage;
using Xunit;

namespace Tests
{
    internal class MyStrategy : SignalObject
    {
        [Input]
        public bool IsAlive { get; set; }

        public MyStrategy(object _ctx) : base(_ctx)
        {
            IsAlive = true;
        }

        protected override void CalcBar()
        {
        }
    }

    public class StrategyTest
    {
        [Fact]
        public void TestCanInstantiate()
        {
            var strategy = new MyStrategy("");
            Assert.True(strategy.IsAlive);
        }
    }
}
