using System;
using Gerb.Telegram.Bot.DecisionMakers;
using Gerb.Telegram.Bot.MessageProcessors;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class TextMessageProcessorTests
    {
        [Fact]
        public void Should_Call_DietDecisionMaker_Return_Result() 
        {
            var message = "Можно ли мне есть шоколад?";
            var textMessageProcessor = new TextMessageProcessor(new StomachUclerDietDesicionMaker());
            var result = textMessageProcessor.Process(message);
            Assert.Equal("нет", result);
        }
    }
}