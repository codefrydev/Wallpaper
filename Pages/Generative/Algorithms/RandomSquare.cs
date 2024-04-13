using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Wallpaper.Models;

namespace Wallpaper.Pages.Generative.Algorithms
{
    public class RandomSquare : IGenerativeDraw
    {

        public SKCanvasView CanvasReference { get; set; } = new();
        public float Width { get; set; } = 300;
        public float Height { get; set; } = 300;
        public Guid Id { get; set; } = Guid.NewGuid();
        Random random = new Random();
        public void ButtonClicked()
        {
            CanvasReference.Invalidate();
        }

        public void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColor.Parse("#fff"));
            SKPaint paint = new()
            {
                Color = SKColors.White.WithAlpha(100),
                IsAntialias = true,
                StrokeWidth = 1,
                ColorF = SKColor.Parse("#003366"),
                Style = SKPaintStyle.Stroke
            };

            float z = 200;
            while (z > 10)
            {
                var x = Width / 2 - random.Next(0, (int)z);
                var y = Height / 2 - random.Next(0, (int)z);
                canvas.DrawRect(x, y, z / 2, z / 2, paint);
                z -= 10;
            }
        }
    }
}
