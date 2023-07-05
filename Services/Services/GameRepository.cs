using Services.Interface;
using Model;

namespace Services.Services
{
    internal class GameRepository : IGameRepository
    {
        private List<Game> _games;

        public GameRepository()
        {
            _games = new List<Game>() { 
            
            new Game { ID = 1, Name ="Game1", Barcode="12345667g", Description = "battleroyale", Photo = "", Price = 122.22M},
            new Game { ID = 2, Name ="Game2", Barcode="45rfwg3215", Description = "deathrun", Photo = "", Price = 12.22M}

            };

        }

        public IEnumerable<Game> GetAllGames()
        {
           return _games;
        }

        public Game GetGameById(int id)
        {
            return _games.FirstOrDefault(p => p.ID == id);
        }
        public void DeleteGameById(int id)
        {
            Game deleteGame = _games.FirstOrDefault(p => p.ID == id);
            if (deleteGame != null)
            {
                _games.Remove(deleteGame);
            }
            
            
        }
    }
}
