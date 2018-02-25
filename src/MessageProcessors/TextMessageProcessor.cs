using System;
using System.Collections.Generic;
using System.Linq;
using Gerb.Telegram.Bot.DecisionMakers;

namespace Gerb.Telegram.Bot.MessageProcessors
{
    public class TextMessageProcessor
    {
        private readonly StomachUclerDietDesicionMaker stomachUclerDietDesicionMaker;

        public TextMessageProcessor(StomachUclerDietDesicionMaker stomachUclerDietDesicionMaker)
        {
            this.stomachUclerDietDesicionMaker = stomachUclerDietDesicionMaker;
        }

        public string Process(string message)
        {
            if (message.Length == 0)
            {
                return "Пустое сообщение";
            }
            var words = message.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var isAllowedAnswers = new List<bool>(words.Length);
            foreach (var word in words)
            {
                isAllowedAnswers.Add(stomachUclerDietDesicionMaker.IsAllowed(word));
            }
            return isAllowedAnswers.Any(x => x == false) ? "можно" : "нет";
        }
    }
}