using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Text.Json;
using Wallpaper.Models;

namespace Wallpaper.Pages.Creative
{
    public partial class Index
    { 
        [Inject] public IDialogService dialogService { get; set; } = null!; 
        protected override async Task OnInitializedAsync()
        {
            Datas.OnChange += StateHasChanged;
            await Datas.InitializeAsync();
        }

        public void Dispose()
        {
            Datas.OnChange -= StateHasChanged;
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
