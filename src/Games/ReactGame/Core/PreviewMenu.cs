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

        if (userInput == null) throw new NullReferenceException();
        if (userInput is not ("y" and "Y" and "n" and "N")) PoshlaNahui();
        if (userInput is not ("n" and "N")) Program.Game.Draw();
        
        NoNotAllowed();
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