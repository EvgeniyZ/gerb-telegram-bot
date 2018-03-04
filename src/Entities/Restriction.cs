namespace Gerb.Telegram.Bot.Entities
{
    public sealed class Restriction : BaseEntity
    {
        public Section Section { get; set; }
        public Food Food { get; set; }
    }
}