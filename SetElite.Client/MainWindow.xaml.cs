using System;
using MyToolkit.Command;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.DirectoryServices.AccountManagement;

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
            HelpCommand = new RelayCommand(ShowHelp);
            SettingsStorage = new SettingsStorageEntity();

            SetWindowPosition();
            UpdateWindowTitle();
            DownloadSettings();

            SettingsStorage.ApplyAll();

            this.DataContext = this;
        }
        
        public SettingsStorageEntity SettingsStorage { get; set; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand HelpCommand { get; }

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

        private void ShowHelp()
        {
            System.Windows.MessageBox.Show("Проект SetElite обеспечивает синхронизацию настроек между компьютерами. Чтобы включить синхронизацию параметра, нужно его раскрыть и задать нужное значение.Например, чтобы переключение языка ввода на Alt + Shift, нужно раскрыть соответствующий пункт настроек и выбрать \"Alt+Shift\", после чего нажать \"Сохранить\".Настройки применятся на остальных компьютерах при входе под Вашей учетной записью.Чтобы принудительно применить новые настройки на компьютере, нажмите правую кнопку мыши на значке SetElite Client в трее и выберите пункт \"Синхронизировать\".",
                "Справка",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
