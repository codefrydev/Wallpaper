using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Wallpaper.Models;

namespace Wallpaper.Utilities
{
    public class GenerativeDrawScafolding : IGenerativeDraw
    {
        public SKCanvasView CanvasReference { get; set; } = new();
        public float Width { get; set; } = 300;
        public float Height { get; set; } = 300;
        public Guid Id { get; set; } = Guid.NewGuid();

        public string DownloadPath => "download/CirclePopulation";

        // I am also confused how i came up with this ideas 
        //void IGenerativeDraw.ButtonClicked()
        //{
        //    CanvasReference.Invalidate();
        //}
        public async Task ButtonClicked()
        {
            CanvasReference.Invalidate();
        }

        public void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColor.Parse("#fff"));
        }
    }
}