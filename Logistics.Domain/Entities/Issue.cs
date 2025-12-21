using Logistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Entities
{
    public class Issue
    {
        public Guid Id { get; set; }
        public Guid DeliveryId { get; set; }
        public Delivery Delivery { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Guid Severity { get; set; } // Low, Medium, High
        public DateTime CreatedAt { get; set; }
    }
}
