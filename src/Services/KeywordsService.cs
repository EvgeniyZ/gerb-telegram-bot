using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Gerb.Telegram.Bot.Services
{
    public class KeywordsService
    {
        private readonly IMemoryCache _cache;

        public KeywordsService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<List<string>> GetKeywords(string question)
        {
            var formattedQuestion = question.Trim().ToLower();
            if (!_cache.TryGetValue(question, out CachedAnswer cachedAnswer)) 
            {
                // call remote API to extract key phrases
                // save result to cache
                // send message to queue
            }
            return cachedAnswer.Keywords;
        }
    }
}