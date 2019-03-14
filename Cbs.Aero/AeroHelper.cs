using System;
using System.Runtime.InteropServices;

namespace Cbs.Aero
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
    }

    public static class AeroHelper
    {
        public static MARGINS NewMargins(int x)
        {
            return new MARGINS
            {
                Left = x,
                Right = x,
                Top = x,
                Bottom = x
            };
        }

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
    }
}
