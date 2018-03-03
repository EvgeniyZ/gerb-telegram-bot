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
        [InlineData("шоколад?")]
        [InlineData("Шоколад")]
        //[InlineData("Can I eat a chocolate?")]
        public void Should_Call_DietDecisionMaker_Forbid_Chocolate(string message)
        {
            var textMessageProcessor = new TextMessageProcessor(new StomachUclerDietDecisionMaker());
            var result = textMessageProcessor.Process(message);

            Assert.Equal("Шоколад исключен из диеты. Из сладкого можно сахар, мёд, некислое варенье, зефир, пастила.", result);
        }

        [Theory]
        [InlineData("Можно ли мне есть банан?")]
        [InlineData("банан")]
        [InlineData("Банан")]
        [InlineData("бананы")]
        public void Should_Call_DietDecisionMaker_Allow_Banana(string message)
        {
            var textMessageProcessor = new TextMessageProcessor(new StomachUclerDietDecisionMaker());
            var result = textMessageProcessor.Process(message);

            Assert.Equal("можно", result);
        }
    }
}