using Microsoft.Win32.SafeHandles;
using System;
using System.IO;

namespace ConsoleTetris.ScreenUtilities
{
    public static class ConsoleManager
    {
        private const byte WhiteForegroundOnBlackBackground = 0x0001 | 0x0002 | 0x0004;

        private static DllImports.CharInfo[] _screenBuffer;
        private static DllImports.SmallRect _screenRectangle;
        private static readonly SafeFileHandle StandardOutputHandle = DllImports.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

        public static void SetConsoleToFullScreen()
        {
            unchecked
            {
                var hConsole = DllImports.GetStdHandle(-11);
                DllImports.Coord xy;
                DllImports.SetConsoleDisplayMode(hConsole, 1, out xy);

                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            }
        }

        public static void HideCursor()
        {
            Console.CursorVisible = false;
        }

        public static void DrawToBuffer(int x, int y, char renderingChar)
        {
            if (_screenBuffer == null)
            {
                _screenBuffer = new DllImports.CharInfo[Console.WindowWidth * Console.WindowHeight];
                _screenRectangle = new DllImports.SmallRect() { Left = 0, Top = 0, Right = (short)Console.WindowWidth, Bottom = (short)Console.WindowHeight };
            }

            _screenBuffer[Console.WindowWidth * y + x].Attributes = WhiteForegroundOnBlackBackground;
            _screenBuffer[Console.WindowWidth * y + x].Char.AsciiChar = (byte)renderingChar;
        }

        public static void BlitBufferToScreen()
        {
            DllImports.WriteConsoleOutput(StandardOutputHandle, _screenBuffer,
                new DllImports.Coord() { X = (short)Console.WindowWidth, Y = (short)Console.WindowHeight },
                new DllImports.Coord() { X = 0, Y = 0 },
                ref _screenRectangle);
        }

        public static void DrawBoder()
        {
            for (var i = 0; i < Console.BufferWidth; i++)
            {
                DrawToBuffer(i, 0, '#');
                DrawToBuffer(i, Console.BufferHeight-1, '#');
            }

            for (var i = 0; i < Console.BufferHeight; i++)
            {
                DrawToBuffer(0, i, '#');
                DrawToBuffer(Console.BufferWidth-1, i, '#');
            }

            BlitBufferToScreen();
        }
    }
}