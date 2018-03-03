using Microsoft.Extensions.DependencyInjection;

namespace Gerb.Telegram.Bot.DecisionMakers
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisionMakers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<StomachUclerDietDecisionMaker>();
        }
    }
}