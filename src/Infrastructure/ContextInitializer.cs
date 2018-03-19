using System.Collections.Generic;
using System.Linq;
using Gerb.Telegram.Bot.Domain.Entities;

namespace Gerb.Telegram.Bot.Infrastructure
{
    public static class ContextInitializer
    {
        public static void Initialize(StomachUnclerDietContext context)
        {
            context.Database.EnsureCreated();
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
                    Name = "СУПЫ",
                    AllowedDescription = "Из разрешённых протёртых овощей на морковном, картофельном отваре, молочные супы из протёртых или хорошо разваренных круп (геркулес, манная, рис и др.), вермишели с добавлением протёртых овощей, молочные супы-пюре из протёртых овощей; суп-пюре из заранее вываренных кур и мяса. Муку для супов только подсушивают. Супы заправляют сливочным маслом, яично-молочной смесью, сливками.",
                    ForbiddenDescription = "Мясные и рыбные бульоны, грибные и крепкие овощные отвары, щи, борщи, окрошку.",
                    Recommendations = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Вермишелевый"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Суп-пюре"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Сырный"
                            }
                        },
                    },
                    Restrictions = new List<Restriction>
                    {
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Щи"
                            }
                        },
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Борщ"
                            }
                        },
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Окрошка"
                            }
                        },
                    }
                },
                new Section
                {
                    Name = "МЯСО И ПТИЦА",
                    AllowedDescription = "Паровые и отварные блюда из языка, печени, нежирной телятины, говядины, молодой нежирной баранины и обрезной свинины, кур, индейки, кролика. Паровые котлеты, биточки, кнели, суфле, пюре, зразы; бефстроганов из варёного мяса.",
                    ForbiddenDescription = "Жирные или жилистые сорта мяса и птиц, утку, гуся, консервы, копчёности.",
                    Recommendations = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Говядина"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Курица"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Индейка"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Кролик"
                            }
                        },
                    },
                    Restrictions = new List<Restriction>
                    {
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Консервы"
                            }
                        },
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Копчённость"
                            }
                        }
                    }
                },
                new Section
                {
                    Name = "РЫБА",
                    AllowedDescription = "Нежирные виды без кожи, куском или в виде котлетной массы; варится в воде или на пару.",
                    ForbiddenDescription = "Жирную, солёную рыбу, консервы.",
                    Recommendations = new List<Recommendation>(),
                    Restrictions = new List<Restriction>(),
                },
                new Section
                {
                    Name = "МОЛОЧНЫЕ ПРОДУКТЫ",
                    AllowedDescription = "Молоко, сливки, некислый кефир, простокваша, ацидофилин, свежий некислый творог (протёртый). Творожные блюда: запечённые сырники, суфле, ленивые вареники, пудинги, неострый сыр.",
                    ForbiddenDescription = "Молочные продукты с высокой кислотностью, острые, солёные сыры. Ограничивают сметану.",
                    Recommendations = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Молоко"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Сливки"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Кефир"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Ацидофилин"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Суфле"
                            }
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Пудинг"
                            }
                        },
                    },
                    Restrictions = new List<Restriction>
                    {
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Сыр"
                            }
                        }
                    }
                },
                new Section
                {
                    Name = "ЯЙЦА",
                    AllowedDescription = "2-3 штуки в день. Всмятку, паровой омлет.",
                    ForbiddenDescription = "Яйца вкрутую, жареные.",
                    Recommendations = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Всмятку"
                            },
                        }
                    },
                    Restrictions = new List<Restriction>()
                },
                new Section
                {
                    Name = "КРУПЫ",
                    AllowedDescription = "Манная, гречневая, освяная, рис. Каши, сваренные на молоке или воде, полувязкие и протёртые. Вермишель, макароны отварные.",
                    ForbiddenDescription = "Пшено, перловую, ячневую, кукурузную крупу, бобовые.",
                    Recommendations = new List<Recommendation>
                    {
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Манная"
                            },
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Гречка"
                            },
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Овсяная"
                            },
                        },
                        new Recommendation
                        {
                            Food = new Food
                            {
                                Name = "Рис"
                            },
                        },
                    },
                    Restrictions = new List<Restriction>
                    {
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Пшенная"
                            },
                        },
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Перловка"
                            },
                        },
                        new Restriction
                        {
                            Food = new Food
                            {
                                Name = "Бобовые"
                            },
                        },
                    }
                },
                new Section
                {
                    Name = "ОВОЩИ",
                    AllowedDescription = "Картофель, морковь, свекла, цветная капуста, ограничено - зелёный горошек. Сваренные на пару или в воде и протёртые (пюре, суфле, паровые пудинги). Непротёртые ранние тыква и кабачки. Мелкошинкованный укроп - в супы. Спелые некислые томаты до 100г.",
                    ForbiddenDescription = "Белокочанную капусту, репу, брюкву, редьку, щавель, шпинат, лук, огурцы, солёные, квашенные  маринованные овощи, грибы, овощные закусочные консервы.",
                    Recommendations = new List<Recommendation>(),
                    Restrictions = new List<Restriction>()
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