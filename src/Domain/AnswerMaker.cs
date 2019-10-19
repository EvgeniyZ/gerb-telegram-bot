namespace Gerb.Telegram.Bot.Domain
{
    public static class AnswerMaker
    {
        private const string Allowed = "Разрешается";
        private const string NotAllowed = "Нельзя.";
        private const string Forbidden = "Исключают из диеты";
        private const string Empty = "Пустое сообщение";
        private const string Positive = "Можно.";

        public static string GetEmptyAnswer()
        {
            return Empty;
        }

        public static string GetPositiveAnswer(string content)
        {
            return string.Join("\n", $"*{Positive}", content);
        }

        public static string GetNegativeAnswer(string content)
        {
            return string.Join("\n", $"*{NotAllowed}. {Forbidden}:", $"*{content}");
        }

        public static string GetOverallAnswer(string allowed, string forbidden)
        {
            return string.Join("\n", $"*{Allowed}:", $"*{allowed}", $"*{Forbidden}:", $"*{forbidden}");
        }
    }
}