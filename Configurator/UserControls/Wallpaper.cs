using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SetElite.Settings;
using SetElite.Settings.Wallpaper;

namespace SetElite.Configurator.UserControls
{
    public partial class Wallpaper : UserControl
    {
        private readonly IUserSettings _userSettings;
        private string userSelectedPath;

        public Wallpaper(IUserSettings userSettings)
        {
            _userSettings = userSettings;
            InitializeComponent();

            checkBox1.Checked = _userSettings.Wallpaper_Enabled;
            checkBox1_CheckedChanged(null, null);

            if (File.Exists(WallpaperSettings.UserWallpaperFilename))
            {
                SetPreview(WallpaperSettings.UserWallpaperFilename);
            }
            
            comboBox1.DataSource = Enum.GetValues(typeof(WallpaperStyle));
            comboBox1.SelectedIndex = (int)comboBox1.Items
                .Cast<WallpaperStyle>()
                .Single(x => x == _userSettings.Wallpaper_WallpaperStyle);
            comboBox1_SelectedValueChanged(null, null);
        }
        
        public void ApplyChanges()
        {
            if (pictureBox1.Image == null || !File.Exists(userSelectedPath))
            {
                return;
            }

            if (Path.GetFullPath(userSelectedPath) == Path.GetFullPath(WallpaperSettings.UserWallpaperFilename))
            {
                return;
            }
            
            File.Copy(userSelectedPath, WallpaperSettings.UserWallpaperFilename, true);
        }

        private void button1_Click(object _, EventArgs __)
        {
            using var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SetPreview(openFileDialog.FileName);
        }

        private void SetPreview(string filePath)
        {
            try
            {
                using var file = File.OpenRead(filePath);
                pictureBox1.Image = Image.FromStream(file);
                file.Close();
                userSelectedPath = filePath;
            }
            catch (Exception)
            {
                var appFolder = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
                userSelectedPath = Path.Combine(appFolder!, "DefaultWallpaper.jpg");
                pictureBox1.Load(userSelectedPath);
            }
        }

        private void comboBox1_SelectedValueChanged(object _, EventArgs __)
        {
            if (!Enum.TryParse<WallpaperStyle>(comboBox1.SelectedValue?.ToString(), out var style))
            {
                comboBox1.SelectedValue = style = WallpaperStyle.Stretched;
            }
            
            _userSettings.Wallpaper_WallpaperStyle = style;
        }

        private void checkBox1_CheckedChanged(object _, EventArgs __)
        {
            _userSettings.Wallpaper_Enabled = checkBox1.Checked;

            mainPanel.Enabled = _userSettings.Wallpaper_Enabled;
        }
    }
}
