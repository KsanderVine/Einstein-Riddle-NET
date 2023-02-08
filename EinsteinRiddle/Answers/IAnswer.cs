namespace EinsteinRiddle.Answers
{
    public interface IAnswer
    {
        bool IsEqual(IAnswer answer);
    }
}