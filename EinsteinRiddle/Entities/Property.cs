using System.Collections;

namespace EinsteinRiddle.Entities
{
    public class Property : IProperty
    {
        public string this[int index]
        {
            get
            {
                if (Values.ElementAtOrDefault(index) is string value)
                {
                    return value;
                }
                return string.Empty;
            }
        }

        public string Key { get; }

        public int Count => Values.Count;

        private List<string> Values { get; } = new List<string>();

        public Property(string key) => Key = key;

        public void AddValues(IEnumerable<string> values)
        {
            Values.AddRange(values);
        }

        public IEnumerator<string> GetEnumerator() => Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Values.GetEnumerator();
    }
}