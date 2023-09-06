namespace TestAspCore.Data.Models;

public class Category
{
    public int Id { set; get; }
    public string CategoryName { set; get; }
    public string Desc { get; set; }
    public List<Game> Games { get; set; }
}