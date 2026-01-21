using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.DTOs
{
    public class VehicleRequest
    {
        public string RegistrationNumber { get; set; } = default!;
        public string Type { get; set; } = default!;
        public double CapacityInKg { get; set; }
    }
}
