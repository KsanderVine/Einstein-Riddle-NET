using EinsteinRiddle.Answers;

namespace EinsteinRiddle.Riddles
{
    public interface IRiddle
    {
        string GetDescription();
        bool IsAnswer(string answer);
    }
}