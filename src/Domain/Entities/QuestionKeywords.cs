using System.Collections.Generic;

namespace Gerb.Telegram.Bot.Domain.Entities
{
    public class QuestionKeywords
    {
        public string Question { get; set; }
        public List<string> Keywords { get; set; }
    }
}