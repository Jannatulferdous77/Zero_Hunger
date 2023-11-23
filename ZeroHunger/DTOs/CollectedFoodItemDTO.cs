using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class CollectedFoodItemDTO
    {
        public int Id { get; set; }
        public int CollectRequestId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Condition { get; set; }
        public string DistributionStatus { get; set; }
        public System.DateTime? DistributionCompletionTime { get; set; }
        public int MaximumPreserveTimeInHours { get; set; }
    }
}