using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using Services.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Store.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly IGameRepository _gamesRepository;

        public IEnumerable<Game> Games { get; private set; }

        public IndexModel (IGameRepository gamesRepository)
        {
            this._gamesRepository = gamesRepository;
        }

        

        public void OnGet()
        {
            Games = _gamesRepository.GetAllGames();
        }
    }
}
