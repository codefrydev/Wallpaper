using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Wallpaper.Models;

namespace Wallpaper.Algorithms
{
    public class GridDots : IGenerativeDraw
    {
        public string DownloadPath { get; } = "download/GridDots";
        public SKCanvasView CanvasReference { get; set; } = new();
        public float Width { get; set; } = 300;
        public float Height { get; set; } = 300;
        public int step { get; set; } = 30;
        public Guid Id { get; set; } = Guid.NewGuid();
        public async Task ButtonClicked()
        {
            CanvasReference.Invalidate();
        }

        public void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            step = 30;
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColor.Parse("#fff"));
            SKPaint paint = new()
            {
                Color = SKColors.White.WithAlpha(100),
                IsAntialias = true,
                StrokeWidth = 3,
                ColorF = SKColor.Parse("#003366")
            };
            for (var i = step; i < Height; i += step)
            {
                for (var j = step; j < Width; j += step)
                {
                    SKPoint point = new(j, i);
                    canvas.DrawPoint(point, paint);
                }
            }
        }
    }
}
