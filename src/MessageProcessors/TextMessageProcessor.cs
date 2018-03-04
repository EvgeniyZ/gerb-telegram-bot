using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gerb.Telegram.Bot.MessageProcessors
{
    public class TextMessageProcessor
    {
        private readonly string _invalidRussianCharacters = "[^а-яА-Я]";
        private readonly string _specialCharacters = "[,.?!]";
        private readonly StomachUnclerDietContext _dietContext;

        public TextMessageProcessor(StomachUnclerDietContext dietContext)
        {
            _dietContext = dietContext;
        }

        public async Task<TextProcessorResult> Process(string message)
        {
            if (message.Length == 0)
            {
                return new TextProcessorResult("Пустое сообщение");
            }
            var sections = await _dietContext.Sections.ToListAsync();
            var section = sections.FirstOrDefault(x => x.Title == message);
            if (section is null)
            {
                var words = Regex.Replace(message, _specialCharacters, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var forbiddenAnswers = new List<DietAnswer>(words.Length);
                var restrictions = await _dietContext.Restrictions.ToListAsync();
                foreach (var word in words)
                {
                    var formattedWord = Regex.Replace(word, _invalidRussianCharacters, "").Trim().ToLower();
                    if (string.IsNullOrEmpty(formattedWord))
                    {
                        continue;
                    }
                    var restriction = restrictions.FirstOrDefault(x => x.Food.Name == formattedWord);
                    if (restriction is null)
                    {
                        continue;
                    }
                    forbiddenAnswers.Add(new DietAnswer(false, restriction.Group.ForbiddenDescription));
                }
                if (forbiddenAnswers.Any())
                {
                    return new TextProcessorResult(string.Join(".", forbiddenAnswers.Select(x => x.Details)));
                }
                return new TextProcessorResult("Можно. Но лучше уточните в разделах диеты.", new DietReplyMarkup
                {
                    keyboard = sections.Select(x => new List<string> { x.Title }).ToList(),
                    one_time_keyboard = true
                });
            }
            var content = string.Join("\n", $"*Разрешается:\n*{section.AllowedDescription}", $"*Исключают из диеты:\n*{section.ForbiddenDescription}");
            return new TextProcessorResult(content);
        }
    }
}