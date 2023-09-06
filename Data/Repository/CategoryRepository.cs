using TestAspCore.Data.Interfaces;
using TestAspCore.Data.Models;

namespace TestAspCore.Data.Repository;

public class CategoryRepository : IGamesCategory
{
    
    private readonly AppDbContent _appDbContent;

    public CategoryRepository(AppDbContent appDbContent)
    {
        this._appDbContent = appDbContent;
    }

    public IEnumerable<Category> AllCategories => _appDbContent.Category;
}