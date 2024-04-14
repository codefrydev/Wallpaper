using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Wallpaper.Utilities;

namespace Wallpaper.Components
{

    public partial class GenerativeDownloaderComponent
    {
        [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

        [Parameter] public GenerativeDrawScafolding dummy { get; set; } = new();
        void ButtonClicked()
        {

        }
        async Task DownloadImage()
        {
            //await JsRuntime.InvokeVoidAsync("generateImage", id.ToString());
        }
    }
}
