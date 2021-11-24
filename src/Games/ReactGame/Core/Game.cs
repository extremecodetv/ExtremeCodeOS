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
    /// Бесконечный цикл отрисовки кадров
    /// </summary>
    public override void Draw()
    {
        while (true)
        {
            Console.Clear();

            int targetBlock = DrawSection();
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            string? userInput = Console.ReadLine();
            int.TryParse(userInput, out var inputNumber);
            
            if (userInput == "exit")
            {
                WriteText("\nВыход из игры...", ConsoleColor.Yellow);
                Thread.Sleep(1000);

                break;
            }

            stopWatch.Stop();

            if (stopWatch.ElapsedMilliseconds > 5000 / ((int)Program.Difficulty / 2))
            {
                WriteText("\nВремя вышло!", ConsoleColor.Red);
                Thread.Sleep(1000);

                break;
            }

            if (inputNumber != targetBlock)
            {
                WriteText("\nНеверный ответ", ConsoleColor.Red);
                Thread.Sleep(1000);

                break;
            }

            _goals++;
        }
    }

    /// <summary>
    /// Рисует секцию блоков
    /// </summary>
    /// <returns>Номер целевого блока слева направо</returns>
    private int DrawSection()
    {
        int leftCount = _random.Next(4 * (int) Program.Difficulty);
        int rightCount = _random.Next(4 * (int) Program.Difficulty);

        int targetBlock = -1;

        WriteText($"Текущее количество очков: {_goals}.\n", ConsoleColor.Blue);
        
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