using System;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.MessageProcessors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class TextMessageProcessorTests : IDisposable
    {
        private readonly DbContextOptions<StomachUnclerDietContext> _options;

        public TextMessageProcessorTests()
        {
            _options = new DbContextOptionsBuilder<StomachUnclerDietContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
        }

        [Theory]
        [InlineData("Можно ли мне есть шоколад?")]
        [InlineData("Можно ли мне есть,например,шоколад?")]
        [InlineData("шоколад?")]
        [InlineData("Шоколад")]
        [InlineData("ржаной")]
        [InlineData("хлеб")]
        [InlineData("ржаной хлеб")]
        //[InlineData("Can I eat a chocolate?")]
        public async Task Should_Call_DietDecisionMaker_Forbid_Chocolate(string message)
        {
            using (var context = new StomachUnclerDietContext(_options))
            {
                ContextInitializer.Initialize(context);
                var textMessageProcessor = new TextMessageProcessor(context, new NullLogger<TextMessageProcessor>());

                var result = await textMessageProcessor.Process(message);

                Assert.False(string.IsNullOrEmpty(result.Content));
                Assert.NotEqual(TextMessageProcessor.Positive, result.Content);
            }
        }

        [Theory]
        [InlineData("Можно ли мне есть банан?")]
        [InlineData("банан")]
        [InlineData("Банан")]
        [InlineData("бананы")]
        public async Task Should_Call_DietDecisionMaker_Allow_Banana(string message)
        {
            using (var context = new StomachUnclerDietContext(_options))
            {
                ContextInitializer.Initialize(context);
                var textMessageProcessor = new TextMessageProcessor(context, new NullLogger<TextMessageProcessor>());
                var result = await textMessageProcessor.Process(message);

                Assert.Equal(TextMessageProcessor.Positive, result.Content);
            }
        }
        public void Dispose()
        {
            using (var context = new StomachUnclerDietContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}