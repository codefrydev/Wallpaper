using Wallpaper.Models;
using Wallpaper.Pages.Generative.Algorithms;

namespace Wallpaper.Pages.Generative;

public partial class Index
{
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
}
