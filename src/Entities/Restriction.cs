namespace Gerb.Telegram.Bot.Entities
{
    public sealed class Restriction : BaseEntity
    {
        public Section Group { get; set; }
        public Food Food { get; set; }
    }
}