using TestAspCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TestAspCore.Data;

public class AppDbContent : DbContext
{
    public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
    {
        
    }

    public DbSet<Game> Game { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<ShopCartItem> ShopCartItem { get; set; }
}