namespace EinsteinRiddle.Tokens
{
    public class SubstringToken : IToken
    {
        public string Value { get; }

        public SubstringToken(string value)
        {
            Value = value;
        }
    }
}