namespace EinsteinRiddle.Entities
{
    public sealed class Entity : IEntity
    {
        public string this[string key]
        {
            get
            {
                return Bindings
                    .FirstOrDefault(b => b.Property.Key.Equals(key))?
                    .ToString() ?? string.Empty;
            }
        }

        private List<PropertyBinding> Bindings { get; } = new List<PropertyBinding>();

        public void AddProperty(IProperty property, int valueId)
        {
            Bindings.Add(new PropertyBinding(property, valueId));
        }

        private class PropertyBinding
        {
            public IProperty Property { get; }
            public int ValueId { get; }

            public PropertyBinding(IProperty property, int valueId)
            {
                Property = property;
                ValueId = valueId;
            }

            public override string ToString()
            {
                return Property[ValueId];
            }
        }
    }
}