using System;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using SetElite.Settings;
using SetElite.Settings.Hotkeys;
using SetElite.Settings.Keyboard;
using SetElite.Settings.Wallpaper;

namespace SetElite.Configurator
{
	public sealed partial class ConfiguratorWindow : Form
	{
		private readonly UserControls.Wallpaper wallpaper;
		private readonly UserControls.Keyboard keyboard;
		private readonly UserControls.Hotkeys hotkeys;
		
		public ConfiguratorWindow(IUserSettings settings)
		{
			InitializeComponent();
			DialogResult = DialogResult.Cancel;

			using var context = new PrincipalContext(ContextType.Domain, Domain.GetComputerDomain().Name);
			var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			var user = UserPrincipal.FindByIdentity(context, username);
			Text = $"Настройки {user?.Name} ({user?.DisplayName})";

			wallpaper = new UserControls.Wallpaper(settings) {Dock = DockStyle.Fill};
			tabControl1.TabPages[0].Text = WallpaperSettings.Name;
			label1.Text = string.Format(label1.Text, WallpaperSettings.Description);
			panel1.Controls.Add(wallpaper);

			keyboard = new UserControls.Keyboard(settings) {Dock = DockStyle.Fill};
			tabControl1.TabPages[1].Text = KeyboardSettings.Name;
			label2.Text = string.Format(label2.Text, KeyboardSettings.Description);
			panel2.Controls.Add(keyboard);

			hotkeys = new UserControls.Hotkeys(settings) {Dock = DockStyle.Fill};
			tabControl1.TabPages[2].Text = HotkeysSettings.Name;
			label3.Text = string.Format(label3.Text, HotkeysSettings.Description);
			panel3.Controls.Add(hotkeys);
		}

		private void Apply_Click(object sender, EventArgs e)
		{
			wallpaper.ApplyChanges();
			keyboard.ApplyChanges();
			hotkeys.ApplyChanges();
			
			DialogResult = DialogResult.OK;
			Close();
			Dispose();
		}
	}
}