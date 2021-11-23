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
        WritingText("ReactGame\n\n", 0.1f, GenerateColor());

        string? userInput = Console.ReadLine();

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
            "Тебе русским языком сказали сука, введите Y или N, ты чё делаешь?", 0.1f);
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