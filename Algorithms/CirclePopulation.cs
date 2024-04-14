using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Wallpaper.Models;

namespace Wallpaper.Algorithms
{
    public class CirclePopulation : IGenerativeDraw
    {
        public string DownloadPath { get; } = "download/CirclePopulation";
        public SKCanvasView CanvasReference { get; set; } = new();
        public float Width { get; set; } = 300;
        public float Height { get; set; } = 300;
        public Guid Id { get; set; } = Guid.NewGuid();
        Random random = new();

        List<(int x, int y, int radius)> circles = [];
        public int minRadius = 2;
        public int maxRadius = 100;
        public int totalCircles = 1200;
        public int createCircleAttempts = 500;

        public int width = 1200;
        public int height = 700;
        public async Task ButtonClicked()
        {
            circles = [];
            CanvasReference.Invalidate();
        }
        public void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            width = (int)Width;
            height = (int)Height;
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
            for (var i = 0; i < totalCircles; i++)
            {
                CreateAndDrawSafeCircle(paint, canvas);
            }
        }
        bool DoesCircleHaveACollision((int x, int y, int radius) circle)
        {
            for (var i = 0; i < circles.Count; i++)
            {
                var otherCircle = circles[i];
                var a = circle.radius + otherCircle.radius;
                var x = circle.x - otherCircle.x;
                var y = circle.y - otherCircle.y;

                if (a >= Math.Sqrt(x * x + y * y)) return true;
            }
            return false;
        }
        void CreateAndDrawSafeCircle(SKPaint paint, SKCanvas canvas)
        {
            var circleSafeToDraw = false;
            var point = (random.Next(0, width), random.Next(0, height), random.Next(minRadius, maxRadius));
            for (var i = 0; i < createCircleAttempts; i++)
            {
                point = (random.Next(0, width), random.Next(0, height), random.Next(minRadius, maxRadius));

                if (!DoesCircleHaveACollision(point))
                {
                    circleSafeToDraw = true;
                    break;
                }
            }
            if (circleSafeToDraw)
            {
                circles.Add(point);
                canvas.DrawCircle(point.Item1, point.Item2, point.Item3, paint);
            }
        }
    }
}
