using Microsoft.Extensions.DependencyInjection;

namespace Gerb.Telegram.Bot.MessageProcessors
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMessageProcessors(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<TextMessageProcessor>();
        }
    }
}