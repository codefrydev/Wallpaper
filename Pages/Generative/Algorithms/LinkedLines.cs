using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Wallpaper.Models;
using Wallpaper.Utilities;

namespace Wallpaper.Pages.Generative.Algorithms
{
    public class LinkedLines : IGenerativeDraw
    {
        public SKCanvasView CanvasReference { get; set; } = new();
        public float Width { get; set; } = 300;
        public float Height { get; set; } = 300;
        public Guid Id { get; set; } = Guid.NewGuid();
        public void ButtonClicked()
        {
            CanvasReference.Invalidate();
        }
        public void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            canvas.Clear(SKColor.Parse("#fff"));
            int step = 12;
            Random rand = new(0);
            SKPaint paintR = new() { Color = SKColors.White.WithAlpha(100), IsAntialias = true };
            for (var i = 0; i <= Width; i += step)
            {
                for (var j = 0; j <= Height; j += step)
                {
                    paintR.StrokeWidth = rand.Next(1, 6);
                    Draw(i, j, step, step, paintR, canvas);
                }
            }
        }
        void Draw(int x, int y, int width, int height, SKPaint paint, SKCanvas canvas)
        {
            Random random = new();
            paint.Color = SkiaConstantColors.listOfColor[random.Next(0, SkiaConstantColors.listOfColor.Count)];
            var prob = random.Next(0, 10);
            if (prob < 5)
            {
                SKPoint pointOne = new(x, y);
                SKPoint pointTwo = new(x + width, y + height);
                canvas.DrawLine(pointOne, pointTwo, paint);
            }
            else
            {
                SKPoint pointOne = new(x + width, y);
                SKPoint pointTwo = new(x, y + height);
                canvas.DrawLine(pointOne, pointTwo, paint);
            }
        }

    }
}
