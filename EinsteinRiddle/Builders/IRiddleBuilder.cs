using EinsteinRiddle.Riddles;

namespace EinsteinRiddle.Builders
{
    public interface IRiddleBuilder<TRiddle> where TRiddle : IRiddle
    {
        TRiddle Build();
    }
}