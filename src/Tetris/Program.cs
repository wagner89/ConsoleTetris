using System;
using Tetris.Chrome;
using Tetris.ScreenUtilities;

namespace Tetris
{
    internal class Program
    {
        private static void Main()
        {
            ConsoleManager.SetConsoleToFullScreen();
            ConsoleManager.HideCursor();

            ChromePresenter.DrawGameArea();

            Console.ReadKey();
        }
    }
}
