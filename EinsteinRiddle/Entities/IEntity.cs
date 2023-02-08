namespace EinsteinRiddle.Entities
{
    public interface IEntity
    {
        string this[string key] { get; }
        void AddProperty(IProperty property, int valueId);
    }
}