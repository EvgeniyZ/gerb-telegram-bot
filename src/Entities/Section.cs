using System.Collections.Generic;

namespace Gerb.Telegram.Bot.Entities
{
    public sealed class Section : BaseEntity
    {
        public string Name { get; set; }
        public string AllowedDescription { get; set; }
        public string ForbiddenDescription { get; set; }
        public ICollection<Restriction> Restrictions { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }
    }
}