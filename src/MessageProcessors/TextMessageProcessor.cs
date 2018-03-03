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
        private readonly StomachUclerDietDecisionMaker _dietDecisionMaker;
        private readonly StomachUnclerDietOverview _dietOverview;

        public TextMessageProcessor(StomachUnclerDietOverview stomachUnclerDietOverview, StomachUclerDietDecisionMaker stomachUclerDietDecisionMaker)
        {
            _dietOverview = stomachUnclerDietOverview;
            _dietDecisionMaker = stomachUclerDietDecisionMaker;
        }

        public TextProcessorResult Process(string message)
        {
            if (message.Length == 0)
            {
                return new TextProcessorResult("Пустое сообщение");
            }
            var overviews = _dietOverview.GetOverviews();
            var overview = overviews.FirstOrDefault(x => x.Name == message);
            if (overview is null)
            {
                var words = Regex.Replace(message, _specialCharacters, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var forbiddenAnswers = new List<DietAnswer>(words.Length);
                foreach (var word in words)
                {
                    var formattedWord = Regex.Replace(word, _invalidRussianCharacters, "").Trim().ToLower();
                    if (string.IsNullOrEmpty(formattedWord))
                    {
                        continue;
                    }
                    var dietAnswer = _dietDecisionMaker.IsAllowed(formattedWord);
                    if (!dietAnswer.IsAllowed)
                    {
                        forbiddenAnswers.Add(dietAnswer);
                    }
                }
                var decisionMakerContent = forbiddenAnswers.Any() ? string.Join(".", forbiddenAnswers.Select(x => x.Details)) : "можно";
                return new TextProcessorResult(decisionMakerContent);
            }
            var overviewContent = string.Join(".", $"*{overview.Name}*", overview.AllowedDescription, $"*Исключают из диеты:*{overview.ForbiddenDescription}");
            return new TextProcessorResult(overviewContent, new DietReplyMarkup
            {
                keyboard = overviews.Select(x => new List<string> { x.Name }).ToList(),
                one_time_keyboard = true,
                selective = true
            });
        }
    }
}