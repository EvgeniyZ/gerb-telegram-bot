using System.Collections.Generic;
using System.Linq;
using Gerb.Telegram.Bot.Entities;

namespace Gerb.Telegram.Bot.Infrastructure
{
    public static class ContextInitializer
    {
        public static void Initialize(StomachUnclerDietContext context)
        {
            if (context.Sections.Any() || context.Recomendations.Any())
            {
                return;
            }
            var sections = new Section[]
            {
                new Section
                {
                    Name = "ХЛЕБ И МУЧНЫЕ ИЗДЕЛИЯ",
                    AllowedDescription = "Хлеб пшеничный вчерашней выпечки или подсушенный; сухой бисквит, печенье сухое. 1-2 раза в неделю хорошо выпеченные несдобные булочки, печеные пирожки с яблоками, отварным мясом или рыбой и яйцами, джемом, ватрушка с творогом.",
                    ForbiddenDescription = "Ржаной и любой свежий хлеб, изделия из сдобного и слоёного теста.",
                    Recommendations = new List<Recommendation>
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
                                Name = "Ватрушка"
                            }
                        },
                    },
                    Restrictions = new List<Restriction>
                    {
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Ржаной хлеб"
                            }
                        },
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Наполеон"
                            }
                        },
                    }
                },
                new Section
                {
                    Name = "ПЛОДЫ, СЛАДКИЕ БЛЮДА, СЛАДОСТИ",
                    AllowedDescription = "В протёртом, варёном и печёном виде сладкие ягоды и фрукты. Пюре, кисели, муссы, желе, компоты, сливочный крем, молочный кисель. Сахар, мёд, некислое варенье, зефир, пастила.",
                    ForbiddenDescription = "Кислые, недостаточно спелые, богатые клетчаткой фрукты и ягоды, непротёртые сухофрукты, шоколад, мороженое.",
                    Recommendations = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Пастила"
                            },
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Зефир"
                            },
                        }
                    },
                    Restrictions = new List<Restriction>
                    {
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Шоколад",
                            }
                        },
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Мороженое",
                            }
                        },
                    },
                }
            };
            foreach (var section in sections)
            {
                foreach (var restriction in section.Restrictions)
                {
                    restriction.Section = section;
                }
                foreach (var recomendation in section.Recommendations)
                {
                    recomendation.Section = section;
                }
                context.Sections.Add(section);
            }
            context.SaveChanges();
        }
    }
}