using Telegram.Bot;

namespace Gerb.Telegram.Bot.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}