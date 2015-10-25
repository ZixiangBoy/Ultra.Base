using System;
using System.Runtime.InteropServices;


namespace DoubleBullet.Surmnt.Surface.SuperForm
{
    /// <summary>
    /// The wrapper class for kernal32.dll
    /// </summary>
    public static class Kernal32Dll
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern UIntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();
    }
}
