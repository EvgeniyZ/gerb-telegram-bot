using System.Collections.Generic;

namespace Gerb.Telegram.Bot.DecisionMakers
{
    public class StomachUclerDietDesicionMaker
    {
        private readonly List<string> _forbiddenKeywords = new List<string> { "шоколад", "мороженое", "ржаной хлеб", "свежий хлеб", "chocolate", "ice cream", "rye bread", "fresh bread" };

        public bool IsAllowed(string food)
        {
            if (string.IsNullOrEmpty(food))
            {
                return true;
            }
            return !_forbiddenKeywords.Contains(food.ToLower());
        }
    }
}