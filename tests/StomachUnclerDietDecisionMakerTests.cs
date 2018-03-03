using System;
using Gerb.Telegram.Bot.DecisionMakers;
using Gerb.Telegram.Bot.Entities;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class StomachUclerDietDecisionMakerTests
    {
        [Theory]
        [InlineData("шоколад")]
        [InlineData("мороженое")]
        [InlineData("хлеб")]
        [InlineData("консервы")]
        [InlineData("копчености")]
        [InlineData("сметана")]
        // [InlineData("fresh bread")]
        // [InlineData("rye bread")]
        // [InlineData("ice cream")]
        // [InlineData("chocolate")]
        public void Should_Not_Allow_Food(string food)
        {
            var stomachUclerDietDecisionMaker = new StomachUclerDietDecisionMaker();
            var dietAnswer = stomachUclerDietDecisionMaker.IsAllowed(food);

            Assert.False(dietAnswer.IsAllowed);
            Assert.NotEmpty(dietAnswer.Details);
        }

        [Theory]
        [InlineData("банан")]
        [InlineData("бананы")]
        public void Should_Allow_Food(string food) 
        {
            var stomachUclerDietDecisionMaker = new StomachUclerDietDecisionMaker();
            var dietAnswer = stomachUclerDietDecisionMaker.IsAllowed(food);

            Assert.True(dietAnswer.IsAllowed);
            Assert.Empty(dietAnswer.Details);
        }
    }
}
