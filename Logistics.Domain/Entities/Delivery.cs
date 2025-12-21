using Logistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Entities
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; } = default!;
        public string SourceAddress { get; set; } = default!;
        public string DestinationAddress { get; set; } = default!;
        public double DistanceInKm { get; set; }
        public double EstimatedTimeInHours { get; set; }
        public Guid Status { get; set; } // Pending, Assigned, InTransit, Delivered, Delayed
        public decimal Revenue { get; set; }
        public Guid? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public ICollection<Issue> Issues { get; set; } = new List<Issue>();
    }
}
