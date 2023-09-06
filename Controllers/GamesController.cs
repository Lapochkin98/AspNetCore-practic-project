using Microsoft.AspNetCore.Mvc;
using TestAspCore.Data.Interfaces;
using TestAspCore.Data.Models;
using TestAspCore.ViewModels;

namespace TestAspCore.Controllers;

public class GamesController : Controller {
    
    private readonly IAllGames _allGames;
    private readonly IGamesCategory _allCategories;

    public GamesController(IAllGames iAllGames, IGamesCategory iGamesCategory)
    {
        _allGames = iAllGames;
        _allCategories = iGamesCategory;
    }

    [Route("Games/List")]
    [Route("Games/List/{category}")]
    public ViewResult List(string category)
    {

        string _category = category;
        IEnumerable<Game> games = null;
        string currCategory = "";

        if(string.IsNullOrEmpty(_category))
        {
            games = _allGames.Games.OrderBy(i => i.Id);
        }
        else
        {
            if(string.Equals("action", category, StringComparison.OrdinalIgnoreCase))
            {
                games = _allGames.Games.Where(i => i.CategoryId == 1).OrderBy(i => i.Id);
            }
            else if(string.Equals("survival", category, StringComparison.OrdinalIgnoreCase))
            {
                games = _allGames.Games.Where(i => i.CategoryId == 3).OrderBy(i => i.Id);
            }
            else if (string.Equals("adventure", category, StringComparison.OrdinalIgnoreCase))
            {
                games = _allGames.Games.Where(i => i.CategoryId == 2).OrderBy(i => i.Id);
            }

            currCategory = _category;
        }

        var gameObj = new GamesListViewModel
        {
            AllGames = games,
            CurrCategory = _category
        };

        ViewBag.Title = "Page with games";
        return View(gameObj);
    }
}