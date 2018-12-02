using System;
using Microsoft.Win32;
using Newtonsoft.Json;
using SetElite.Client.ParameterEntities.Virtual;
using SetElite.Client.ServiceClasses;

namespace SetElite.Client.ParameterEntities
{
    public sealed class KeyboardLayoutHotkeyParameterModel : VirtualParameterModel
    {
        [JsonProperty(PropertyName = "Value")]
        private KeyboardLayouts _value;

        public KeyboardLayoutHotkeyParameterModel()
        {
            IsEnabled = true;
            Value = KeyboardLayouts.AltShift;
        }

        public KeyboardLayouts Value
        {
            get => _value;
            set => Set(ref _value, value);
        }

        public override void Apply()
        {
            if (!IsEnabled)
            {
                return;
            }

            var value = Value == KeyboardLayouts.AltShift ? 1 : 2;

            var keyboardToggleSettings = Registry.CurrentUser.OpenSubKey(@"Keyboard Layout\Toggle", true);

            keyboardToggleSettings?.SetValue("Hotkey", value, RegistryValueKind.String);
            keyboardToggleSettings?.SetValue("Language Hotkey", value, RegistryValueKind.String);
            keyboardToggleSettings?.SetValue("Layout Hotkey", 3, RegistryValueKind.String);
        }
    }
}
