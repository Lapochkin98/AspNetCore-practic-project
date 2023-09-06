namespace TestAspCore.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Game game { get; set; }
        public int price { get; set; }
        public string shopCartId { get; set; }
    }
}
