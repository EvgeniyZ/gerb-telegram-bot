using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Domain.Entities;
using Gerb.Telegram.Bot.Infrastructure.Remote;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Gerb.Telegram.Bot.Services
{
    public class KeywordsService
    {
        private readonly IMemoryCache _cache;
        private readonly ITextProcessingApi _textProcessingApi;

        public KeywordsService(IMemoryCache cache, ITextProcessingApi textProcessingApi)
        {
            _cache = cache;
            _textProcessingApi = textProcessingApi;
        }

        public async Task<List<string>> GetKeywords(string question)
        {
            var formattedQuestion = question.Trim().ToLower();
            if (!_cache.TryGetValue(question, out List<string> keywords))
            {
                keywords = await _textProcessingApi.GetKeywords(question);
                _cache.Set(question, keywords);
                // send message to queue
            }
            return keywords;
        }
    }
}