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
    public class OrderForList
    {
        /// <summary>
        /// the order ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the customer's name
        /// </summary>
        public string? CustomerName { get; set; }
        /// <summary>
        /// the order's status
        /// </summary>
        public Enums.OrderStatus? Status { get; set; }
        /// <summary>
        /// the amount of items in the order
        /// </summary>
        public int AmountOfItems { get; set; }
        /// <summary>
        /// the order's total price
        /// </summary>
        public double TotalPrice { get; set; }
        public override string ToString() => $@"
        ID: {ID}
        Customer Name {CustomerName}        
        Status {Status}
        Amount Of Items {AmountOfItems}
        Total Price {TotalPrice}";
    }
}
