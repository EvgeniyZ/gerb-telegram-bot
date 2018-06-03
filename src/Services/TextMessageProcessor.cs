using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gerb.Telegram.Bot.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Domain;
using Microsoft.Extensions.Logging;

namespace Gerb.Telegram.Bot.Services
{
    public class TextMessageProcessor
    {
        private readonly DietContext _dietContext;
        private readonly ILogger<TextMessageProcessor> _logger;

        public TextMessageProcessor(DietContext dietContext, ILogger<TextMessageProcessor> logger)
        {
            _dietContext = dietContext;
            _logger = logger;
        }

        public async Task<TextProcessorResult> Process(string message)
        {
            if (message.Length == 0)
            {
                return new TextProcessorResult(AnswerMaker.GetEmptyAnswer());
            }
            var sections = await _dietContext.Sections
                .Include(sect => sect.Restrictions)
                .ThenInclude(restr => restr.Food)
                .ToListAsync();
            _logger.LogDebug($"Sections count is - {sections.Count}");
            var section = sections.FirstOrDefault(x => x.Name == message);
            if (section is null)
            {
                List<string> words = MessageParser.GetWords(message);
                var restrictions = sections.SelectMany(x => x.Restrictions).ToList();
                _logger.LogDebug($"Restrictions count is - {restrictions.Count}");
                string forbiddenContent = DecisionMaker.GetForbiddenContent(words, restrictions);
                if (string.IsNullOrEmpty(forbiddenContent))
                {
                    var recommendations = sections
                        .SelectMany(x => x.Recommendations)
                        .ToList();
                    _logger.LogDebug($"Recommendations count is - {recommendations.Count}");
                    string allowedContent = DecisionMaker.GetAllowedContent(words, recommendations);
                    if (string.IsNullOrEmpty(allowedContent))
                    {
                        //suggest user to decide allowed\forbidden and section
                    }
                    return new TextProcessorResult(AnswerMaker.GetPositiveAnswer(allowedContent), new DietReplyMarkup
                    {
                        keyboard = sections.Select(x => new List<string> { x.Name }).ToList(),
                        one_time_keyboard = true
                    });
                }
                return new TextProcessorResult(AnswerMaker.GetNegativeAnswer(forbiddenContent));
            }
            return new TextProcessorResult(AnswerMaker.GetOverallAnswer(section.AllowedDescription,
                section.ForbiddenDescription));
        }
    }
}