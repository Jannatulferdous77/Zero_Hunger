using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class RestaurantDTO
    {
        public int Id { get; set; }

        [Required]
        [Display]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }
}