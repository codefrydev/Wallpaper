using Microsoft.AspNetCore.Components;

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
            CardClass = ""
        });
        modes.Add(new Mode()
        {
            Name = "Generative",
            Location = "Generative",
            Description = "Algorithm-generated patterns",
            CardClass = ""
        });
        return base.OnInitializedAsync();
    }
    
    void Selected(Mode mode)
    {
        Manager.NavigateTo(mode.Location);
    }

    void NavigateToGenerative()
    {
        Manager.NavigateTo("Generative");
    }

    public struct Mode
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string CardClass { get; set; }
    }
}
