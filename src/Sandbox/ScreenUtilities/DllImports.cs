using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsoleTetris.ScreenUtilities
{
    /// <summary>
    /// Contains native methods imported as unmanaged code.
    /// </summary>
    internal static class DllImports
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;

            public COORD(short x, short y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(int handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteConsoleOutputCharacter(SafeFileHandle hConsoleOutput, string lpCharacter, int nLength, COORD dwWriteCoord, ref int lpumberOfCharsWritten);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern SafeFileHandle CreateFile(string fileName,
                                                        [MarshalAs(UnmanagedType.U4)] uint fileAccess,
                                                        [MarshalAs(UnmanagedType.U4)] uint fileShare,
                                                        IntPtr securityAttributes,
                                                        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
                                                        [MarshalAs(UnmanagedType.U4)] int flags,
                                                        IntPtr template);
    }
}