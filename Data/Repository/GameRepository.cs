using System.Data.Entity;
using TestAspCore.Data.Interfaces;
using TestAspCore.Data.Models;

namespace TestAspCore.Data.Repository;

public class GameRepository : IAllGames
{

    private readonly AppDbContent _appDbContent;

    public GameRepository(AppDbContent appDBContent)
    {
        this._appDbContent = appDBContent;
    }

    public IEnumerable<Game> Games => _appDbContent.Game.Include(g => g.Category);

    public IEnumerable<Game> GetFavouriteGame => _appDbContent.Game.Where(p => p.IsFavourite).Include(g => g.Category);

    public Game GetObjectGame(int gameId) => _appDbContent.Game.FirstOrDefault(p => p.Id == gameId);
}