using Logistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.DTOs
{
    public class VehicleFilter
    {
        public Guid? Status { get; set; }
        public Guid? Type { get; set; }
    }
}
