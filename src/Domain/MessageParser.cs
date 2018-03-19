using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Gerb.Telegram.Bot.Domain
{
    public static class MessageParser 
    {
        private const string _invalidRussianCharacters = "[^а-яА-Я]";
        private const string _specialCharacters = "[,.?!]";

        public static List<string> GetWords(string message)
        {
            var words = Regex.Replace(message, _specialCharacters, " ")
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return words
                .Select(x => Regex.Replace(x, _invalidRussianCharacters, "")
                                  .Trim()
                                  .ToLower())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
        }
    }
}