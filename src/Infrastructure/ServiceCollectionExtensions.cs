using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gerb.Telegram.Bot.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DietContext>(options => options.UseNpgsql(connectionString));
        }
    }
}