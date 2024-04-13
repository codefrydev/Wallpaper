using SkiaSharp.Views.Blazor;

namespace Wallpaper.Models
{
    public interface IGenerativeDraw
    {
        SKCanvasView CanvasReference { get; set; }
        float Height { get; set; }
        float Width { get; set; }
        Guid Id { get; set; }
        void ButtonClicked();
        void OnPaintSurface(SKPaintSurfaceEventArgs e);
    }
}