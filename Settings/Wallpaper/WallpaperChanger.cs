using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SetElite.Settings.Wallpaper
{
    internal static class WallpaperChanger
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public static void Apply(string filename, WallpaperStyle style)
        {
            using var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            var (wallpaperStyle, tileWallpaper) = style switch
            {
                WallpaperStyle.Stretched => (2, 0),
                WallpaperStyle.Centered => (1, 0),
                WallpaperStyle.Tiled => (1, 1),
                _ => throw new NotSupportedException(),
            };
            
            key.SetValue("WallpaperStyle", wallpaperStyle, RegistryValueKind.String);
            key.SetValue("TileWallpaper", tileWallpaper, RegistryValueKind.String);

            SystemParametersInfo(20, 0, filename, 3);
        }
    }
}