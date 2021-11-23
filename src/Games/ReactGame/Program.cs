using System.Runtime.CompilerServices;
using ReactGame.Core;
// ReSharper disable InconsistentNaming
#pragma warning disable CS8618

namespace ReactGame;

public static class Program
{
    public static PreviewMenu PreviewMenu;
    public static Game Game;

    public static void Main()
    {
        PreviewMenu = new PreviewMenu();
        Game = new Game();

        PreviewMenu.Draw();
    }
}