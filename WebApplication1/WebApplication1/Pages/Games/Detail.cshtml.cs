using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using Services.Interface;

namespace Store.Pages.Games
{
   
    public class DetailModel : PageModel
    {
        
        private readonly IGameRepository _gameRepository;

        public Game Games{ get; private set; }

        public DetailModel(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        [TempData]
        public string NotificationMessage { get; set; }

        public IGameRepository GameRepository => _gameRepository;

        public IActionResult OnGet(int id)
        {
            Games = GameRepository.GetGameById(id);

            if (Games == null)
            {
                return NotFound();
            }
            TempData["NotificationMessage"] = "here is your game";
            return Page();

        }
    }
}
