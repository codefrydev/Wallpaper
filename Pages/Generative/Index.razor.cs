using Microsoft.AspNetCore.Components;
using Wallpaper.Algorithms;
using Wallpaper.Models;

namespace Wallpaper.Pages.Generative;

public partial class Index
{
    [Inject]
    public NavigationManager navigationManager { get; set; } = null!;
    List<IGenerativeDraw> generativeDraws = [];
    protected override Task OnInitializedAsync()
    {
        generativeDraws.Clear();
        generativeDraws.Add(new LinkedLines());
        generativeDraws.Add(new HorizontalLines());
        generativeDraws.Add(new GridDots());
        generativeDraws.Add(new CirclePopulation());
        generativeDraws.Add(new RandomSquare());
        return base.OnInitializedAsync();
    }
    void NavigateTo(IGenerativeDraw generativeDraw)
    {
        navigationManager.NavigateTo(generativeDraw.DownloadPath);
    }
}
