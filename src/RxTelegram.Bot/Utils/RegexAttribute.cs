using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RxTelegram.Bot.Utils
{
    internal class RegexAttribute : Attribute
    {
        private readonly string[] _regex;

        public RegexAttribute(params string[] regex) => _regex = regex;

        public bool Match(string description) => _regex?.Any(x => Regex.IsMatch(description, x)) == true;
    }
}
