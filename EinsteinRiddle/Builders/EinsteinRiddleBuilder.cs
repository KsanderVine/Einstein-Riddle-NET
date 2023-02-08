using EinsteinRiddle.Answers;
using EinsteinRiddle.Entities;
using EinsteinRiddle.Riddles;
using EinsteinRiddle.Templates;

namespace EinsteinRiddle.Builders
{
    public sealed class EinsteinRiddleBuilder : IRiddleBuilder<Riddle>
    {
        private ITemplate? DescriptionTemplate { get; set; }

        private ITemplate? AnswerTemplate { get; set; }
        private bool IsAnswerCaseSensitive { get; set; }

        private ITable<IProperty>? PropertyTable { get; set; }
        private bool IsShufflingEnabled { get; set; } = true;

        public EinsteinRiddleBuilder WithDescription(string description)
        {
            DescriptionTemplate = new Template(description);
            return this;
        }

        public EinsteinRiddleBuilder WithAnswer(string answer, bool isCaseSensitive = false)
        {
            IsAnswerCaseSensitive = isCaseSensitive;
            AnswerTemplate = new Template(answer);
            return this;
        }

        public EinsteinRiddleBuilder DefineProperty(string propertyKey, params string[] values)
        {
            if (PropertyTable is null)
                PropertyTable = new PropertyTable(values.Length);

            IProperty property = new Property(propertyKey);
            property.AddValues(values);

            PropertyTable.AddRow(property);
            return this;
        }

        public EinsteinRiddleBuilder DisableShuffling ()
        {
            IsShufflingEnabled = false;
            return this;
        }

        public Riddle Build()
        {
            if (AnswerTemplate is null)
                throw new NullReferenceException($"Answer can not be null");

            if (DescriptionTemplate is null)
                throw new NullReferenceException($"Description can not be null");

            if (PropertyTable is null)
                throw new NullReferenceException($"Properties can not be null");

            var entitites = new EntityBuilder()
                .GetEntities(PropertyTable, IsShufflingEnabled)
                .ToList();

            var description = DescriptionTemplate.MapEntities(entitites);
            var answer = new Answer(AnswerTemplate.MapEntities(entitites), IsAnswerCaseSensitive);

            return new Riddle(description, answer, new AnswerReader());
        }
    }
}