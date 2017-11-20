using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Flight_System.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public virtual Customer CustomerID { get; set; }
        public virtual Flight FlightID { get; set; }
        public virtual TravelClass TravelClassID { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
