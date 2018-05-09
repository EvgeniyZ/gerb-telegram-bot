using System.Collections.Generic;
using Gerb.Telegram.Bot.Services.Options;

namespace Gerb.Telegram.Bot.Services
{
    public class TextAnalyticsApi : ITextAnalyticsApi
    {
        private readonly string _url;
        private readonly string _key;
        public TextAnalyticsApi(TextAnalyticsApiOptions options)
        {
            _url = options.Url;
            _key = options.Key;
        }

        public List<string> GetKeywords(string question)
        {
            throw new System.NotImplementedException();
        }
    }
}