using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Domain;
using Gerb.Telegram.Bot.Domain.Entities;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.Infrastructure.Remote;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Gerb.Telegram.Bot.Services
{
    public class KeywordsService
    {
        private readonly IMemoryCache _cache;
        private readonly ITextProcessingApi _textProcessingApi;
        private readonly QuestionKeywordRx _questionKeywordRx;

        public KeywordsService(IMemoryCache cache, ITextProcessingApi textProcessingApi, QuestionKeywordRx questionKeywordRx)
        {
            _cache = cache;
            _textProcessingApi = textProcessingApi;
            _questionKeywordRx = questionKeywordRx;
        }

        public async Task<List<string>> GetKeywords(string question)
        {
            var formattedQuestion = question.Trim().ToLower();
            if (!_cache.TryGetValue(question, out List<string> keywords))
            {
                keywords = await _textProcessingApi.GetKeywords(question);
                _cache.Set(question, keywords);
                var questionKeyword = new QuestionKeyword
                {
                    Question = question,
                    Keywords = keywords
                };
                _questionKeywordRx.Receive(questionKeyword);
            }
            return keywords;
        }
    }
}