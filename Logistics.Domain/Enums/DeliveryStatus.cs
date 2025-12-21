using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Domain.Enums
{
    public class DeliveryStatus
    {
        public static string Pending => "9703424E-66DE-F011-98AC-94E97958798A";
        public static string Assigned => "9803424E-66DE-F011-98AC-94E97958798A";
        public static string InTransit => "9903424E-66DE-F011-98AC-94E97958798A";
        public static string Delivered => "9A03424E-66DE-F011-98AC-94E97958798A";
        public static string Delayed => "9B03424E-66DE-F011-98AC-94E97958798A";
    }
}
