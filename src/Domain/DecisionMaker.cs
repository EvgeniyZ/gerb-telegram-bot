using System;
using System.Collections.Generic;
using System.Linq;
using Gerb.Telegram.Bot.Extensions;
using Gerb.Telegram.Bot.Domain.Entities;

namespace Gerb.Telegram.Bot.Domain
{
    public static class DecisionMaker
    {
        public static string GetForbiddenContent(List<string> words, List<Restriction> restrictions)
        {
            var forbiddenDescriptions = restrictions
                .Where(x => words.Any(word => x.Food.Name.Contains(word, StringComparison.OrdinalIgnoreCase)))
                .Select(x => x.Section.ForbiddenDescription);

            return forbiddenDescriptions.Any() ? string.Join(".", forbiddenDescriptions) : "";
        }

        public static string GetAllowedContent(List<string> words, List<Recommendation> recommendations) 
        {
            var allowedDescriptions = recommendations
                .Where(x => words.Any(word => x.Food.Name.Contains(word, StringComparison.OrdinalIgnoreCase)))
                .Select(x => x.Section.AllowedDescription);
            
            return allowedDescriptions.Any() ? string.Join(".", allowedDescriptions) : "";
        }
    }
}