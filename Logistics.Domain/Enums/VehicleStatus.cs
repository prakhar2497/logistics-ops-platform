using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Enums
{
    public static class VehicleStatus
    {
        public static readonly ReferenceData Available = new ReferenceData
        {
            Id = Guid.Parse("9103424E-66DE-F011-98AC-94E97958798A"),
            Code = "Available"
        };

        public static readonly ReferenceData InTransit = new ReferenceData
        {
            Id = Guid.Parse("9103424E-66DE-F011-98AC-94E97958798A"),
            Code = "InTransit"
        };

        public static readonly ReferenceData Maintenance = new ReferenceData
        {
            Id = Guid.Parse("9103424E-66DE-F011-98AC-94E97958798A"),
            Code = "Maintenance"
        };
    }
}
