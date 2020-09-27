using System;
using Microsoft.Win32;

namespace SetElite.Settings.Keyboard
{
	public class KeyboardSettings : SettingsBase<KeyboardConfigModel>
	{
		public new static string Name = "Переключение языка";
		
		public new static string Description = "Позволяет задать способ переключения языка клавиатуры.";

		protected override void Apply(KeyboardConfigModel model, object _)
		{
			var value = model.Layout switch
			{
				KeyboardLayout.AltShift  => 1,
				KeyboardLayout.CtrlShift => 2,
				_ => throw new NotSupportedException(),
			};

			var keyboardToggleSettings = Registry.CurrentUser.OpenSubKey(@"Keyboard Layout\Toggle", true);

			keyboardToggleSettings?.SetValue("Hotkey", value, RegistryValueKind.String);
			keyboardToggleSettings?.SetValue("Language Hotkey", value, RegistryValueKind.String);
			keyboardToggleSettings?.SetValue("Layout Hotkey", 3, RegistryValueKind.String);
		}
	}
}