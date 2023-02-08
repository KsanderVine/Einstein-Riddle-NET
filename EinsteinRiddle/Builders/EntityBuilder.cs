using EinsteinRiddle.Entities;

namespace EinsteinRiddle.Builders
{
    public sealed class EntityBuilder : IEntityBuilder<Entity>
    {
        private static readonly Random _random = new();

        public IEnumerable<Entity> GetEntities(ITable<IProperty> propertyTable, bool shuffleProperties = true)
        {
            List<Entity> entities = new();

            for (int i = 0; i < propertyTable.ColumnsCount; i++)
                entities.Add(new Entity());

            foreach (IProperty property in propertyTable)
            {
                var indices = GetIndices(propertyTable.ColumnsCount, shuffleProperties);

                foreach (var selector in entities.Select((entity, index) => (index, entity)))
                {
                    var valueId = indices.ElementAt(selector.index);
                    selector.entity.AddProperty(property, valueId);
                }
            }

            return entities;
        }

        private static IEnumerable<int> GetIndices(int length, bool withShuffling = true)
        {
            if (withShuffling)
                return new int[length]
                    .Select((x, i) => i)
                    .OrderBy(x => _random.Next(0, 100) > 50)
                    .ToList();
            else
                return new int[length]
                    .Select((x, i) => i)
                    .ToList();

        }
    }
}