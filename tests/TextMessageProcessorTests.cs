using System;
using Gerb.Telegram.Bot.DecisionMakers;
using Gerb.Telegram.Bot.MessageProcessors;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class TextMessageProcessorTests
    {
        [Theory]
        [InlineData("Можно ли мне есть шоколад?")]
        [InlineData("Можно ли мне есть,например,шоколад?")]
        //[InlineData("Can I eat a chocolate?")]
        public void Should_Call_DietDecisionMaker_Return_Not_Allowed(string message)
        {
            var textMessageProcessor = new TextMessageProcessor(new StomachUclerDietDesicionMaker());
            var result = textMessageProcessor.Process(message);
            Assert.Equal("нет", result);
        }

        [Theory]
        [InlineData("Можно ли мне есть банан?")]
        [InlineData("банан")]
        [InlineData("бананы")]
        public void Should_Call_DietDecisionMaker_Return_Allowed(string message)
        {
            var textMessageProcessor = new TextMessageProcessor(new StomachUclerDietDesicionMaker());
            var result = textMessageProcessor.Process(message);
            Assert.Equal("можно", result);
        }
    }
}