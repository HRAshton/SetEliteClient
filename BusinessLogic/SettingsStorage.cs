using Dal.ParameterEntities;

namespace Dal
{
    public class SettingsStorageEntity
    {
        public KeyboardLayoutHotkeyParameterEntity KeyboardLayout { get; set; }

        public WallpaperParameterEntity Wallpaper { get; set; }
    }
}
