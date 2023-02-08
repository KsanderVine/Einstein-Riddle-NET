namespace EinsteinRiddle.Answers
{
    public class WrongAnswer : IAnswer
    {
        public bool IsEqual(IAnswer answer) => false;
    }
}