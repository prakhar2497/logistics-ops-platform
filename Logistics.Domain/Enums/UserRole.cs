using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Enums
{
    public static class UserRole
    {
        public static readonly ReferenceData Admin = new ReferenceData
        {
            Id = Guid.Parse("8E03424E-66DE-F011-98AC-94E97958798A"),
            Code = "Admin"
        };

        public static readonly ReferenceData Dispatcher = new ReferenceData
        {
            Id = Guid.Parse("8F03424E-66DE-F011-98AC-94E97958798A"),
            Code = "Dispatcher"
        };

        public static readonly ReferenceData Driver = new ReferenceData
        {
            Id = Guid.Parse("9003424E-66DE-F011-98AC-94E97958798A"),
            Code = "Driver"
        };

    }
}
