using System;
using System.Text.RegularExpressions;

namespace Gerb.Telegram.Bot.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static bool Contains(this string source, string value, StringComparison comparison)
        {
            return source?.IndexOf(value, comparison) >= 0;
        }
    }
}
