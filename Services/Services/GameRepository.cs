using Services.Interface;
using Telegram.Bot.Types;
using Model;

namespace Services.Services
{
    internal class GameRepository : IGameRepository
    {
        private List<Model.Game> _games;

        public GameRepository()
        {
            _games = new List<Model.Game>() { 
            
            new Model.Game { ID = 1, Name ="Game1", Barcode="12345667g", Description = "battleroyale", Photo = "", Price = 122.22M},
            new Model.Game { ID = 2, Name ="Game2", Barcode="45rfwg3215", Description = "deathrun", Photo = "", Price = 12.22M}

            };

        }

        public IEnumerable<Model.Game> GetAllGames()
        {
           return _games;
        }

        public Model.Game GetGameById(int id)
        {
            return _games.FirstOrDefault(p => p.ID == id);
        }
    }
}
