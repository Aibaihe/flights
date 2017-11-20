using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDAC_Flight_System.Models;
using Microsoft.AspNetCore.Http;

namespace DDAC_Flight_System.Controllers
{
    public class LoginController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private FlightDbContext _context;

        public LoginController(FlightDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        [HttpPost]
        public IActionResult LoginAs(Customer customer)
        {
            var customers = _context.Customers;
            foreach (var c in customers)
            {
                if (c.email.Equals(customer.email) && c.password.Equals(customer.password))
                {
                    _session.SetString("usernow",c.customerID.ToString());
                    _session.SetString("isExisted", "true");
                    var viewModel = new ViewModel(_context, _session);
                    return View("~/Views/Main/Main.cshtml", viewModel);
                }
            }
            return View("~/Views/Login/Login.cshtml");
        }
        public IActionResult Logout()
        {
            _session.Clear();
            return View("~/Views/Home/Index.cshtml");
        }
    }
}