using System;
using Gerb.Telegram.Bot.DecisionMakers;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class ProcessTextMessageTests
    {
        [Fact]
        public void Should_Forbid_Messages()
        {
            var expected = "шоколад";
            var stomachUclerDietDecisionMaker = new StomachUclerDietDesicionMaker();
            var isAllowed = stomachUclerDietDecisionMaker.IsAllow(expected);
            Assert.False(isAllowed);
        }
    }
}
