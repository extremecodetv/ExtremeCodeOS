using System.Diagnostics;

namespace ReactGame.Core;

public class Game : Menu
{
    private Random _random;
    private int _goals;

    public Game()
    {
        _random = new Random();
    }

    /// <summary>
    /// Цикл отрисовки игры
    /// </summary>
    public override void Draw()
    {
        while (true)
        {
            if (!Update()) break;
        }
        
        // Exit logic
    }

    /// <summary>
    /// Отрисовывает один кадр игры
    /// </summary>
    /// <returns>Продолжать ли игру?</returns>
    private bool Update()
    {
        Console.Clear();

        int targetBlock = DrawSection();
        var stopWatch = new Stopwatch();

        stopWatch.Start();

        string? rawUserInput = Console.ReadLine();
        if (rawUserInput == "exit") return false;

        bool inputIsWrong = !int.TryParse(rawUserInput, out var userInput);

        stopWatch.Stop();

        if (stopWatch.ElapsedMilliseconds > 5000)
        {
            WriteText("Время вышло!");
            Thread.Sleep(1000);

            return true;
        }

        if (inputIsWrong || userInput != targetBlock)
        {
            WriteText("Неверный ответ");

            return true;
        }
            
        _goals++;

        return true;
    }

    /// <summary>
    /// Рисует секцию блоков
    /// </summary>
    /// <returns>Номер целевого блока слева направо</returns>
    private int DrawSection()
    {
        int leftCount = _random.Next(7);
        int rightCount = _random.Next(7);

        int targetBlock = -1;

        for (int i = 0; i <= leftCount; i++)
        {
            if (i == leftCount)
            {
                WriteText("* ", ConsoleColor.Yellow);

                targetBlock = leftCount + 1;
            }
            
            int symbol = _random.Next(2);

            switch (symbol)
            {
                case 0:
                    WriteText("= ");
                    break;
                case 1:
                    WriteText("+ ");
                    break;
                case 2:
                    WriteText("- ");
                    break;
            }
        }

        for (int i = 0; i <= rightCount; i++)
        {
            if (rightCount <= 0) break;

            int symbol = _random.Next(2);

            switch (symbol)
            {
                case 0:
                    WriteText("= ");
                    break;
                case 1:
                    WriteText("+ ");
                    break;
                case 2:
                    WriteText("- ");
                    break;
            }
        }

        Console.Write("\n\n");
        
        return targetBlock;
    }
}