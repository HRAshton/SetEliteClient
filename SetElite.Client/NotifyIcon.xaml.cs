using System;
using System.Windows;
using MyToolkit.Command;

namespace SetElite.Client
{
    /// <summary>
    /// Модель иконки приложения в трее.
    /// </summary>
    public partial class NotifyIcon : Window
    {
        /// <summary>
        /// Команда открытия основного окна.
        /// </summary>
        public RelayCommand OpenSettingsCommand => new RelayCommand(OpenSettings);
        /// <summary>
        /// Команда синхронизации настроек.
        /// </summary>
        public RelayCommand SyncNowCommand => new RelayCommand(SyncNow);
        /// <summary>
        /// Команда закрытия приложения.
        /// </summary>
        public RelayCommand CloseCommand => new RelayCommand(() => Environment.Exit(0));

        private MainWindow _mainWindow;

        /// <summary>
        /// Конструктор.
        /// </summary>
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
