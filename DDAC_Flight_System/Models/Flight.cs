using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Flight_System.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public decimal price { get; set; }
        public bool flightStatus { get; set; }
    }
}
