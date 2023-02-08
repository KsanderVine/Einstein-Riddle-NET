using EinsteinRiddle.Entities;

namespace EinsteinRiddle.Builders
{
    public interface IEntityBuilder<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetEntities(ITable<IProperty> propertyTable, bool shuffleProperties = true);
    }
}