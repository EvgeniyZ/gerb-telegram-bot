using Gerb.Telegram.Bot.Services.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Gerb.Telegram.Bot.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBotService, BotService>();
            serviceCollection.AddScoped<IUpdateService, UpdateService>();
            serviceCollection.AddScoped<KeywordsService>();
            serviceCollection.AddSingleton<QuestionKeywordsHandler>();
            serviceCollection.AddScoped<TextMessageProcessor>();
        }

        public static void AddTextAnalysisApi(this IServiceCollection serviceCollection, string url, string apiKey)
        {
            serviceCollection.Configure<TextAnalyticsApiOptions>(options => {
                options.Url = url;
                options.Key = apiKey;
            });
            serviceCollection.AddScoped<ITextAnalyticsApi, TextAnalyticsApi>();
        }
    }
}