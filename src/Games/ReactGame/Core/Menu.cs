namespace ReactGame.Core;

public abstract class Menu
{
    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public abstract void Draw();

    /// <summary>
    /// Выводит цветной текст
    /// </summary>
    /// <param name="text">Выводимый текст</param>
    /// <param name="color">Используемый цвет</param>
    private protected static void WriteText(
        string text, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.Write(text);

        Console.ForegroundColor = ConsoleColor.Gray;
    }

    /// <summary>
    /// Посимвольно выводит цветной текст
    /// </summary>
    /// <param name="text">Выводимый текст</param>
    /// <param name="delay">Интервал между выводом 1 символа</param>
    /// <param name="color">Используемый цвет</param>
    private protected static void WritingText(
        string text, float delay, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;

        foreach (var character in text)
        {
            Console.Write(character);
            Thread.Sleep((int) (delay * 1000));
        }

        Console.ForegroundColor = ConsoleColor.Gray;
    }
}