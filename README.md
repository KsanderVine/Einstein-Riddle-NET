# Загадка Эйнштейна
Моё представление о реализация загадки Эйнштейна на C# с настраиваемыми параметрами, подставляемыми в шаблон. Подробнее о самой загадке Эйнштейна можно прочитать в [Википедии](https://ru.wikipedia.org/wiki/%D0%97%D0%B0%D0%B3%D0%B0%D0%B4%D0%BA%D0%B0_%D0%AD%D0%B9%D0%BD%D1%88%D1%82%D0%B5%D0%B9%D0%BD%D0%B0 "Страница в Википедии").

## Примеры
Для демонстрации подготовлены три примера загадок, каждый из которых имеет разный текст, используемые свойства и ответ. Код их конфигурации содержится в файле **ExampleRiddles.cs**, но если вы желаете проверить себя и решить эти загадки - советую сначала запустить приложение.

## Построение загадки
Каждая загадка состоит из трех компонентов: описания (description), свойств (properties) и ответа (answer). Внутри описания и ответа есть поддержка плейсхолдеров, которые в момент построения загадки заменяются конкретными значениями. По умолчанию эти значения перемешиваются, поэтому результат генерации загадки из этого примера будет недетерменирован (если не раскомментировать DisableShuffling).

```csharp
var riddle = new EinsteinRiddleBuilder()
                .WithDescription("This is placeholder for {Name:0}, and this is for {Name:1}")
                .WithAnswer("{Name:0}")
                .DefineProperty("Name", "Tom", "Garry")
                //.DisableShuffling() //<< Для отключения перемешивания
                .Build();
```

## Дальнейшие действия
После построения загадки все плейсхолдеры заменяются конкретными значениями. Зафиксированный текст загадки можно получить функцией GetDescription, а проверить ответ функцией IsAnswer.

```csharp
var description = riddle.GetDescription();
// This is placeholder for Tom, and this is for Garry
var answer = Console.ReadLine(); // Garry
var isCorrectAnswer = riddle.IsAnswer(answer); // FALSE
```

В данной реализации для определения корректного ответа сравниваются две строки: ожидаемая, которая была указана при конфигурации строителя, и та, которую ввел пользователь. Так как при конфигурации был задан плейсхолдер **{Name:0}** - правильным ответом будет являться **первое имя** из текста этой загадки.

## Немного о плейсхолдерах
Плейсхолдер состоит из двух обязательных и двух опциональных частей:
- **Модификатор** - опциональный - определяет модификацию при размещении конкретного значения. Имеет три возможных типа:
	- Без модификации
	- ^ - модификация первой буквы в заглавную.
	- ! - модификация первой буквы в строчную.
- **Ключ свойства** - обязательный - определяет, какое свойство будет использовано при выборе конкретного значения.
- **Индекс значения** - обязательный - определяет, какая версия значения свойства будет использована при выборе конкретного значения.
- **Окончание** - опциональный - добавляет фиксированное окончание при размещении конкретного значения (начинается с символа ~).

#### Полный плейсхолдер имеет следующий синтаксис:
{([^!]:)([propertyKey]):([valueIndex])(~[ending])}

#### Пример 1
Допустим, что в свойстве **Pet** определены два варианта значения: *собак* и *кошк*. При замене плейсхолдеров на конкретное значение свойства **Pet** произойдет следующее:

|  Текст загадки с плейсхолдером  | После построения загадки |
| ------------ | ------------ |
| **{^:Pet:0~а}** бывает кусачей | **Собака** бывает кусачей |
| **{^:Pet:1~а}** бывает кусачей | **Кошка** бывает кусачей |

#### Пример 2
Допустим, что в свойстве **Name** определены два варианта значения: *Лилия* и *Роза*. При замене плейсхолдеров на конкретное значение свойства **Name** произойдет следующее:

|  Текст загадки с плейсхолдером  | После построения загадки |
| ------------ | ------------ |
| Есть имя **{Name:0}** и **{!:Name:0}** цветок  | Есть имя **Лилия** и **лилия** цветок |
| Есть имя **{Name:1}** и **{!:Name:1}** цветок | Есть имя **Роза** и **роза** цветок |

## Послесловие
Эта система была создана под вдохновением от игры Dishonored 2, где использовался этот вид загадки (пример которой есть в ExampleRiddles.cs). Если вдруг у вас появятся свои идеи загадок и вы захотите разместить их в ExampleRiddles в этом репозитории - свяжитесь со мной. Никаких запретов по использованию - веселитесь.
