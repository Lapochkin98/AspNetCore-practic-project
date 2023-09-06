using TestAspCore.Data.Models;

namespace TestAspCore.Data.Interfaces;

public interface IGamesCategory
{
    IEnumerable<Category> AllCategories { get; }
}