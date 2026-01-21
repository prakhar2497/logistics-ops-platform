using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Enums
{
    public static class VehicleType
    {
        public static readonly ReferenceData Van = new ReferenceData
        {
            Id = new Guid("74D582C1-BEF6-F011-98AD-94E97958798A"),
            Code = "Van"
        };

        public static readonly ReferenceData Truck = new ReferenceData
        {
            Id = new Guid("0E167DD5-BEF6-F011-98AD-94E97958798A"),
            Code = "Truck"
        };
    }
}
