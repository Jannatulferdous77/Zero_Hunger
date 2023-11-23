using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.Entity_Framework;

namespace ZeroHunger.DTOs
{
    public class CollectRequestDTO
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int? EmployeeId { get; set; }
        public System.DateTime Time { get; set; }
        public System.DateTime MaximumPreserveTime { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionTime { get; set; }
    }
}