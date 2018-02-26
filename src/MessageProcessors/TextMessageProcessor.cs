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
            var answers = new List<bool>(words.Length);
            foreach (var word in words)
            {
                var formattedWord = Regex.Replace(word, _invalidRussianCharacters, "").Trim().ToLower();
                if (string.IsNullOrEmpty(formattedWord))
                {
                    answers.Add(true);
                    continue;
                }
                answers.Add(stomachUclerDietDesicionMaker.IsAllowed(formattedWord));
            }
            return answers.All(x => x == true) ? "можно" : "нет";
        }
    }
}