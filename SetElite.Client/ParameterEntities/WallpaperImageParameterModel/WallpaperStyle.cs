using System.ComponentModel;

namespace SetElite.Client.ParameterEntities.WallpaperImageParameterModel
{
    /// <summary>
    /// Стиль обоев.
    /// </summary>
    public enum WallpaperStyle
    {
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

        /// <summary>
        /// Растянуть.
        /// </summary>
        [Description("Растянуть")]
        Stretched
    }
}