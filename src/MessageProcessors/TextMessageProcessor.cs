using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gerb.Telegram.Bot.DecisionMakers;
using Gerb.Telegram.Bot.Entities;

namespace Gerb.Telegram.Bot.MessageProcessors
{
    public class TextMessageProcessor
    {
        private readonly string _invalidRussianCharacters = "[^а-яА-Я]";
        private readonly string _specialCharacters = "[,.?!]";
        private readonly StomachUclerDietDecisionMaker stomachUclerDietDesicionMaker;

        public TextMessageProcessor(StomachUclerDietDecisionMaker stomachUclerDietDesicionMaker)
        {
            this.stomachUclerDietDesicionMaker = stomachUclerDietDesicionMaker;
        }

        public string Process(string message)
        {
            if (message.Length == 0)
            {
                return "Пустое сообщение";
            }
            var words = Regex.Replace(message, _specialCharacters, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var forbiddenAnswers = new List<DietAnswer>(words.Length);
            foreach (var word in words)
            {
                var formattedWord = Regex.Replace(word, _invalidRussianCharacters, "").Trim().ToLower();
                if (string.IsNullOrEmpty(formattedWord))
                {
                    continue;
                }
                var dietAnswer = stomachUclerDietDesicionMaker.IsAllowed(formattedWord);
                if (!dietAnswer.IsAllowed)
                {
                    forbiddenAnswers.Add(dietAnswer);
                }
            }
            return forbiddenAnswers.Any() ? string.Join(".", forbiddenAnswers.Select(x => x.Details)) : "можно";
        }
    }
}