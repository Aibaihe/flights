using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDAC_Flight_System.Models;
using Microsoft.AspNetCore.Http;

namespace DDAC_Flight_System.Controllers
{
    public class BookFlightController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private FlightDbContext _context;

        public BookFlightController(FlightDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            _session.SetString("origin", "KL");
            var viewModel = new ViewModel(_context, _session);
            return View("~/Views/Main/BookFlight.cshtml", viewModel);
        }

        public IActionResult BookFlight(int id)
        {
            _session.SetString("selectedFlight",id.ToString());
            var viewModel = new ViewModel(_context, _session);
            return View("~/Views/Main/BookFlightDetail.cshtml", viewModel);
        }

        public IActionResult BookFlightDetail(int classId)
        {

            var flight = _context.Flights.Find(Int32.Parse(_session.GetString("selectedFlight")));
            var customer = _context.Customers.Find(Int32.Parse(_session.GetString("usernow")));
            var travelClass = _context.TravelClasses.Find(1);

            var reservation = new Reservation
            {
                FlightID = flight,
                CustomerID = customer,
                TravelClassID = travelClass,
                TotalPrice = travelClass.ClassPrice + flight.price,
                Status = "false"
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            
            var viewModel = new ViewModel(_context, _session);
            return View("~/Views/Main/Main.cshtml", viewModel);
        }

        //searching
    }
}