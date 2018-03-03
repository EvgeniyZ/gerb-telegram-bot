using System;
using Gerb.Telegram.Bot.DecisionMakers;
using Gerb.Telegram.Bot.Entities;
using Xunit;

namespace Gerb.Unit.Tests
{
    public sealed class StomachUnclerDietOverviewTests
    {
        [Fact]
        public void Should_Return_Overview_About_Section() 
        {
            var section = "ХЛЕБ И МУЧНЫЕ ИЗДЕЛИЯ";
            var desicionMaker = new StomachUnclerDietOverview();

            var overview = desicionMaker.GetOverview(section);

            Assert.NotNull(overview);
            Assert.True(!string.IsNullOrEmpty(overview.Name));
        }
    }
}