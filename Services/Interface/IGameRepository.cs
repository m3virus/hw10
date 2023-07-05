
using Model;

namespace Services.Interface
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int id);
    }
}