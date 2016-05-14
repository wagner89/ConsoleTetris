using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using static Tetris.ScreenUtilities.DllImports;

namespace Tetris.ScreenUtilities
{
    public static class ConsoleManager
    {
        private static CharInfo[] _screenBuffer;
        private static SmallRect _screenRectangle;
        private static readonly SafeFileHandle StandardOutputHandle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

        public static void SetConsoleToFullScreen()
        {
            unchecked
            {
                var hConsole = GetStdHandle(-11);
                Coord xy;
                SetConsoleDisplayMode(hConsole, 1, out xy);

                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            }
        }

        public static void HideCursor()
        {
            Console.CursorVisible = false;
        }

        public static void DrawCharToBuffer(int x, int y, char renderingChar)
        {
            if (_screenBuffer == null)
            {
                _screenBuffer = new CharInfo[Console.WindowWidth * Console.WindowHeight];
                _screenRectangle = new SmallRect() { Left = 0, Top = 0, Right = (short)Console.WindowWidth, Bottom = (short)Console.WindowHeight };
            }

            _screenBuffer[Console.WindowWidth * y + x].Attributes = ColorAttribute.WhiteForegroundOnBlackBackground;
            _screenBuffer[Console.WindowWidth * y + x].Char.AsciiChar = (byte)renderingChar;
        }

        public static void DrawCharToBuffer(int x, int y, char renderingChar, byte charInfo)
        {
            if (_screenBuffer == null)
            {
                _screenBuffer = new CharInfo[Console.WindowWidth * Console.WindowHeight];
                _screenRectangle = new SmallRect() { Left = 0, Top = 0, Right = (short)Console.WindowWidth, Bottom = (short)Console.WindowHeight };
            }

            _screenBuffer[Console.WindowWidth * y + x].Attributes = charInfo;
            _screenBuffer[Console.WindowWidth * y + x].Char.AsciiChar = (byte)renderingChar;
        }

        public static void DrawHorizontalLineToBuffer(int startX, int endX, int y, char renderingChar)
        {
            for (var i = startX; i <= endX; i++) ConsoleManager.DrawCharToBuffer(i, y, '#');
        }

        public static void DrawVerticalLineToBuffer(int startY, int endY, int x, char renderingChar)
        {
            for (var i = startY; i <= endY; i++) ConsoleManager.DrawCharToBuffer(x, i, '#');
        }

        public static void BlitBufferToScreen()
        {
            DllImports.WriteConsoleOutput(StandardOutputHandle, _screenBuffer,
                new Coord() { X = (short)Console.WindowWidth, Y = (short)Console.WindowHeight },
                new Coord() { X = 0, Y = 0 },
                ref _screenRectangle);
        }

        public static void DrawBoder()
        {
            for (var i = 0; i < Console.BufferWidth; i++)
            {
                DrawCharToBuffer(i, 0, '#');
                DrawCharToBuffer(i, Console.BufferHeight - 1, '#');
            }

            for (var i = 0; i < Console.BufferHeight; i++)
            {
                DrawCharToBuffer(0, i, '#');
                DrawCharToBuffer(Console.BufferWidth - 1, i, '#');
            }

            BlitBufferToScreen();
        }

        public static void DrawSquare(int upperLeftX, int upperLeftY, char renderingChar, byte color)
        {
            DrawCharToBuffer(upperLeftX, upperLeftY, renderingChar, color);
            DrawCharToBuffer(upperLeftX + 1, upperLeftY, renderingChar, color);
            DrawCharToBuffer(upperLeftX, upperLeftY + 1, renderingChar, color);
            DrawCharToBuffer(upperLeftX + 1, upperLeftY + 1, renderingChar, color);
        }
    }
}