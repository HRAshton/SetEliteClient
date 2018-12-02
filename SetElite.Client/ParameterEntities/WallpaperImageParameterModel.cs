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
        [JsonProperty(PropertyName = "Filename")]
        private string _filename;

        [JsonProperty(PropertyName = "WallpaperStyle")]
        private WallpaperStyle _wallpaperStyle;

        public WallpaperImageParameterModel()
        {
            IsEnabled = false;
            
            Filename = "<Не выбрано>";
            Style = WallpaperStyle.Stretched;
            
            _wallpaperPath = new Uri(new Uri(MainWindow.UserdataDirectoryPath), "wallpaper.bmp");
        }

        public RelayCommand OpenWallpaperCommand => new RelayCommand(OpenWallpaper);

        private readonly Uri _wallpaperPath;

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
            
            var tempBitmapFilename = _wallpaperPath;

            var wallpaperChanger = new WallpaperChanger();
            wallpaperChanger.Set(tempBitmapFilename.AbsolutePath, Style);
        }


        private void OpenWallpaper()
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Image Files | *.jpg; *.jpeg; *.png;"
            };

            if (openFileDialog.ShowDialog() != true) return;

            var filename = openFileDialog.FileName;

            using (var stream1 = new WebClient().OpenRead(filename))
            {
                using (var stream2 = new FileStream(_wallpaperPath.AbsolutePath, FileMode.Create))
                {
                    var img = Image.FromStream(stream1);
                    img.Save(stream2, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }

            Filename = new FileInfo(filename).Name;
        }
    }
}