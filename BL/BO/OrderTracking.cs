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
        /// <summary>
        /// the order's ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the order's status
        /// </summary>
        public Enums.OrderStatus? Status { get; set; }
        /// <summary>
        /// the order's diary. lists all events and their date
        /// </summary>
        public Dictionary<DateTime, Enums.OrderStatus>? OrderDiary { get; set; }
        public override string ToString() => this.AutoToString(); //why isn't it working? it exactly the same code?
//            $@"
//ID: {ID}
//Status: {Status}
//OrderDiary:
//{string.Join(Environment.NewLine, OrderDiary!)}";//TODO this might need further stringing
    }
}
