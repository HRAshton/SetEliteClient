using System;
using MyToolkit.Command;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using MyToolkit.Mvvm;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace SetElite.Client
{
    public partial class MainWindow : Window
    {
        public const string UserdataDirectoryPath = @"U:\SetElite\";

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
            using (var context = new PrincipalContext(ContextType.Domain, "main.tpu.ru"))
            {
                var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                var user = UserPrincipal.FindByIdentity(context, username);

                this.Title = $"Настройки {user.Name} ({user.DisplayName})";
            }
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

            if (!Directory.Exists(UserdataDirectoryPath))
            {
                Directory.CreateDirectory(UserdataDirectoryPath);
            }
            File.WriteAllText(_settingsFilepath.AbsolutePath, json);

            SettingsStorage.ApplyAll();
        }
    }
}
