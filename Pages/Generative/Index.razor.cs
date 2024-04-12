using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SkiaSharp;
using SkiaSharp.Views.Blazor;

namespace Wallpaper.Pages.Generative;

public partial class Index
{
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    float Height = 300;
    float Width = 300;
    SKCanvasView canvasReference = new();


    Guid id = Guid.NewGuid();
    void ButtonClicked()
    {
        canvasReference.Invalidate();
    }
    async Task DownloadImage()
    {
        await JsRuntime.InvokeVoidAsync("generateImage", id.ToString());
    }
    private void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;

        canvas.Clear(SKColor.Parse("#003366"));

        int width = 300;
        int height = 300;


        int step = 12;
        Random rand = new(0);
        SKPaint paintR = new() { Color = SKColors.White.WithAlpha(100), IsAntialias = true };
        for (var i = 0; i < width; i += step)
        {
            for (var j = 0; j < height; j += step)
            {
                paintR.StrokeWidth = rand.Next(1, 6);
                Draw(i, j, step, step, paintR, canvas);
            }
        }
    }
    void Draw(int x, int y, int width, int height, SKPaint paint, SKCanvas canvas)
    {
        Random random = new();
        paint.Color = listOfColor[random.Next(0, listOfColor.Count)];
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
    List<SKColor> listOfColor =
    [
        SKColor.Parse("#EEF5FF"),
        SKColor.Parse("#B4D4FF"),
        SKColor.Parse("#86B6F6"),
        SKColor.Parse("#176B87"),
        SKColor.Parse("#00A9FF"),
        SKColor.Parse("#89CFF3"),
        SKColor.Parse("#A0E9FF"),
        SKColor.Parse("#CDF5FD"),
        SKColor.Parse("#FF90BC"),
        SKColor.Parse("#FFC0D9"),
        SKColor.Parse("#F9F9E0"),
        SKColor.Parse("#8ACDD7"),
        SKColor.Parse("#F2AFEF"),
        SKColor.Parse("#C499F3"),
        SKColor.Parse("#33186B"),

    ];
}
