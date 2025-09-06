using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Wallpaper.Models;

namespace Wallpaper.Pages.Creative
{
    public partial class Index
    { 
        protected override async Task OnInitializedAsync()
        {
            Datas.OnChange += StateHasChanged;
            await Datas.InitializeAsync();
        }

        public void Dispose()
        {
            Datas.OnChange -= StateHasChanged;
        }

        private Drawing? selectedImage = null;
        private bool showModal = false;

        private void OpenDialog(Drawing drawing)
        {
            selectedImage = drawing;
            showModal = true;
            StateHasChanged();
        }

        private void CloseModal()
        {
            showModal = false;
            selectedImage = null;
            StateHasChanged();
        }
    }
}
