using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Wallpaper.Models;
using Wallpaper.Utilities;

namespace Wallpaper.Pages.Generative.Algorithms
{
    public class HorizontalLines : IGenerativeDraw
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
            int step = 1;
            int crowd = 90;
            canvas.Clear(SKColor.Parse("#fff"));

            Random rand = new(0);
            SKPaint paint = new()
            {
                Color = SKColors.White.WithAlpha(100),
                IsAntialias = true,
                StrokeWidth = rand.Next(1, 6)
            };
            var ls = GetList(Width, Height, step, crowd);

            foreach (var i in ls)
            {

                using SKPath path = new();
                var pointOne = i.Select(x => new SKPoint(x.Item1, x.Item2)).ToArray();
                path.AddPoly(pointOne);
                Random random = new();
                paint.Color = SkiaConstantColors.listOfColor[random.Next(0, SkiaConstantColors.listOfColor.Count)];
                paint.StrokeWidth = rand.Next(1, 4);
                canvas.DrawPath(path, paint);

            }
        }

        List<List<(int, int)>> GetList(float width, float height, int step, int crowd)
        {
            var lines = new List<List<(int, int)>>();
            Random random = new Random();
            for (var i = 0; i < height; i += step)
            {
                var ls = new List<(int, int)>();
                for (var j = 0; j < width; j += crowd)
                {
                    ls.Add((j, i + random.Next(1, 10)));
                }
                lines.Add(ls);
            }
            return lines;
        }
    }
}
