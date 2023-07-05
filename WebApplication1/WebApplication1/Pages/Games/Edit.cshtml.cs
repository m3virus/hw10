using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Model;
using Services.Interface;
using System.IO;

namespace Store.Pages.Games
{

    public class EditModel : PageModel
    {

        private readonly IGameRepository _gameRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IGameRepository gameRepository, IWebHostEnvironment webHostEnvironment)
        {
            _gameRepository = gameRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Game Game { get; set; }

        [BindProperty]
        public IFormFile NewPhoto { get; set; }

        public IActionResult OnGet(int id)
        {
            Game = _gameRepository.GetGameById(id);

            if (Game == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productToUpdate = _gameRepository.GetGameById(Game.ID);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (NewPhoto != null)
            {
                if (productToUpdate.Photo != null)
                {

                    string currentPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", productToUpdate.Photo);
                    if (System.IO.File.Exists(currentPhotoPath))
                    {
                        System.IO.File.Delete(currentPhotoPath);
                    }
                }


                string uniqueFileName = Guid.NewGuid().ToString() + "_" + NewPhoto.FileName;
                string newPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);

                using (var fileStream = new FileStream(newPhotoPath, FileMode.Create))
                {
                    await NewPhoto.CopyToAsync(fileStream);
                }

                productToUpdate.Photo = uniqueFileName;
            }



           // _gameRepository.UpdateGame(productToUpdate);

            return RedirectToPage("/games/Index");
        }
    }
}
    
