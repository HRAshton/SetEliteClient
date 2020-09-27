using System.ComponentModel;

namespace SetElite.Settings.Wallpaper
{
    /// <summary>
    /// Стиль обоев.
    /// </summary>
    public enum WallpaperStyle
    {
        /// <summary>
        /// Растянуть.
        /// </summary>
        [Description("Растянуть")]
        Stretched,
        
        /// <summary>
        /// Замостить.
        /// </summary>
        [Description("Замостить")]
        Tiled,

        /// <summary>
        /// Центрировать.
        /// </summary>
        [Description("Центрировать")]
        Centered,
    }
}