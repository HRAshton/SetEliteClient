using System;
using System.Windows.Forms;
using SetElite.Client.Properties;
using SetElite.Configurator;
using SetElite.Settings.Hotkeys;
using SetElite.Settings.Keyboard;
using SetElite.Settings.Wallpaper;
using UserSettings = SetElite.Client.Properties.UserSettings;

namespace SetElite.Client
{
	public class IconApplicationContext : ApplicationContext
	{
		private readonly NotifyIcon trayIcon;

		public IconApplicationContext()
		{
			trayIcon = new NotifyIcon
			{
				Icon = Resources.notifyIcon,
				ContextMenu = new ContextMenu(
					new[]
					{
						new MenuItem("Изменить параметры", (_, __) => OpenConfigurator()),
						new MenuItem("Закрыть", Exit),
					}
				),
				Visible = true,
			};

			trayIcon.DoubleClick += (_, __) => OpenConfigurator();
			
			ApplySettings();
		}

		private static void ApplySettings()
		{
			new HotkeysSettings().Apply(new HotkeysConfigModel
			{
				IsEnabled = UserSettings.Default.Hotkeys_IsEnabled,
			}, true);
			
			new KeyboardSettings().Apply(new KeyboardConfigModel
			{
				IsEnabled = UserSettings.Default.Keyboard_IsEnabled,
				Layout = UserSettings.Default.Keyboard_Mode,
			});
			
			new WallpaperSettings().Apply(new WallpaperConfigModel
			{
				IsEnabled = UserSettings.Default.Wallpaper_Enabled,
				WallpaperStyle = UserSettings.Default.Wallpaper_WallpaperStyle,
			});
		}

		private void OpenConfigurator()
		{
			using var r = new ConfiguratorWindow(UserSettings.Default) {Icon = trayIcon.Icon};
			
			if (r.ShowDialog() != DialogResult.OK)
			{
				UserSettings.Default.Reload();
				return;
			}
			
			UserSettings.Default.Save();
			ApplySettings();
			
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
		}

		private void Exit(object sender, EventArgs e)
		{
			trayIcon.Visible = false;

			Application.Exit();
		}
	}
}