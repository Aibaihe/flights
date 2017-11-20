using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Flight_System.Models
{
    public class Customer
    {
        public int customerID { get; set; }
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
