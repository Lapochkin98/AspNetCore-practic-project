using TestAspCore.Data.Models;

namespace TestAspCore.ViewModels;

public class GamesListViewModel
{
    public IEnumerable<Game> AllGames { get; set; }

    public string CurrCategory { get; set; }
}