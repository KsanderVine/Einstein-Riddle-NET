namespace EinsteinRiddle.Answers
{
    public class AnswerReader : IAnswerReader
    {
        public IAnswer ReadFromString(string input)
        {
            return new Answer(input);
        }
    }
}