using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Wallpaper.Pages;

public partial class Index
{
    [Inject] public NavigationManager Manager { get; set; } = null!;

    readonly List<Mode> modes = [];
    
    protected override Task OnInitializedAsync()
    {
        modes.Clear();
        modes.Add(new Mode()
        {
            Name = "Creative",
            Location = "Creative",
            Description = "Hand-drawn artistic wallpapers",
            Icon = "Icons.Material.Filled.Palette",
            ModeStyle = ""
        });
        modes.Add(new Mode()
        {
            Name = "Generative",
            Location = "Generative",
            Description = "Algorithm-generated patterns",
            Icon = "Icons.Material.Filled.AutoAwesome",
            ModeStyle = ""
        });
        return base.OnInitializedAsync();
    }
    
    void Selected(Mode mode)
    {
        Manager.NavigateTo(mode.Location);
    }
    
    void MouseEnter(Mode mode)
    {
        if (mode.Name == "Creative")
        {
            mode.ModeStyle = "background: linear-gradient(135deg, #fef3c7 0%, #fde68a 100%); border-color: #f59e0b;";
        }
        else
        {
            mode.ModeStyle = "background: linear-gradient(135deg, #dbeafe 0%, #bfdbfe 100%); border-color: #3b82f6;";
        }
        StateHasChanged();
    }
    
    void MouseExit(Mode mode)
    {
        mode.ModeStyle = "";
        StateHasChanged();
    }

    public struct Mode
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Icon { get; set; }
        public string ModeStyle { get; set; }
    }
}
