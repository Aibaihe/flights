using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDAC_Flight_System.Models
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions options) :  base(options)
        {
        }

        public DbSet<TravelClass> TravelClasses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
