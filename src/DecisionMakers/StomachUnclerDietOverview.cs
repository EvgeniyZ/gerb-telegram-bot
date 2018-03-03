using System;
using Gerb.Telegram.Bot.Entities;

namespace Gerb.Telegram.Bot.DecisionMakers
{
    public sealed class StomachUnclerDietOverview
    {
        public DietOverview GetOverview(string name)
        {
            return new DietOverview
            {
                Name = name,
                AllowedDescription = "Хлеб пшеничный вчерашней выпечки или подсушенный; сухой бисквит, печенье сухое. 1-2 раза в неделю хорошо выпеченные несдобные булочки, печеные пирожки с яблоками, отварным мясом или рыбой и яйцами, джемом, ватрушка с творогом.",
                ForbiddenDescription = "Ржаной и любой свежий хлеб, изделия из сдобного и слоёного теста."
            };
        }
    }
}