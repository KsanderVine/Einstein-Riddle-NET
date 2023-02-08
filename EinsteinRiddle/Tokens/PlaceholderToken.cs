namespace EinsteinRiddle.Tokens
{
    public class PlaceholderToken : IToken
    {
        public string PropertyKey { get; }
        public int EntityId { get; }

        public ModifierType Modifier { get; }
        public string Ending { get; }

        public PlaceholderToken(string propertyKey, int entityId, ModifierType modifier, string ending)
        {
            PropertyKey = propertyKey;
            EntityId = entityId;
            Modifier = modifier;
            Ending = ending;
        }
    }
}