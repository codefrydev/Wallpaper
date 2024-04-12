using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Wallpaper.Models;

namespace Wallpaper.Pages.Creative
{
    public partial class CreativeImageDialog
    {

        [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

        [Parameter, EditorRequired] public Drawing ImageToDownload { get; set; } = null!;
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = null!;

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
        async Task DownloadImage()
        {
            await JsRuntime.InvokeVoidAsync("downloadImageUrl", ImageToDownload.ThumbNailUrl, ImageToDownload.Name);
        }
    }
}
