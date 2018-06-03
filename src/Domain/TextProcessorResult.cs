using Telegram.Bot.Types.ReplyMarkups;

namespace Gerb.Telegram.Bot.Domain
{
    public sealed class TextProcessorResult
    {
        public TextProcessorResult(string content, IReplyMarkup replyMarkup = null)
        {
            Content = content;
            ReplyMarkup = replyMarkup;
        }

        public string Content { get; set; }
        public IReplyMarkup ReplyMarkup { get; set; }
    }
}