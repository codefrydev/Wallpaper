using SkiaSharp;
using SkiaSharp.Views.Blazor;
using Wallpaper.Models;
using static MudBlazor.CategoryTypes;

namespace Wallpaper.Algorithms
{
    public class PointsOnCircle : IGenerativeDraw
    {
        public string DownloadPath { get; } = "download/pointOnCircle";
        public SKCanvasView CanvasReference { get; set; } = new();
        public float Width { get; set; } = 300;
        public float Height { get; set; } = 300;
        public float Times { get; set; } = 6;
        public int Radius { get; set; } = 90;

        public int InLine { get; set; } = 10;
        public Guid Id { get; set; } = Guid.NewGuid(); 

        private int width = 1200;
        private int height = 700;
        private int radius = 90;

        public async Task ButtonClicked()
        { 
            CanvasReference.Invalidate();
        }
        public void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            width = (int)Width;
            height = (int)Height;
            radius = Radius;
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
            CreateAndDraw(paint, canvas);
        } 
        void CreateAndDraw(SKPaint paint, SKCanvas canvas)
        {
            var ls = GetCenter(10, 7, radius);
            for (var n = 3; n <= Times +3; n++)
            {
                float X = ls[n - 3].Y;
                float Y = ls[n - 3].X;
                //paint.ColorF =listOfColor[random.Next(0,listOfColor.Count)];
                foreach (var i in GetAllLinePoints(n: n, x: X, y: Y, radius: radius))
                {
                    canvas.DrawLine(i.Item1, i.Item2, paint); 
                } 
            }
        }
        SKPoint[] CirclePoints(int n, float radius = 3, float x = 0, float y = 0)
        {
            float degree = (float)(2 * Math.PI / n);
            return Enumerable
                .Range(1, n)
                .Select(i => degree * i)
                .Select(i => (new SKPoint(x + radius * (float)Math.Cos(i), y + radius * (float)Math.Sin(i))))
                .ToArray();
        }
        List<(SKPoint, SKPoint)> GetAllLinePoints(int n, int radius = 3, float x = 0, float y = 0)
        {
            var arr = CirclePoints(n: n, x: x, y: y, radius: radius);
            var ls = new List<(SKPoint, SKPoint)>();

            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    ls.Add((arr[i], arr[j]));
                }
            }
            return ls;
        }
        List<(float X, float Y)> GetCenter(int m, int n, int radius = 60)
        {
            var ls = new List<(float X, float Y)>();
            int X = radius * 3;
            int Y = radius * 3;
            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    ls.Add((Y * i, X * j));
                }
            }
            return ls;
        }
    }
}
