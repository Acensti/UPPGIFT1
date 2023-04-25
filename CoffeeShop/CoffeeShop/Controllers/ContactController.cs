using System;
using System.Net.Mail;
using CoffeeShop.Data;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ContactController : Controller
    {
        private readonly CoffeeShopDbContext _context;

        public ContactController(CoffeeShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a new Contact object and set its properties
                    var contact = new Contact
                    {
                        Name = contactForm.Name,
                        Email = contactForm.Email,
                        Message = contactForm.Message,
                        CreatedAt = DateTime.Now
                    };

                    // Add the Contact object to the database and save changes
                    _context.Contacts.Add(contact);
                    _context.SaveChanges();

                    // Send an email notification
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("youremail@example.com");
                    mailMessage.To.Add("recipient@example.com");
                    mailMessage.Subject = "New contact form submission";
                    mailMessage.Body = $"Name: {contactForm.Name}\nEmail: {contactForm.Email}\n\nMessage:\n{contactForm.Message}";

                    SmtpClient smtpClient = new SmtpClient
                    {
                        Host = "smtp.example.com", // Replace with your SMTP server
                        Port = 587,
                        Credentials = new System.Net.NetworkCredential("username", "password"), // Replace with your credentials
                        EnableSsl = true,
                    };

                    smtpClient.Send(mailMessage);

                    return Json(new { success = true });
                }
                catch
                {
                    return Json(new { success = false });
                }
            }
            return Json(new { success = false });
        }
    }
}
