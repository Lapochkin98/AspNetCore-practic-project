using TestAspCore.Data.Interfaces;
using TestAspCore.Data.Models;

namespace TestAspCore.Data.Mocks;

public class MockCategory : IGamesCategory
{
    public IEnumerable<Category> AllCategories =>
        new List<Category>
        {
            new Category { CategoryName = "Action", Desc = "Category for action-packed games" },
            new Category { CategoryName = "Adventure", Desc = "Category for immersive adventure games" }
        };
}