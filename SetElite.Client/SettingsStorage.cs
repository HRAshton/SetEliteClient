using System;
using SetElite.Client.ParameterEntities;

namespace SetElite.Client
{
    public class SettingsStorageEntity
    {
        public SettingsStorageEntity()
        {
            KeyboardLayout = new KeyboardLayoutHotkeyParameterModel();
            WallpaperImage = new WallpaperImageParameterModel();
        }

        public KeyboardLayoutHotkeyParameterModel KeyboardLayout { get; set; }

        public WallpaperImageParameterModel WallpaperImage { get; set; }

        public void ApplyAll()
        {
            KeyboardLayout.Apply();
            WallpaperImage.Apply();
        }
    }
}
