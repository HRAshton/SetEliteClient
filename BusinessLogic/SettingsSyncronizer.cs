using System.IO;
using Dal.ParameterEntities;
using Newtonsoft.Json;

namespace Dal
{
    public class SettingsSyncronizer
    {
        private readonly string _settingsStorageFilename;

        public SettingsSyncronizer(string settingsStorageFilename)
        {
            _settingsStorageFilename = settingsStorageFilename;

            State = new SettingsStorageEntity
            {
                KeyboardLayout = new KeyboardLayoutHotkeyParameterEntity(),
                Wallpaper = new WallpaperParameterEntity()
            };
        }


        public SettingsStorageEntity State { get; set; }


        public void DownloadSettings()
        {
            var json = File.ReadAllText(_settingsStorageFilename);
            State = JsonConvert.DeserializeObject<SettingsStorageEntity>(json);
        }

        public void UploadSettings()
        {
            var json = JsonConvert.SerializeObject(State);
            File.WriteAllText(_settingsStorageFilename, json);
        }
    }
}
