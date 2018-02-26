using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gerb.Telegram.Bot.DecisionMakers;

namespace Gerb.Telegram.Bot.MessageProcessors
{
    public class TextMessageProcessor
    {
        private readonly string _invalidRussianCharacters = "[^а-яА-Я]";
        private readonly string _specialCharacters = "[,.?!]";
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
            var words = Regex.Replace(message, _specialCharacters, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var forbiddenAnswers = new List<Tuple<bool, string>>(words.Length);
            foreach (var word in words)
            {
                var formattedWord = Regex.Replace(word, _invalidRussianCharacters, "").Trim().ToLower();
                if (string.IsNullOrEmpty(formattedWord))
                {
                    continue;
                }
                var (isAllowed, details) = stomachUclerDietDesicionMaker.IsAllowed(formattedWord);
                if (!isAllowed)
                {
                    forbiddenAnswers.Add(Tuple.Create(isAllowed, details));
                }
            }
            return forbiddenAnswers.Any() ? string.Join(".", forbiddenAnswers.Select(x => x.Item2)) : "можно";
        }
    }
}