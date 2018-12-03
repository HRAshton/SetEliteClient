using System;
using System.Drawing;
using Microsoft.Win32;
using MyToolkit.Command;
using Newtonsoft.Json;
using SetElite.Client.ParameterEntities.Virtual;
using SetElite.Client.ServiceClasses;
using System.IO;
using System.Net;
using MyToolkit.Utilities;

namespace SetElite.Client.ParameterEntities
{
    public sealed class WallpaperImageParameterModel : VirtualParameterModel
    {
        private const string defaultFilename = "<Не выбрано>";

        [JsonProperty(PropertyName = "Filename")]
        private string _filename;

        [JsonProperty(PropertyName = "WallpaperStyle")]
        private WallpaperStyle _wallpaperStyle;

        private Uri _wallpaperPath => new Uri(new Uri(MainWindow.UserdataDirectoryPath), Filename);

        public WallpaperImageParameterModel()
        {
            IsEnabled = false;
            
            Filename = defaultFilename;
            Style = WallpaperStyle.Stretched;
        }

        public RelayCommand OpenWallpaperCommand => new RelayCommand(OpenWallpaper);
        public RelayCommand ResetCommand => new RelayCommand(Reset);

        public string Filename
        {
            get => _filename;
            set => Set(ref _filename, value);
        }

        public WallpaperStyle Style
        {
            get => _wallpaperStyle;
            set => Set(ref _wallpaperStyle, value);
        }


        public override void Apply()
        {
            if (!IsEnabled)
            {
                return;
            }

            var wallpaperChanger = new WallpaperChanger();
            var path = Filename == defaultFilename 
                ? @"C:\Windows\Web\4K\Wallpaper\Windows\img0_3840x2160.jpg" 
                : _wallpaperPath.AbsolutePath;
            wallpaperChanger.Set(path, Style);
        }


        private void OpenWallpaper()
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Image Files | *.jpg; *.jpeg; *.png;"
            };

            if (openFileDialog.ShowDialog() != true) return;

            var filepath = openFileDialog.FileName;
            Filename = new FileInfo(filepath).Name;
            File.Copy(filepath, _wallpaperPath.AbsolutePath);
        }

        public override void Reset()
        {
            Filename = defaultFilename;
            Style = WallpaperStyle.Stretched;

            Apply();
        }
    }
}