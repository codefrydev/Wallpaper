using Microsoft.AspNetCore.Components;

namespace Wallpaper.Pages;

public partial class Index
{
    [Inject] public NavigationManager Manager { get; set; } = null!;
    void GenerativeSelected()
    {
        Manager.NavigateTo("Generative");
    }
    void CreativeSelected()
    {
        Manager.NavigateTo("Creative");
    }
}
