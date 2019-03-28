using Microsoft.Win32;
using SetElite.Client.ParameterEntities.Virtual;
using System;

namespace SetElite.Client.ParameterEntities.AccordEliteParameterModel
{
    public sealed class AccordEliteParameterModel : VirtualParameterModel
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public AccordEliteParameterModel()
        {
            IsEnabled = false;
        }

        /// <summary>
        /// Применить параметр.
        /// </summary>
        public override void Apply()
        {
            var value = IsEnabled
                ? $@"\\W03307\Users\{Environment.UserName}\Desktop"
                : @"%USERPROFILE%\Desktop";

            var keyboardToggleSettings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders", true);

            keyboardToggleSettings?.SetValue("Desktop", value, RegistryValueKind.ExpandString);
        }

        /// <summary>
        /// Сбросить значение параметра.
        /// </summary>
        public override void Reset()
        {
            IsEnabled = false;

            Apply();
        }
    }
}
