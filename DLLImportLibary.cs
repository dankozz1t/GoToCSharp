using System;
using System.Runtime.InteropServices;

namespace GoToCSharp
{
    public class DLLImportLibary
    {
        [DllImport("User32.dll")]
        public static extern int MessageBoxA(IntPtr intPtr, string text, string caption, uint type);


        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr intPtr);
    }
}