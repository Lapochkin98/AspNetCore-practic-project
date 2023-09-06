using TestAspCore.Data.Models;

namespace TestAspCore.Data.Interfaces;

public interface IAllGames
{
    IEnumerable<Game> Games { get;}
    IEnumerable<Game> GetFavouriteGame { get;}
    Game GetObjectGame(int gameId);
}