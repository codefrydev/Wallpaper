using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wallpaper.Utilities;

namespace Wallpaper.Algorithms
{
    public partial class GridDotsDownload
    {
        private float height;
        private float width;

        private GridDots data;

        private bool calculating = false;
        public GridDotsDownload()
        {
            data = new GridDots();
            width = data.Width;
            height = data.Height;
        }
        [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

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
