using System;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.MessageProcessors;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class TextMessageProcessorTests
    {
        [Theory]
        [InlineData("Можно ли мне есть шоколад?")]
        [InlineData("Можно ли мне есть,например,шоколад?")]
        [InlineData("шоколад?")]
        [InlineData("Шоколад")]
        //[InlineData("Can I eat a chocolate?")]
        public async Task Should_Call_DietDecisionMaker_Forbid_Chocolate(string message)
        {
            var options = new DbContextOptionsBuilder<StomachUnclerDietContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new StomachUnclerDietContext(options))
            {
                var textMessageProcessor = new TextMessageProcessor(context);
                var result = await textMessageProcessor.Process(message);

                Assert.False(string.IsNullOrEmpty(result.Content));
            }
        }

        [Theory]
        [InlineData("Можно ли мне есть банан?")]
        [InlineData("банан")]
        [InlineData("Банан")]
        [InlineData("бананы")]
        public async Task Should_Call_DietDecisionMaker_Allow_Banana(string message)
        {
            var options = new DbContextOptionsBuilder<StomachUnclerDietContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new StomachUnclerDietContext(options))
            {
                var textMessageProcessor = new TextMessageProcessor(context);
                var result = await textMessageProcessor.Process(message);

                Assert.True(string.IsNullOrEmpty(result.Content));
            }
        }
    }
}