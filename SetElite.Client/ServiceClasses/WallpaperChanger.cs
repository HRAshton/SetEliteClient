using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace SetElite.Client.ServiceClasses
{
    public class WallpaperChanger
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public void Set(string filename, WallpaperStyle style)
        {
            var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            switch (style)
            {
                case WallpaperStyle.Stretched:
                    key.SetValue(@"WallpaperStyle", 2, RegistryValueKind.String);
                    key.SetValue(@"TileWallpaper", 0, RegistryValueKind.String);
                    break;
                case WallpaperStyle.Centered:
                    key.SetValue(@"WallpaperStyle", 1, RegistryValueKind.String);
                    key.SetValue(@"TileWallpaper", 0, RegistryValueKind.String);
                    break;
                case WallpaperStyle.Tiled:
                    key.SetValue(@"WallpaperStyle", 1, RegistryValueKind.String);
                    key.SetValue(@"TileWallpaper", 1, RegistryValueKind.String);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(style), style, null);
            }

            SystemParametersInfo(20, 0, filename, 3);
        }
    }
}
