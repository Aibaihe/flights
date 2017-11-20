using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDAC_Flight_System.Models;
using Microsoft.AspNetCore.Http;

namespace DDAC_Flight_System.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private FlightDbContext _context;

        public HomeController(FlightDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MainPanel()
        {
            var check = _session.GetString("isExisted");
            if (check == null)
            {
                return View("~/Views/Login/Login.cshtml");
            }
            else
            {
                if (check == "false")
                {
                    return View("~/Views/Login/Login.cshtml");
                }
                else
                {
                    var viewModel = new ViewModel(_context, _session);
                    return View("~/Views/Main/Main.cshtml", viewModel);
                }
            }
        }

        public IActionResult BookingFlight()
        {
            var check = _session.GetString("isExisted");
            if (check == null)
            {
                return View("~/Views/Login/Login.cshtml");
            }
            else
            {
                if (check == "false")
                {
                    return View("~/Views/Login/Login.cshtml");
                }
                else
                {
                    var viewModel = new ViewModel(_context, _session);
                    return View("~/Views/Main/BookFlight.cshtml", viewModel);
                }
            }
        }

        public IActionResult ViewFlightRecord()
        {
            var check = _session.GetString("isExisted");
            if (check == null)
            {
                return View("~/Views/Login/Login.cshtml");
            }
            else
            {
                if (check == "false")
                {
                    return View("~/Views/Login/Login.cshtml");
                }
                else
                {
                    var viewModel = new ViewModel(_context, _session);
                    return View("~/Views/Main/ViewRecord.cshtml", viewModel);
                }
            }
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
