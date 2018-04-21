using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class KeywordsServiceTests
    {
        [Fact]
        public async Task GetKeywordsFromMessage()
        {
            var question = "Можно ли мне есть мороженое?";
            var cache = new MemoryCache(new MemoryCacheOptions());
            cache.Set(question, new CachedAnswer
            {
                Question = question,
                Keywords = new List<string> { "мороженое" }
            });
            var keywordsService = new KeywordsService(cache);

            var keywords = await keywordsService.GetKeywords(question);

            Assert.Equal("мороженое", keywords.First());
        }

        [Fact]
        public async Task GetKeywordsFromUpperMessage()
        {
            var question = "МОЖНО ЛИ МОРОЖЕНОЕ?";
            var cache = new MemoryCache(new MemoryCacheOptions());
            cache.Set(question, new CachedAnswer
            {
                Question = question,
                Keywords = new List<string> { "мороженое" }
            });
            var keywordsService = new KeywordsService(cache);

            var keywords = await keywordsService.GetKeywords(question);

            Assert.Equal("мороженое", keywords.First());
        }
    }
}