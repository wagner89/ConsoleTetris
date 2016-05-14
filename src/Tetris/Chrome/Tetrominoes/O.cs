using Tetris.ScreenUtilities;
using static Tetris.ScreenUtilities.ConsoleManager;

namespace Tetris.Chrome.Tetrominoes
{
    public class O : TetrominoBase
    {
        public override void Draw()
        {
            DrawSquare(TopLeft.X, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
            DrawSquare(TopLeft.X + 2, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
            DrawSquare(TopLeft.X, TopLeft.Y + 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
            DrawSquare(TopLeft.X + 2, TopLeft.Y + 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
        }
    }
}