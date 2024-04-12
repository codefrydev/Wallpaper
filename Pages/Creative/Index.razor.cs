using Microsoft.AspNetCore.Components;
using MudBlazor;
using Wallpaper.Models;

namespace Wallpaper.Pages.Creative
{
    public partial class Index
    {
        [Inject] public IDialogService dialogService { get; set; } = null!;
        readonly List<Drawing> images = [];
        public Index()
        {
            images.Add(new Drawing()
            {
                OriginalDrawingUrl = "https://picsum.photos/200/300",
                ThumbNailUrl = "https://picsum.photos/200/300",
                Name = "Abhijeet"
            });
        }
        private void OpenDialog(Drawing drawing)
        {
            var parameters = new DialogParameters<CreativeImageDialog>
            {
                { x => x.ImageToDownload, drawing }
            };
            var options = new DialogOptions
            {
                CloseOnEscapeKey = true,
                CloseButton = true,
                //Position = DialogPosition.Center
            };
            dialogService.Show<CreativeImageDialog>(drawing.Name, parameters, options);
        }
    }
}
