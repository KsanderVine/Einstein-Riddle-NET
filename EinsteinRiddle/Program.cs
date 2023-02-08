using EinsteinRiddle.Answers;
using EinsteinRiddle.Entities;
using EinsteinRiddle.Riddles;
using EinsteinRiddle.Templates;

namespace EinsteinRiddle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProperty prop = new Property("Name");
            prop.AddValues(new List<string>() { "Лилия", "Роза" });

            IEntity entity = new Entity();
            entity.AddProperty(prop, 1);

            ITemplate template = new Template("Есть имя {Name:0} и {!:Name:0} как цветок");
            var val = template.MapEntities(new List<IEntity>() { entity });

            Console.WriteLine(val);

            return;

            while (true)
            {
                Console.WriteLine(
                    "Выберите одну из загадок: " +
                    "\n1) Простой пример загадки " +
                    "\n2) Загадка Эйнштейна " +
                    "\n3) Загадка Джиндоша (из Dishonored 2)");
                Console.WriteLine("(Для выбора введите номер)");

                var riddle = GetRiddle(Console.ReadLine());

                if (riddle == null)
                {
                    Console.Clear();
                    Console.WriteLine("Ни одна загадка не была выбрана...");
                    continue;
                }

                Console.WriteLine(riddle.GetDescription());

                while (true)
                {
                    Console.Write("Ответ: ");
                    var answer = Console.ReadLine() ?? String.Empty;

                    if (riddle.IsAnswer(answer))
                    {
                        Console.WriteLine("Правильный ответ!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Неправильный ответ... Попробуйте снова!");
                    }
                }
            }

            static IRiddle? GetRiddle(string? riddleNumber) => riddleNumber switch
            {
                "1" => ExampleRiddles.GetSimpleEinsteinLikeRiddle(),
                "2" => ExampleRiddles.GetEinsteinRiddle(),
                "3" => ExampleRiddles.GetJindoshRiddle(),
                _ => null,
            };
        }
    }
}