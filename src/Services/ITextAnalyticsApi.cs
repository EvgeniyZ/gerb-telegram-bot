using System.Collections.Generic;

namespace Gerb.Telegram.Bot.Services
{
    public interface ITextAnalyticsApi
    {
        List<string> GetKeywords(string question);
    }
}