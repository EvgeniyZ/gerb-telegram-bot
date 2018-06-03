using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace Gerb.Telegram.Bot.Domain
{
    /// <summary>
    /// Look at https://core.telegram.org/bots/api#replykeyboardmarkup
    /// </summary>
    public sealed class DietReplyMarkup : IReplyMarkup
    {
        public List<List<string>> keyboard { get; set; }
        public bool resize_keyboard { get; set; }
        public bool one_time_keyboard { get; set; }
        public bool selective { get; set; }
    }
}