
using Services;
using Model;

namespace Services.Interface
{
    public interface IGameRepository
    {
        //void DeleteGameById(int id);
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int id);
    }
}