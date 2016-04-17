using ConsoleTetris.ScreenUtilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTetris
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleManager.SetConsoleToFullScreen();

            ConsoleManager.DrawBoder();
            ConsoleManager.Draw(236, 66, '#');

            Console.ReadKey();
        }
    }
}
