using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
    }
}