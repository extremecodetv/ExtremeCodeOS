using System.Runtime.CompilerServices;
using ReactGame.Core;
// ReSharper disable InconsistentNaming
#pragma warning disable CS8618

namespace ReactGame;

public static class Program
{
    private static PreviewMenu PreviewMenu;
    public static Game Game;
    public static Difficulty Difficulty;
    public static bool ShowsHelp;

    public static void Main(string[] args)
    {
        CheckForParams(args);
        
        PreviewMenu = new PreviewMenu();
        Game = new Game();

        PreviewMenu.Draw();
    }

    private static void CheckForParams(string[] args)
    {
        if (args == null)
        {
            throw new ArgumentNullException();
        }
        
        if (args.Any(param => param is "-nh" or "-NH" or "--no-help"))
        {
            ShowsHelp = false;
            return;
        }

        ShowsHelp = true;
    }
}