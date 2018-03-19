namespace Gerb.Telegram.Bot.Domain 
{
    public static class AnswerMaker 
    {
        private const string Allowed = "Разрешается";
        private const string NotAllowed = "Нельзя.";
        private const string Forbidden = "Исключают из диеты";
        private const string Empty = "Пустое сообщение";
        public const string Positive = "Можно. Но лучше уточните в разделах диеты.";

        public static string GetEmptyAnswer() 
        {
            return Empty;
        }

        public static string GetPositiveAnswer() 
        {
            return Positive;
        }

        public static string GetNegativeAnswer(string content) 
        {
            return string.Join("\n", $"*{NotAllowed}. {Forbidden}:\n*{content}");
        }

        public static string GetOverallAnswer(string allowed, string forbidden) 
        {
            return string.Join("\n", $"*{Allowed}:\n*{allowed}",
                $"*{Forbidden}:\n*{forbidden}");
        }
    }
}