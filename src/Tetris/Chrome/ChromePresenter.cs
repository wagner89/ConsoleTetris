using System;
using System.Drawing;
using Tetris.Chrome.Tetrominoes;
using Tetris.ScreenUtilities;

namespace Tetris.Chrome
{
    public class ChromePresenter
    {
        public static void DrawGameArea()
        {
            var centerScreenX = Console.WindowWidth / 2;
            var centerScreenY = Console.WindowHeight / 2;

            var startX = centerScreenX - 20;
            var endX = centerScreenX + 21;

            var startY = centerScreenY - 20;
            var endY = centerScreenY + 21;

            ConsoleManager.DrawHorizontalLineToBuffer(startX, endX, startY, '#');
            ConsoleManager.DrawHorizontalLineToBuffer(startX, endX, endY, '#');

            ConsoleManager.DrawVerticalLineToBuffer(startY, endY, startX, '#');
            ConsoleManager.DrawVerticalLineToBuffer(startY, endY, endX, '#');

            var o = new O { TopLeft = new Point(centerScreenX, centerScreenY), Rotation = Rotation.None };
            o.Draw();

            ConsoleManager.BlitBufferToScreen();
        }
    }
}