using System;
using System.Windows.Forms;
using SetElite.Settings;
using SetElite.Settings.Keyboard;

namespace SetElite.Configurator.UserControls
{
    public partial class Hotkeys : UserControl
    {
        private readonly IUserSettings _userSettings;

        public Hotkeys(IUserSettings userSettings)
        {
            _userSettings = userSettings;
            InitializeComponent();

            checkBox1.Checked = _userSettings.Hotkeys_IsEnabled;
            checkBox1_CheckedChanged(null, null);
        }

        public void ApplyChanges()
        {
            // ignore
        }

        private void checkBox1_CheckedChanged(object _, EventArgs __)
        {
            _userSettings.Hotkeys_IsEnabled = checkBox1.Checked;

            mainPanel.Enabled = _userSettings.Hotkeys_IsEnabled;
        }
    }
}
