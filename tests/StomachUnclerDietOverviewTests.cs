using System;
using Gerb.Telegram.Bot.DecisionMakers;
using Gerb.Telegram.Bot.Entities;
using Xunit;

namespace Gerb.Unit.Tests
{
    public sealed class StomachUnclerDietOverviewTests
    {
        [Fact]
        public void Should_Return_Overviews()
        {
            var desicionMaker = new StomachUnclerDietOverview();

            var overviews = desicionMaker.GetOverviews();

            foreach (var overview in overviews)
            {
                Assert.NotNull(overview);
                Assert.True(!string.IsNullOrEmpty(overview.Name));
                Assert.True(!string.IsNullOrEmpty(overview.AllowedDescription));
                Assert.True(!string.IsNullOrEmpty(overview.ForbiddenDescription));
            }
        }
    }
}