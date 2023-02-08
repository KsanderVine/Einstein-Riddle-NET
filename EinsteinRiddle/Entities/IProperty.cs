namespace EinsteinRiddle.Entities
{
    public interface IProperty : IEnumerable<string>
    {
        string this[int index] { get; }
        string Key { get; }
        void AddValues(IEnumerable<string> values);
    }
}