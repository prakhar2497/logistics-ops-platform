using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Enums
{
    public static class IssueSeverity
    {
        public static readonly ReferenceData Low = new ReferenceData
        {
            Id = Guid.Parse("9403424E-66DE-F011-98AC-94E97958798A"),
            Code = "Low"
        };

        public static readonly ReferenceData Medium = new ReferenceData
        {
            Id = Guid.Parse("9503424E-66DE-F011-98AC-94E97958798A"),
            Code = "Medium"
        };

        public static readonly ReferenceData High = new ReferenceData
        {
            Id = Guid.Parse("9603424E-66DE-F011-98AC-94E97958798A"),
            Code = "High"
        };
    }
}
