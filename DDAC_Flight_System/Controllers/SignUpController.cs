using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDAC_Flight_System.Models;

namespace DDAC_Flight_System.Controllers
{
    public class SignUpController : Controller
    {
        private FlightDbContext _context;
        public SignUpController(FlightDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/SignUp/SignUp.cshtml");
        }

        [HttpPost]
        public IActionResult SignUp(CheckCustomer customer)
        {
            if (!ModelState.IsValid) {
                return View();
            }
            var _customer = new Customer
            {
                email = customer.Email,
                name = customer.Name,
                password = customer.Password
            };
            _context.Add(_customer);
            _context.SaveChanges();
            return View("~/Views/Login/Login.cshtml");
        }
    }
}