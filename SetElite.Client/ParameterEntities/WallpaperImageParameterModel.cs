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
    /// <summary>
    /// Модель настроек фона рабочего стола.
    /// </summary>
    public sealed class WallpaperImageParameterModel : VirtualParameterModel
    {
        private const string DefaultFilename = "<Не выбрано>";

        [JsonProperty(PropertyName = "Filename")]
        private string _filename;

        [JsonProperty(PropertyName = "WallpaperStyle")]
        private WallpaperStyle _wallpaperStyle;

        private Uri WallpaperPath => new Uri(new Uri(MainWindow.UserdataDirectoryPath), Filename);

        /// <summary>
        /// Конструктор.
        /// </summary>
        public WallpaperImageParameterModel()
        {
            IsEnabled = false;
            
            Filename = DefaultFilename;
            Style = WallpaperStyle.Stretched;
        }

        /// <summary>
        /// Команда выбора файла.
        /// </summary>
        public RelayCommand OpenWallpaperCommand => new RelayCommand(OpenWallpaper);

        /// <summary>
        /// Название файла фона рабочего стола.
        /// </summary>
        public string Filename
        {
            get => _filename;
            set => Set(ref _filename, value);
        }
        /// <summary>
        /// Стиль фона рабочего стола.
        /// </summary>
        public WallpaperStyle Style
        {
            get => _wallpaperStyle;
            set => Set(ref _wallpaperStyle, value);
        }


        /// <inheritdoc />
        /// <summary>
        /// Применить параметр.
        /// </summary>
        public override void Apply()
        {
            if (!IsEnabled)
            {
                return;
            }

            var wallpaperChanger = new WallpaperChanger();
            var path = Filename == DefaultFilename 
                ? @"C:\Windows\Web\4K\Wallpaper\Windows\img0_3840x2160.jpg" 
                : WallpaperPath.AbsolutePath;
            wallpaperChanger.Set(path, Style);
        }

        /// <inheritdoc />
        /// <summary>
        /// Сбросить значение параметра.
        /// </summary>
        public override void Reset()
        {
            Filename = DefaultFilename;
            Style = WallpaperStyle.Stretched;

            Apply();
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
            File.Copy(filepath, WallpaperPath.AbsolutePath, true);
        }
    }
}