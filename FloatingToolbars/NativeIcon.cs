using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FloatingToolbars
{
    internal static class NativeIcon
    {
        internal static Icon GetSmallIcon(string path) => GetIcon(path, SHGFI_ICON | SHGFI_SMALLICON);

        internal static Icon GetLargeIcon(string path) => GetIcon(path, SHGFI_ICON | SHGFI_LARGEICON);

        internal static Icon ExtractIcon(string path, int index)
        {
            IntPtr[] icons = new IntPtr[1];
            ExtractIconEx(path, index, null, icons, 1);
            return Icon.FromHandle(icons[0]);
        }

        private static Icon GetIcon(string path, uint flags)
        {
            SHFILEINFO info = new SHFILEINFO();
            SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), flags);
            return Icon.FromHandle(info.hIcon);
        }

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;

        [DllImport("shell32.dll", CharSet=CharSet.Auto)]
        static extern uint ExtractIconEx(string szFileName, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO sfi, uint cbFileInfo, uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            internal IntPtr hIcon;
            internal IntPtr iIcon;
            internal uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            internal string szTypeName;
        }
    }
}