using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        }

        private void OpenSettings()
        {
            if (_mainWindow != null)
            {
                return;
            }

            _mainWindow = new MainWindow();
            _mainWindow.ShowDialog();
        }

        private void SyncNow()
        {
            var wnd = _mainWindow ?? new MainWindow();
            wnd.SettingsStorage.ApplyAll();
        }
    }
}
