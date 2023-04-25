using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> _products = new()
        {
            // Add sample products here
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _products;
        }

        [HttpGet("featured")]
        public ActionResult<IEnumerable<Product>> GetFeatured()
        {
            return _products.Where(p => p.IsFeatured).ToList();
        }

        [HttpGet("new")]
        public ActionResult<IEnumerable<Product>> GetNew()
        {
            return _products.Where(p => p.IsNew).ToList();
        }

        [HttpGet("popular")]
        public ActionResult<IEnumerable<Product>> GetPopular()
        {
            return _products.Where(p => p.IsPopular).ToList();
        }
    }
}
