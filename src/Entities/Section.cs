using System.Collections.Generic;

namespace Gerb.Telegram.Bot.Entities
{
    public sealed class Section : BaseEntity
    {
        public string Title { get; set; }
        public string AllowedDescription { get; set; }
        public string ForbiddenDescription { get; set; }
        public IEnumerable<Restriction> Restrictions { get; set; }
        public IEnumerable<Recommendation> Recomendations { get; set; }
    }
}