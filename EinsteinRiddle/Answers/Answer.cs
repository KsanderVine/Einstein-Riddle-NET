namespace EinsteinRiddle.Answers
{
    public class Answer : IAnswer
    {
        public string Value { get; }
        private bool IsCaseSensitive { get; }

        public Answer(string value, bool isCaseSensitive = true)
        {
            Value = value;
            IsCaseSensitive = isCaseSensitive;
        }

        public bool IsEqual(IAnswer originalAnswer)
        {
            if (originalAnswer is Answer answer)
            {
                if (!IsCaseSensitive)
                {
                    return answer.Value.ToUpper().Equals(Value.ToUpper());
                } 
                else
                {
                    return answer.Value.Equals(Value);
                }
            }
            return false;
        }
    }
}