using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wallpaper.Utilities;

namespace Wallpaper.Algorithms
{
    public partial class CirclePopulationDownload
    {
        private float height;
        private float width;
        private int minRadius;
        private int maxRadius;
        private int totalCircle;
        private int numberOfAttempts;

        private CirclePopulation circlePopulationRef;

        private bool calculating = false;
        public CirclePopulationDownload()
        {
            circlePopulationRef = new CirclePopulation();
            width = circlePopulationRef.Width;
            height = circlePopulationRef.Height;
            minRadius = circlePopulationRef.minRadius;
            maxRadius = circlePopulationRef.maxRadius;
            totalCircle = circlePopulationRef.totalCircles;
            numberOfAttempts = circlePopulationRef.createCircleAttempts;
        }
        [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
        [Inject] public NavigationManager Navigation { get; set; } = null!;

        [Parameter] public GenerativeDrawScafolding dummy { get; set; } = new();
        async Task GenerateImage()
        {
            circlePopulationRef.Width = width;
            circlePopulationRef.Height = height;
            circlePopulationRef.minRadius = minRadius;
            circlePopulationRef.maxRadius = maxRadius;
            circlePopulationRef.totalCircles = totalCircle;
            circlePopulationRef.createCircleAttempts = numberOfAttempts;
            await circlePopulationRef.ButtonClicked();
        }
        async Task DownloadImage()
        {
            await JsRuntime.InvokeVoidAsync("generateImage", circlePopulationRef.Id.ToString());
        }
    }
}
