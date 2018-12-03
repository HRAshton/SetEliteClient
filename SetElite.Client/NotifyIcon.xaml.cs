using System;
using System.Windows;
using MyToolkit.Command;

namespace SetElite.Client
{
    public partial class NotifyIcon : Window
    {
        public RelayCommand OpenSettingsCommand => new RelayCommand(OpenSettings);
        public RelayCommand SyncNowCommand => new RelayCommand(SyncNow);
        public RelayCommand CloseCommand => new RelayCommand(() => Environment.Exit(0));

        MainWindow _mainWindow;

        public NotifyIcon()
        {
            InitializeComponent();
            this.DataContext = this;
            SyncNow();
        }

        private void OpenSettings()
        {
            if (_mainWindow?.IsVisible != true)
            {
                _mainWindow = new MainWindow();
                _mainWindow.ShowDialog();
            }

            _mainWindow.Close();
        }

        private void SyncNow()
        {
            var wnd = _mainWindow ?? new MainWindow();
            wnd.SettingsStorage.ApplyAll();
        }
    }
}
