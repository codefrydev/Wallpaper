using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wallpaper.Utilities;

namespace Wallpaper.Algorithms
{
    public partial class HorizontalLinesDownload
    {
        private float height;
        private float width;

        private HorizontalLines data;

        private bool calculating = false;
        public HorizontalLinesDownload()
        {
            data = new HorizontalLines();
            width = data.Width;
            height = data.Height;
        }
        [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

        [Parameter] public GenerativeDrawScafolding dummy { get; set; } = new();
        async Task Recalculate()
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
