using Logistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; } = default!; // e.g. UP32XX0001
        public string Type { get; set; } = default!;               // Truck, Van, Bike
        public double CapacityInKg { get; set; }
        public Guid Status { get; set; }                  // Available, InTransit, Maintenance
        public DateTime LastServiceDate { get; set; }
        public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}
