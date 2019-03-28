using System;
using SetElite.Client.ParameterEntities;
using SetElite.Client.ParameterEntities.KeyboardLayoutHotkeyParameterModel;
using SetElite.Client.ParameterEntities.WallpaperImageParameterModel;

namespace SetElite.Client
{
    /// <summary>
    /// Хранилище настроек.
    /// </summary>
    public class SettingsStorageModel
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SettingsStorageModel()
        {
            KeyboardLayout = new KeyboardLayoutHotkeyParameterModel();
            WallpaperImage = new WallpaperImageParameterModel();
        }

        /// <summary>
        /// Настройки языка ввода.
        /// </summary>
        public KeyboardLayoutHotkeyParameterModel KeyboardLayout { get; set; }
        /// <summary>
        /// Настройки фона рабочего стола.
        /// </summary>
        public WallpaperImageParameterModel WallpaperImage { get; set; }

        /// <summary>
        /// Применить все параметры.
        /// </summary>
        public void ApplyAll()
        {
            KeyboardLayout.Apply();
            WallpaperImage.Apply();
        }
    }
}
