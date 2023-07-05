using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using Services.Interface;

namespace Store.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly IGameRepository _gameRepository;

        public Game game { get; private set; }

        public DeleteModel(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult OnGet(int id)
        {
            game = _gameRepository.GetGameById(id);

            if (game == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
           // _gameRepository.DeleteGameById(id);
            return RedirectToPage("/Games/Index");
        }
    }
}
