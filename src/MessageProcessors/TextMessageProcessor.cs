using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Shared;

namespace Gerb.Telegram.Bot.MessageProcessors
{
    public class TextMessageProcessor
    {
        private readonly string _invalidRussianCharacters = "[^а-яА-Я]";
        private readonly string _specialCharacters = "[,.?!]";
        private readonly StomachUnclerDietContext _dietContext;
        public const string Empty = "Пустое сообщение";
        public const string Positive = "Можно. Но лучше уточните в разделах диеты.";
        private const string Allowed = "Разрешается";
        private const string Forbidden = "Исключают из диеты";

        public TextMessageProcessor(StomachUnclerDietContext dietContext)
        {
            _dietContext = dietContext;
        }

        public async Task<TextProcessorResult> Process(string message)
        {
            if (message.Length == 0)
            {
                return new TextProcessorResult(Empty);
            }
            var sections = await _dietContext.Sections.ToListAsync();
            var section = sections.FirstOrDefault(x => x.Name == message);
            if (section is null)
            {
                var words = Regex.Replace(message, _specialCharacters, " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var formattedWords = words.Select(x => Regex.Replace(x, _invalidRussianCharacters, "").Trim().ToLower()).Where(x => !string.IsNullOrEmpty(x));
                var forbiddenContent = GetForbiddenContent(formattedWords, sections.SelectMany(x => x.Restrictions));
                if (string.IsNullOrEmpty(forbiddenContent))
                {
                    return new TextProcessorResult(Positive, new DietReplyMarkup
                    {
                        keyboard = sections.Select(x => new List<string> { x.Name }).ToList(),
                        one_time_keyboard = true
                    });
                }
                return new TextProcessorResult(forbiddenContent);
            }
            var content = string.Join("\n", $"*{Allowed}:\n*{section.AllowedDescription}", $"*{Forbidden}:\n*{section.ForbiddenDescription}");
            return new TextProcessorResult(content);
        }

        public string GetForbiddenContent(IEnumerable<string> words, IEnumerable<Restriction> restrictions)
        {
            var forbiddenDescriptions = restrictions
                .Where(x => words.Any(word => x.Food.Name.Contains(word, StringComparison.OrdinalIgnoreCase)))
                .Select(x => x.Section.ForbiddenDescription);

            return forbiddenDescriptions.Any() ? string.Join(".", forbiddenDescriptions) : "";
        }
    }
}