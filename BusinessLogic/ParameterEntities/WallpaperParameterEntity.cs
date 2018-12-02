using Dal.ParameterEntities.Virtual;

namespace Dal.ParameterEntities
{
    public sealed class WallpaperParameterEntity : ParameterEntity
    {
        public WallpaperParameterEntity()
        {
            IsEnabled = false;
            BinaryData = null;
            Filename = "<Не выбрано>";
        }

        public string Filename { get; set; }
        public byte[] BinaryData { get; set; }
    }
}