using System;
using MyToolkit.Command;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using MyToolkit.Mvvm;

namespace SetElite.Client
{
    public partial class MainWindow : Window
    {
        public const string UserdataDirectoryPath = @"C:\Users\Some\Desktop\";

        private readonly Uri _userdataDirectory;
        private readonly Uri _settingsFilepath;

        public MainWindow()
        {
            _userdataDirectory = new Uri(UserdataDirectoryPath);
            _settingsFilepath = new Uri(_userdataDirectory, "set.json");

            InitializeComponent();

            SaveCommand = new RelayCommand(UploadSettings);
            SettingsStorage = new SettingsStorageEntity();
            
            SetWindowPosition();
            UpdateWindowTitle();
            DownloadSettings();

            SettingsStorage.ApplyAll();

            this.DataContext = this;
        }


        public SettingsStorageEntity SettingsStorage { get; set; }
        public RelayCommand SaveCommand { get; }

        private void SetWindowPosition()
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void UpdateWindowTitle()
        {
            var username = "kss20";
            var fullname = "Kirill S. Suntsov";

            this.Title = $"Настройки {username} ({fullname})";
        }

        private void DownloadSettings()
        {
            try
            {
                var json = File.ReadAllText(_settingsFilepath.AbsolutePath);
                var model = JsonConvert.DeserializeObject<SettingsStorageEntity>(json);
                SettingsStorage = model;
            }
            catch
            {
                // ignored
            }
        }

        private void UploadSettings()
        {
            var json = JsonConvert.SerializeObject(SettingsStorage);
            File.WriteAllText(_settingsFilepath.AbsolutePath, json);

            SettingsStorage.ApplyAll();
        }
    }
}
