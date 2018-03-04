using System.Collections.Generic;
using System.Linq;
using Gerb.Telegram.Bot.Entities;

namespace Gerb.Telegram.Bot.Infrastructure
{
    public static class ContextInitializer
    {
        public static void Initialize(StomachUnclerDietContext context)
        {
            if (context.Recomendations.Any())
            {
                return;
            }
            var sections = new List<Section>
            {
                new Section
                {
                    Title = "ХЛЕБ И МУЧНЫЕ ИЗДЕЛИЯ",
                    Recomendations = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Бисквит"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Печенье"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = ""
                            }
                        },
                    },
                    Restrictions = new List<Restriction>
                    {
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = ""
                            }
                        }
                    }
                }
            };
        }
    }
}