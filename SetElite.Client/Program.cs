using System;
using System.IO;
using System.Windows.Forms;
using SetElite.Client.Properties;

namespace SetElite.Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(AppSettings.Default.UserConfigPath))
            {
                var directoryInfo = Directory.CreateDirectory(AppSettings.Default.UserConfigPath); 
                directoryInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden; 
            }
            Directory.SetCurrentDirectory(AppSettings.Default.UserConfigPath);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IconApplicationContext());
        }
    }
}
