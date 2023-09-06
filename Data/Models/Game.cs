namespace TestAspCore.Data.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public string Img { get; set; }
    public double Price { get; set; }
    public bool IsFavourite { get; set; }
    public bool Available { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}