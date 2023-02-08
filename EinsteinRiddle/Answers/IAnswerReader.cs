namespace EinsteinRiddle.Answers
{
    public interface IAnswerReader
    {
        IAnswer ReadFromString(string input);
    }
}