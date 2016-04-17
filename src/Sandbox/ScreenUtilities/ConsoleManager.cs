using Microsoft.Win32.SafeHandles;
using System;
using System.IO;

namespace ConsoleTetris.ScreenUtilities
{
    public static class ConsoleManager
    {
        public static void SetConsoleToFullScreen()
        {
            unchecked
            {
                IntPtr hConsole = DllImports.GetStdHandle(-11);
                DllImports.COORD xy = new DllImports.COORD(100, 100);
                DllImports.SetConsoleDisplayMode(hConsole, 1, out xy);

                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            }
        }

        public static void Draw(int x, int y, char renderingChar)
        {
            // The handle to the output buffer of the console
            SafeFileHandle consoleHandle = DllImports.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            // Draw with this native method because this method does NOT move the cursor.
            int n = 0;
            DllImports.WriteConsoleOutputCharacter(consoleHandle, renderingChar.ToString(), 1, new DllImports.COORD((short)x, (short)y), ref n);
        }

        public static void DrawBoder()
        {
            for (var i = 0; i < Console.BufferWidth; i++)
            {
                Draw(i, 0, '#');
                Draw(i, Console.BufferHeight-1, '#');
            }

            for (var i = 0; i < Console.BufferHeight; i++)
            {
                Draw(0, i, '#');
                Draw(Console.BufferWidth-1, i, '#');
            }

        }
    }
}