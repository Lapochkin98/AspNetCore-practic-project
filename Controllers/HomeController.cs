using Microsoft.AspNetCore.Mvc;
using TestAspCore.Data.Interfaces;
using TestAspCore.Data.Models;
using TestAspCore.ViewModels;

namespace TestAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllGames _gameRep;

        public HomeController(IAllGames gameRep)
        {
            _gameRep = gameRep;
        }

        public ViewResult Index()
        {
            var homeGames = new HomeViewModel
            {
                favGames = _gameRep.GetFavouriteGame
            };

            return View(homeGames);
        }
    }
}
