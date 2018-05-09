using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gerb.Telegram.Bot.Services;
using Gerb.Telegram.Bot.Infrastructure;
using Gerb.Telegram.Bot.MessageProcessors;
using System;

namespace Gerb.Telegram.Bot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddServices();
            services.AddTextAnalysisApi(Environment.GetEnvironmentVariable("TextAnalysisAPIUrl"), Environment.GetEnvironmentVariable("TextAnalysisAPIKey"));
            services.AddInfrastructure(Configuration.GetConnectionString("Gerb"));
            services.AddMessageProcessors();

            services.Configure<BotConfiguration>(Configuration.GetSection("BotConfiguration"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
