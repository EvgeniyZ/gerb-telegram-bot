using System;
using System.Collections.Generic;
using Gerb.Telegram.Bot.Entities;

namespace Gerb.Telegram.Bot.DecisionMakers
{
    public class StomachUclerDietDecisionMaker
    {
        private static readonly Dictionary<string, string> _forbiddenFoodsDictionary = new Dictionary<string, string>
        {
            { "шоколад", "Шоколад исключен из диеты. Из сладкого можно сахар, мёд, некислое варенье, зефир, пастила." },
            { "мороженое", "Мороженое исключено из диеты. Из сладкого можно сахар, мёд, некислое варенье, зефир, пастила." },
            { "морожен", "Мороженое исключено из диеты. Из сладкого можно сахар, мёд, некислое варенье, зефир, пастила." },
            { "хлеб", "Ржаной и любой свежий хлеб, изделия из сдобного и слоёного теста исключены из диеты." },
            { "консервы", "Ржаной и любой свежий хлеб, изделия из сдобного и слоёного теста исключены из диеты." },
            { "копчености", "Исключают копчености, жирные или жилистые сорта мяса и птиц, утку, гуся, консервы." },
            { "сметана", "Следует ограничить употребление сметаны." },
        };

        public DietAnswer IsAllowed(string food)
        {
            if (_forbiddenFoodsDictionary.ContainsKey(food))
            {
                return new DietAnswer(false, _forbiddenFoodsDictionary[food]);
            }
            return new DietAnswer(true, "");
        }
    }
}