using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.DTOs
{
    public class CreateVehicleDto
    {
        public string RegistrationNumber { get; set; } = default!;
        public Guid Type { get; set; } = default!;
        public double CapacityInKg { get; set; }
        public Guid Status { get; set; }
        public DateTime LastServiceDate { get; set; }
    }
}
