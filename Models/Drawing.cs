namespace Wallpaper.Models
{
    public class Drawing
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ThumbNailUrl { get; set; } = string.Empty;
        public string OriginalDrawingUrl { get; set; } = string.Empty;
        public string DrawingCreated { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public bool Amoled { get; set; }
    }
}
