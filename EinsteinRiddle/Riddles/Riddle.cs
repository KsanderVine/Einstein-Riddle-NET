using EinsteinRiddle.Answers;

namespace EinsteinRiddle.Riddles
{
    public class Riddle : IRiddle
    {
        private readonly IAnswer _answer;
        private readonly IAnswerReader _reader;
        private readonly string _description;

        public Riddle(string description, IAnswer answer, IAnswerReader reader)
        {
            _answer = answer;
            _reader = reader;
            _description = description;
        }

        public string GetDescription()
        {
            return _description;
        }

        public bool IsAnswer(string answer)
        {
            return _answer.IsEqual(_reader.ReadFromString(answer));
        }
    }
}