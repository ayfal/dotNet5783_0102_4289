using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;
using System.Xml.Linq;

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }
        public Enums.OrderStatus Status { get; set; }
        public Dictionary<> OrderDiary { get; set; }
        public override string ToString() => $@"
        ID: {ID}
        Status {Status}
        OrderDiary {OrderDiary}";
    }
}
