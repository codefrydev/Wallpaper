using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wallpaper.Utilities;

namespace Wallpaper.Algorithms
{
    public partial class PointsOnCircleDownload
    {
        public int width = 300;
        public int height = 300;
        public int radius = 60;
        public int times = 5;
        PointsOnCircle pointsOnCircle;
        public PointsOnCircleDownload()
        {
            pointsOnCircle = new PointsOnCircle();
            pointsOnCircle.Radius = radius;
            pointsOnCircle.Height = height;
            pointsOnCircle.Width = width;
            pointsOnCircle.Times = times;

        }
        async Task GenerateImage()
        {
            pointsOnCircle.Radius = radius;
            pointsOnCircle.Height = height;
            pointsOnCircle.Width = width;
            pointsOnCircle.Times = times;
            await pointsOnCircle.ButtonClicked();
        }
        [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

        [Parameter] public GenerativeDrawScafolding dummy { get; set; } = new();
        async Task DownloadImage()
        {
            await JsRuntime.InvokeVoidAsync("generateImage", pointsOnCircle.Id.ToString());
        }
    }
}
