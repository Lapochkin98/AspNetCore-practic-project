using Microsoft.AspNetCore.Mvc;
using TestAspCore.Data.Interfaces;
using TestAspCore.Data.Models;
using TestAspCore.ViewModels;

namespace TestAspCore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllGames _gameRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllGames gameRep, ShopCart shopCart)
        {
            _gameRep = gameRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _gameRep.Games.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
