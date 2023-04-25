using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using CoffeeShop.Models;


namespace CoffeeShop.Models
{
    public class ContactForm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}