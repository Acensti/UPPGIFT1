using Microsoft.AspNetCore.Mvc;

namespace FIXXOUPPGIFT.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
