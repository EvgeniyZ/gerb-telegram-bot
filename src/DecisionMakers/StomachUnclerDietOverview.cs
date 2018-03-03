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
                AllowedDescription = "",
                ForbiddenDescription = ""
            };
        }
    }
}