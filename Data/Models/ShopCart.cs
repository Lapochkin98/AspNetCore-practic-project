using System.Data.Entity;

namespace TestAspCore.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContent _appDbContent;

        public ShopCart(AppDbContent appDBContent)
        {
            this._appDbContent = appDBContent;
        }

        public string shopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { shopCartId = shopCartId };
        }

        public void AddToCart(Game game)
        {
            _appDbContent.ShopCartItem.Add(new ShopCartItem
            {
                shopCartId = shopCartId,
                game = game,
                price = (int)game.Price
            } );

            _appDbContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return _appDbContent.ShopCartItem.Where(c => c.shopCartId == shopCartId).Include(c => c.game).ToList();
        }
    }
}
