namespace Gerb.Telegram.Bot.Entities
{
    public sealed class DietAnswer
    {
        public DietAnswer(bool isAllowed, string details)
        {
            IsAllowed = isAllowed;
            Details = details;
        }

        public bool IsAllowed { get; set; }
        public string Details { get; set; }
    }
}