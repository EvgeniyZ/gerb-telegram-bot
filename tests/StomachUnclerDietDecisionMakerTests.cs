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
        public void Should_Not_Allow_Food(string food)
        {
            var stomachUclerDietDecisionMaker = new StomachUclerDietDesicionMaker();
            var isAllowed = stomachUclerDietDecisionMaker.IsAllowed(food);

            Assert.False(isAllowed);
        }

        [Theory]
        [InlineData("банан")]
        [InlineData("бананы")]
        public void Should_Allow_Food(string food) 
        {
            var stomachUclerDietDecisionMaker = new StomachUclerDietDesicionMaker();
            var isAllowed = stomachUclerDietDecisionMaker.IsAllowed(food);

            Assert.True(isAllowed);
        }
    }
}
