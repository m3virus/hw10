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

        public IActionResult OnGet(int id)
        {
            Games = _gameRepository.GetGameById(id);

            if (Games == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
