using System;
using SetElite.Client.ParameterEntities.AccordEliteParameterModel;
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
            KeyboardLayoutHotkeyParameterModel = new KeyboardLayoutHotkeyParameterModel();
            WallpaperImageParameterModel = new WallpaperImageParameterModel();
            AccordEliteParameterModel = new AccordEliteParameterModel();
        }

        /// <summary>
        /// Настройки языка ввода.
        /// </summary>
        public KeyboardLayoutHotkeyParameterModel KeyboardLayoutHotkeyParameterModel { get; set; }
        /// <summary>
        /// Настройки фона рабочего стола.
        /// </summary>
        public WallpaperImageParameterModel WallpaperImageParameterModel { get; set; }
        /// <summary>
        /// Настройки синхронизации рабочего стола.
        /// </summary>
        public AccordEliteParameterModel AccordEliteParameterModel { get; set; }

        /// <summary>
        /// Применить все параметры.
        /// </summary>
        public void ApplyAll()
        {
            KeyboardLayoutHotkeyParameterModel.Apply();
            WallpaperImageParameterModel.Apply();
            AccordEliteParameterModel.Apply();
        }
    }
}
