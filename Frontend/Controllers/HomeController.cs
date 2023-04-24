using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;

        public HomeController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _apiService.GetFeaturedProductsAsync();
            var newProducts = await _apiService.GetNewProductsAsync();
            var popularProducts = await _apiService.GetPopularProductsAsync();

            ViewBag.FeaturedProducts = featuredProducts;
            ViewBag.NewProducts = newProducts;
            ViewBag.PopularProducts = popularProducts;

            return View();
        }
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _apiService.GetProductByIdAsync(id);
            return View(product);
        }
        public IActionResult Contact()
        {
            return View();
        }
        // Add this method inside HomeController class
        [HttpPost]
        public async Task<IActionResult> SubmitContactForm(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                await _apiService.SubmitContactFormAsync(contactForm);
                TempData["MessageSent"] = true;
                return RedirectToAction("Contact");
            }

            return View("Contact");
        }
        
    }
}
