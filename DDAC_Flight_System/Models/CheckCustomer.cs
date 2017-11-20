using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Flight_System.Models
{
    public class CheckCustomer
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not matched!")]
        public string RePassword { get; set; }
    }
}
