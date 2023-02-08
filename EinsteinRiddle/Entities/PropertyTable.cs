using System.Collections;

namespace EinsteinRiddle.Entities
{
    public class PropertyTable : ITable<IProperty>
    {
        public int ColumnsCount { get; }
        public int RowsCount => Properties.Count;

        private List<IProperty> Properties { get; }

        public PropertyTable(int valuesLength)
        {
            ColumnsCount = valuesLength;
            Properties = new List<IProperty>();
        }

        public void AddRow(IProperty property)
        {
            if (property is null)
            {
                throw new NullReferenceException($"Value of {nameof(property)} can not be null");
            }

            if (Properties.FirstOrDefault(p => p.Key == property.Key) != null)
            {
                throw new ArgumentException($"An property with Key = \"{nameof(property.Key)}\" already exists.");
            }

            if (property.Count() != ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(property), property.Count(),
                    $"Table definition expecting length of {ColumnsCount} values for each property");
            }

            Properties.Add(property);
        }

        public IEnumerator<IProperty> GetEnumerator() => Properties.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Properties.GetEnumerator();
    }
}