using System;
using Gerb.Telegram.Bot.DecisionMakers;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class StomachUclerDietDecisionMakerTests
    {
        [Theory]
        [InlineData("шоколад")]
        [InlineData("мороженое")]
        [InlineData("ржаной хлеб")]
        [InlineData("свежий хлеб")]
        [InlineData("fresh bread")]
        [InlineData("rye bread")]
        [InlineData("ice cream")]
        [InlineData("chocolate")]
        public void Should_Not_Allow_Food(string input)
        {
            var stomachUclerDietDecisionMaker = new StomachUclerDietDesicionMaker();
            var isAllowed = stomachUclerDietDecisionMaker.IsAllowed(input);

            Assert.False(isAllowed);
        }
    }
}
