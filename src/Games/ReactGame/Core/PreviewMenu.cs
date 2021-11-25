#pragma warning disable CS8794
namespace ReactGame.Core;

public class PreviewMenu : Menu
{
    private readonly Random _random;

    public PreviewMenu()
    {
        _random = new Random();
    }

    public override void Draw()
    {
        Console.Clear();
        
        WritingText("ReactGame\n\n", 0.05f, GenerateColor());

        if (Program.ShowsHelp)
        {
            ShowHelp();
        }
        
        AskForDifficulty();
        AskForStartGame();
    }

    private static void ShowHelp()
    {
        WritingText(
            "\nПомощь по игре:\n" +
            "Цель игры - назвать правильный порядковый номер жёлтой звезды слева направо.\n" +
            "Первый блок слева может быть звездой, а может быть космическим мусором. (Порядковый номер 1).\n" +
            "Космический мусор - серый, звезда - жёлтая.\n" +
            "Длина строки с блоками меняется рандомно и зависит от выбранной сложности.\n" +
            "Чтобы выключить отображение помощи при каждом запуске, запускайте игру с параметром: -nh | -NH | --no-help.\n" +
            "Нажмите любую кнопку, чтобы перейти к игре.", 0.075f, ConsoleColor.Yellow
        );

        Console.ReadKey();
        Console.Clear();
    }

    private static void AskForDifficulty()
    {
        string[] names = Enum.GetNames(typeof(Difficulty));

        for (int i = 1; i <= names.Length; i++)
        {
            WriteText($"{i}. {names[i - 1]}\n", ConsoleColor.Blue);
        }

        WriteText("Выберите номер сложности (от 1 до 6): ");

        string? userInput = Console.ReadLine();
        bool inputIsWrong = !int.TryParse(userInput, out var inputNumber);

        if (inputIsWrong) throw new NullReferenceException();

        if (inputNumber is not (1 or 2 or 3 or 4 or 5))
        {
            PoshlaNahui();
        }
        else
        {
            Program.Difficulty = (Difficulty)inputNumber;
        }
    }

    private static void AskForStartGame()
    {
        WriteText("Хотите начать игру (Y либо N)? ");

        string? userInput = Console.ReadLine();
        Console.Write("\n");

        switch (userInput)
        {
            case null:
                throw new NullReferenceException();
            case "n":
            case "N":
                NoNotAllowed();
                break;
            case "y":
            case "Y":
                Program.Game.Draw();
                break;
            default:
                PoshlaNahui();
                break;
        }
    }

    /// <summary>
    /// Генерирует рандомный цвет
    /// </summary>
    /// <returns>ConsoleColor</returns>
    private ConsoleColor GenerateColor()
        => (ConsoleColor)_random.Next(9, 15);

    /// <summary>
    /// Посылает тупую домохозяйку нахуй
    /// </summary>
    private static void PoshlaNahui()
    {
        Console.Clear();

        WritingText(
            "Тебе русским языком сказали сука, ты чё делаешь?", 0.1f);
        Thread.Sleep(1000);

        Environment.Exit(777);
    }

    private static void NoNotAllowed()
    {
        Console.Clear();

        WritingText("Всмысле блять нет? А зачем ты вообще её запустил?", 0.1f);
        Thread.Sleep(1000);

        Environment.Exit(228);
    }
}