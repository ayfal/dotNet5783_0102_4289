﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;
using System.Xml.Linq;

namespace BO
{
    public class OrderForList
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public Enums.OrderStatus Status { get; set; }
        public int AmountOfItems { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString() => $@"
        ID: {ID}
        Customer Name {CustomerName}        
        Status {Status}
        Amount Of Items {AmountOfItems}
        Total Price {TotalPrice}";
    }
}
