using System;
using System.Windows.Forms;
using SetElite.Settings;
using SetElite.Settings.Keyboard;

namespace SetElite.Configurator.UserControls
{
    public partial class Keyboard : UserControl
    {
        private readonly IUserSettings _userSettings;

        public Keyboard(IUserSettings userSettings)
        {
            _userSettings = userSettings;
            InitializeComponent();

            checkBox1.Checked = _userSettings.Keyboard_IsEnabled;
            checkBox1_CheckedChanged(null, null);

            radioButton1.Checked = _userSettings.Keyboard_Mode == KeyboardLayout.CtrlShift;
            radioButton2.Checked = !radioButton1.Checked;

            radioButton1.CheckedChanged += (_, __) => SetMode(KeyboardLayout.CtrlShift);
            radioButton2.CheckedChanged += (_, __) => SetMode(KeyboardLayout.AltShift);
        }

        private void SetMode(KeyboardLayout keyboardLayout)
        {
            _userSettings.Keyboard_Mode = keyboardLayout;
        }

        public void ApplyChanges()
        {
            // ignore
        }

        private void checkBox1_CheckedChanged(object _, EventArgs __)
        {
            _userSettings.Keyboard_IsEnabled = checkBox1.Checked;

            mainPanel.Enabled = _userSettings.Keyboard_IsEnabled;
        }
    }
}
