using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wallpaper.Utilities;

namespace Wallpaper.Algorithms
{
    public partial class RandomSquareDownload
    {
        private float height;
        private float width;

        private RandomSquare data;
        public RandomSquareDownload()
        {
            data = new RandomSquare();
            width = data.Width;
            height = data.Height;
        }
        [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
        [Inject] public NavigationManager Navigation { get; set; } = null!;

        [Parameter] public GenerativeDrawScafolding dummy { get; set; } = new();
        async Task GenerateImage()
        {
            data.Width = width;
            data.Height = height;
            await data.ButtonClicked();
        }
        async Task DownloadImage()
        {
            await JsRuntime.InvokeVoidAsync("generateImage", data.Id.ToString());
        }
    }
}
