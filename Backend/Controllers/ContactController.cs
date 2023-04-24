using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // Add a constructor and a private field for the DbContext
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactForm([FromBody] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _context.ContactForms.Add(contactForm);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
