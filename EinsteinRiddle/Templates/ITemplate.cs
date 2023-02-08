using EinsteinRiddle.Entities;

namespace EinsteinRiddle.Templates
{
    public interface ITemplate
    {
        string MapEntities(IEnumerable<IEntity> entities);
    }
}