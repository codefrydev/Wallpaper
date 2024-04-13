using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Wallpaper.Pages;

public partial class Index
{
    [Inject] public NavigationManager Manager { get; set; } = null!;

    readonly string creativeColor = $"color:{(new MudTheme()).Palette.Dark}; background:{(new MudTheme()).Palette.Warning};";
    readonly string generativeColor = $"color:{(new MudTheme()).Palette.SuccessLighten}; background:{(new MudTheme()).Palette.Dark};";
    readonly List<Mode> modes = [];
    protected override Task OnInitializedAsync()
    {
        modes.Clear();
        modes.Add(new Mode()
        {
            Name = "Creative",
            Location = "Creative"
        });
        modes.Add(new Mode()
        {
            Name = "Generative",
            Location = "Generative"
        });
        return base.OnInitializedAsync();
    }
    void Selected(Mode mode)
    {
        Manager.NavigateTo(mode.Location);
    }
    void MouseEnter(Mode mode)
    {
        mode.ModeStyle = creativeColor;
        StateHasChanged();
    }
    void MouseExit(Mode mode)
    {
        mode.ModeStyle = generativeColor;
        StateHasChanged();
    }

    public struct Mode
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string BackgroundColor { get; set; }
        public string ModeStyle { get; set; }
    }
}
