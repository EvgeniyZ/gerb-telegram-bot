using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Shared;
using Microsoft.Extensions.Logging;

namespace Gerb.Telegram.Bot.MessageProcessors
{
    public class TextMessageProcessor
    {
        private readonly string _invalidRussianCharacters = "[^а-яА-Я]";
        private readonly string _specialCharacters = "[,.?!]";
        private readonly StomachUnclerDietContext _dietContext;
        private readonly ILogger<TextMessageProcessor> _logger;
        private const string Allowed = "Разрешается";
        private const string NotAllowed = "Нельзя.";
        private const string Forbidden = "Исключают из диеты";
        private const string Empty = "Пустое сообщение";
        public const string Positive = "Можно. Но лучше уточните в разделах диеты.";

        public TextMessageProcessor(StomachUnclerDietContext dietContext, ILogger<TextMessageProcessor> logger)
        {
            _dietContext = dietContext;
            _logger = logger;
        }

        public async Task<TextProcessorResult> Process(string message)
        {
            if (message.Length == 0)
            {
                return new TextProcessorResult(Empty);
            }
            var sections = await _dietContext.Sections
                .Include(sect => sect.Restrictions)
                .ThenInclude(restr => restr.Food)
                .ToListAsync();
            _logger.LogInformation($"Sections count is - {sections.Count}");
            var section = sections.FirstOrDefault(x => x.Name == message);
            if (section is null)
            {
                var words = GetWords(message);
                var forbiddenContent = GetForbiddenContent(words, sections.SelectMany(x => x.Restrictions).ToList());
                if (string.IsNullOrEmpty(forbiddenContent))
                {
                    return new TextProcessorResult(Positive, new DietReplyMarkup
                    {
                        keyboard = sections.Select(x => new List<string> { x.Name }).ToList(),
                        one_time_keyboard = true
                    });
                }

                return new TextProcessorResult(string.Join("\n", $"*{NotAllowed}.*{Forbidden}:\n*{forbiddenContent}"));
            }
            var content = string.Join("\n", $"*{Allowed}:\n*{section.AllowedDescription}",
                $"*{Forbidden}:\n*{section.ForbiddenDescription}");

            return new TextProcessorResult(content);
        }

        private List<string> GetWords(string message)
        {
            var words = Regex.Replace(message, _specialCharacters, " ")
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return words
                .Select(x => Regex.Replace(x, _invalidRussianCharacters, "")
                                  .Trim()
                                  .ToLower())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
        }

        private string GetForbiddenContent(List<string> words, List<Restriction> restrictions)
        {
            _logger.LogInformation($"Restrictions count is - {restrictions.Count}");
            var forbiddenDescriptions = restrictions
                .Where(x => words.Any(word => x.Food.Name.Contains(word, StringComparison.OrdinalIgnoreCase)))
                .Select(x => x.Section.ForbiddenDescription);

            return forbiddenDescriptions.Any() ? string.Join(".", forbiddenDescriptions) : "";
        }
    }
}