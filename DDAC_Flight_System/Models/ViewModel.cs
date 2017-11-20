using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Flight_System.Models
{
    public class ViewModel
    {
        public ISession _session;
        public FlightDbContext _context;

        public ViewModel(FlightDbContext context, ISession session)
        {
            _session = session;
            _context = context;
        }

        public Customer getCustomer()
        {
            var usernowId = Int32.Parse(_session.GetString("usernow"));
            return _context.Customers.Find(usernowId);
        }

        public List<Flight> getFlights()
        {
            var origin = _session.GetString("origin");
            //var flights = _context.Flights.Where(a => a.origin == origin).ToList();
            var flights = _context.Flights.ToList();
            return flights;
        }

        public Flight getFlight()
        {
            var id = Int32.Parse(_session.GetString("selectedFlight"));
            return _context.Flights.Find(id);
        }

        public List<TravelClass> getClasses()
        { 
            return _context.TravelClasses.ToList();
        }

        public List<Reservation> getReservations()
        {
            return _context.Reservations.Where(a => a.CustomerID == getCustomer()).ToList();
        }
    }
}
