using System.Collections.Generic;

namespace Gerb.Telegram.Bot.Services
{
    public class CachedAnswer
    {
        public string Question { get; set; }
        public List<string> Keywords { get; set; }
    }
}