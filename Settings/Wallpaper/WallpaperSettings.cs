using System.IO;
using System.Linq;
using System.Text;

namespace SetElite.Settings.Wallpaper
{
	public class WallpaperSettings : SettingsBase<WallpaperConfigModel>
	{
		public const string UserWallpaperFilename = "UserWallpaper.png";

		public new static string Name = "Обои рабочего стола";

		public new static string Description = "Позволяет задать параметры обоев рабочего стола.";

		protected override void Apply(WallpaperConfigModel model, object _)
		{
			var fileInfo = new FileInfo(UserWallpaperFilename);
			if (!fileInfo.Exists || !IsValidImage(File.ReadAllBytes(fileInfo.FullName)))
			{
				var appFolder = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
				fileInfo = new FileInfo(Path.Combine(appFolder!, "DefaultWallpaper.jpg"));
			}

			WallpaperChanger.Apply(fileInfo.FullName, model.WallpaperStyle);
		}

		private static bool IsValidImage(byte[] bytes)
		{
			// see http://www.mikekunz.com/image_file_header.html  
			var bmp = Encoding.ASCII.GetBytes("BM"); // BMP
			var gif = Encoding.ASCII.GetBytes("GIF"); // GIF
			var png = new byte[] {137, 80, 78, 71}; // PNG
			var tiff = new byte[] {73, 73, 42}; // TIFF
			var tiff2 = new byte[] {77, 77, 42}; // TIFF
			var jpeg = new byte[] {255, 216, 255, 224}; // jpeg
			var jpeg2 = new byte[] {255, 216, 255, 225}; // jpeg canon

			return bmp.SequenceEqual(bytes.Take(bmp.Length)) || gif.SequenceEqual(bytes.Take(gif.Length)) || png.SequenceEqual(bytes.Take(png.Length)) || tiff.SequenceEqual(bytes.Take(tiff.Length)) || tiff2.SequenceEqual(bytes.Take(tiff2.Length)) || jpeg.SequenceEqual(bytes.Take(jpeg.Length)) || jpeg2.SequenceEqual(bytes.Take(jpeg2.Length));
		}
	}
}