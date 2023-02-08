namespace EinsteinRiddle.Tokens
{
    public interface ITokenizer<TType>
    {
        IEnumerable<TType> Tokenize(string text);
    }
}