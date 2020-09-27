using SetElite.Settings.Keyboard;
using SetElite.Settings.Wallpaper;

namespace SetElite.Settings
{
	public interface IUserSettings
	{
		bool Wallpaper_Enabled { get; set; }
		
		WallpaperStyle Wallpaper_WallpaperStyle { get; set; }
		
		
		bool Keyboard_IsEnabled { get; set; }
		
		KeyboardLayout Keyboard_Mode { get; set; }

		
		bool Hotkeys_IsEnabled { get; set; }
	}
}