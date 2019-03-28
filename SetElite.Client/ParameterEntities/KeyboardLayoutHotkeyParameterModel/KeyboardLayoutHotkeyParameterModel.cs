using Microsoft.Win32;
using Newtonsoft.Json;
using SetElite.Client.ParameterEntities.Virtual;

namespace SetElite.Client.ParameterEntities.KeyboardLayoutHotkeyParameterModel
{
    public sealed class KeyboardLayoutHotkeyParameterModel : VirtualParameterModel
    {
        [JsonProperty(PropertyName = "Value")]
        private KeyboardLayouts _value;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public KeyboardLayoutHotkeyParameterModel()
        {
            IsEnabled = true;
            Value = KeyboardLayouts.AltShift;
        }


        /// <summary>
        /// Значение параметра.
        /// </summary>
        public KeyboardLayouts Value
        {
            get => _value;
            set => Set(ref _value, value);
        }

        /// <summary>
        /// Применить параметр.
        /// </summary>
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

        /// <summary>
        /// Сбросить значение параметра.
        /// </summary>
        public override void Reset()
        {
            Value = KeyboardLayouts.CtrlShift;

            Apply();
        }
    }
}
