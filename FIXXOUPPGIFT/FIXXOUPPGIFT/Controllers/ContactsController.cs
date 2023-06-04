using FIXXOUPPGIFT.Services;
using FIXXOUPPGIFT.ViewModels;
using FIXXOUPPGIFT.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FIXXOUPPGIFT.Controllers
{
    public class ContactsController : Controller
    {
        private readonly CommentsService _commentService;

        public ContactsController(CommentsService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            //ContactFormViewModel model = new ContactFormViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.CreateAsync(model);

                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Account");

                ModelState.AddModelError("", "Incorrect input");
            }

            return View(model);
        }
    }
}
