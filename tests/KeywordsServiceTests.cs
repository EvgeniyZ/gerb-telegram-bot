using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Domain;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.Infrastructure.Remote;
using Gerb.Telegram.Bot.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Gerb.Unit.Tests
{
    public class KeywordsServiceTests
    {
        [Fact]
        public async Task GetKeywordsFromCache()
        {
            var question = "Можно ли мне есть мороженое?";
            var cache = new MemoryCache(new MemoryCacheOptions());
            cache.Set(question, new List<string> { "мороженое" });
            var mockTextProcessingApi = new Mock<ITextProcessingApi>();
            var keywordsService = new KeywordsService(cache, mockTextProcessingApi.Object, new QuestionKeywordRx());

            var keywords = await keywordsService.GetKeywords(question);

            Assert.Equal("мороженое", keywords.First());
        }

        [Fact]
        public async Task GetKeywordsFromCacheUpperMessage()
        {
            var question = "МОЖНО ЛИ МОРОЖЕНОЕ?";
            var cache = new MemoryCache(new MemoryCacheOptions());
            cache.Set(question, new List<string> { "мороженое" });
            var mockTextProcessingApi = new Mock<ITextProcessingApi>();
            var keywordsService = new KeywordsService(cache, mockTextProcessingApi.Object, new QuestionKeywordRx());

            var keywords = await keywordsService.GetKeywords(question);

            Assert.Equal("мороженое", keywords.First());
        }

        [Fact]
        public async Task GetKeywordsFromTextProcessingApi()
        {
            var question = "МОЖНО ЛИ МОРОЖЕНОЕ?";
            var cache = new MemoryCache(new MemoryCacheOptions());
            var mockTextProcessingApi = new Mock<ITextProcessingApi>();
            mockTextProcessingApi
                .Setup(x => x.GetKeywords(question))
                .ReturnsAsync(new List<string> { "мороженое" });
            var keywordsService = new KeywordsService(cache, mockTextProcessingApi.Object, new QuestionKeywordRx());

            var keywords = await keywordsService.GetKeywords(question);

            Assert.Equal("мороженое", keywords.First());
        }
    }
}