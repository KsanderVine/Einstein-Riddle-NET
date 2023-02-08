using EinsteinRiddle.Entities;
using EinsteinRiddle.Tokens;
using System.Text;

namespace EinsteinRiddle.Templates
{
    public class Template : ITemplate
    {
        private readonly List<IToken> _tokens;

        public Template(string text)
        {
            var tokenizer = new PlaceholderTokenizer();
            _tokens = new List<IToken>(tokenizer.Tokenize(text));
        }

        public string MapEntities(IEnumerable<IEntity> entities)
        {
            StringBuilder stringBuilder = new();

            foreach (var token in _tokens)
            {
                if (token is PlaceholderToken placeholder)
                {
                    if (entities.ElementAtOrDefault(placeholder.EntityId) is IEntity entity)
                    {
                        StringBuilder value = new(entity[placeholder.PropertyKey]);

                        value = ApplyModifier(value, placeholder.Modifier).Append(placeholder.Ending);

                        stringBuilder.Append(value);
                    }
                }
                else
                if (token is SubstringToken substring)
                {
                    stringBuilder.Append(substring.Value);
                }
            }

            return stringBuilder.ToString();

            static StringBuilder ApplyModifier(StringBuilder value, ModifierType modifier)
            {
                return modifier switch
                {
                    ModifierType.ToUpperFirst => ModifyFirstCharacter(value, true),
                    ModifierType.ToLowerFirst => ModifyFirstCharacter(value, false),
                    _ => value,
                };
            }

            static StringBuilder ModifyFirstCharacter(StringBuilder value, bool toUpper)
            {
                string firstChar = value[0].ToString();
                firstChar = toUpper ? firstChar.ToUpper() : firstChar.ToLower();
                return value.Remove(0, 1).Insert(0, firstChar);
            }
        }
    }
}