using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;
using System.Xml.Linq;
using System.Collections;

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }
        public Enums.OrderStatus Status { get; set; }
        public Dictionary<DateTime, Enums.OrderStatus> OrderDiary { get; set; }
        public override string ToString() => $@"
ID: {ID}
Status: {Status}
OrderDiary:
{string.Join(Environment.NewLine, OrderDiary)}";//TODO this might need further stringing
    }
}
