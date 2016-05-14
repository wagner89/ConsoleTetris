using Tetris.ScreenUtilities;
using static Tetris.ScreenUtilities.ConsoleManager;

namespace Tetris.Chrome.Tetrominoes
{
    public class Z : TetrominoBase
    {
        public override void Draw()
        {
            switch (Rotation)
            {
                case Rotation.None:
                    {
                        DrawSquare(TopLeft.X, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X + 2, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X - 2, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X, TopLeft.Y - 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        break;
                    }
                case Rotation.Deg90:
                    {
                        DrawSquare(TopLeft.X, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X, TopLeft.Y - 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X, TopLeft.Y + 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X + 2, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        break;
                    }
                case Rotation.Deg180:
                    {
                        DrawSquare(TopLeft.X, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X + 2, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X - 2, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X, TopLeft.Y + 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        break;
                    }
                case Rotation.Deg270:
                    {
                        DrawSquare(TopLeft.X, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X, TopLeft.Y - 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X, TopLeft.Y + 2, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        DrawSquare(TopLeft.X - 2, TopLeft.Y, 'O', ColorAttribute.GreenForegroundOnBlackBackground);
                        break;
                    }
            }
        }
    }
}