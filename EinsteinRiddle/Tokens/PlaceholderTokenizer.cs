using System.Text.RegularExpressions;

namespace EinsteinRiddle.Tokens
{
    public class PlaceholderTokenizer : ITokenizer<IToken>
    {
        private readonly Regex _regex = new(@"{(?:([\^!]):)?([A-za-z0-9]+):([0-9]+)(?:~(.*))?}");

        public IEnumerable<IToken> Tokenize(string text)
        {
            var tokens = new List<IToken>();
            var tokenizer = new RegexTokenizer(@"{?[^{}]+}?");
            var stringTokens = tokenizer.Tokenize(text);

            foreach (var selector in stringTokens.Select((token, i) => (i, token)))
            {
                Match match = _regex.Match(selector.token);
                if (match.Success)
                {
                    string propertyKey = match.Groups[2].Value;

                    int entityId = string.IsNullOrWhiteSpace(match.Groups[3].Value) ? 0 : int.Parse(match.Groups[3].Value);

                    ModifierType modifier = DetermineModifier(match.Groups[1].Value);

                    string ending = match.Groups[4].Value;

                    PlaceholderToken token = new(propertyKey, entityId, modifier, ending);
                    tokens.Add(token);
                }
                else
                {
                    tokens.Add(new SubstringToken(selector.token));
                }
            }

            return tokens;

            static ModifierType DetermineModifier(string value)
            {
                return value switch
                {
                    "!" => ModifierType.ToLowerFirst,
                    "^" => ModifierType.ToUpperFirst,
                    _ => ModifierType.None,
                };
            }
        }
    }
}