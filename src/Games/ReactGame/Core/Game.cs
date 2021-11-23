namespace ReactGame.Core;

public class Game : Menu
{
    private Random _random;

    public Game()
    {
        _random = new Random();
    }

    public override void Draw()
    {
        
    }

    private void Update()
    {
        Console.Clear();
        
        WritingText("ReactGame\n\n", 0.2f, ConsoleColor.Cyan);
        
        DrawSection();
    }

    private void DrawNumbers(int leftCount, int rightCount)
    {
        for (int i = 1; i <= leftCount + rightCount + 1; i++)
        {
            WriteText(i.ToString(), ConsoleColor.White);
        }
    }
    /// <summary>
    /// Рисует секцию блоков
    /// </summary>
    /// <returns>Номер целевого блока слева направо</returns>
    private int DrawSection()
    {
        int leftCount = _random.Next(10);
        int rightCount = _random.Next(10);

        DrawNumbers(leftCount, rightCount);
        
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
                    WriteText("=");
                    break;
                case 1:
                    WriteText("+");
                    break;
                case 2:
                    WriteText("-");
                    break;
            }
        }

        return targetBlock;
    }
}