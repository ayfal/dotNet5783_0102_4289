using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        /// <summary>
        /// the order's id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the customer's name
        /// </summary>
        public string? CustomerName { get; set; }
        /// <summary>
        /// the customer's Email
        /// </summary>
        public string? CustomerEmail { get; set; }
        /// <summary>
        /// the customer's address
        /// </summary>
        public string? CustomerAddress { get; set; }
        /// <summary>
        /// the order's status
        /// </summary>
        public Enums.OrderStatus? Status { get; set; }
        /// <summary>
        /// the order's date
        /// </summary>
        public DateTime? OrderDate { get; set; }
        /// <summary>
        /// the shipping's date
        /// </summary>
        public DateTime? ShipDate { get; set; }
        /// <summary>
        /// the delivery's date
        /// </summary>
        public DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// a list of all the products in the order
        /// </summary>
        public List<OrderItem?>? Items { get; set; }
        /// <summary>
        /// the order's total price
        /// </summary>
        public double TotalPrice { get; set; }

        public override string ToString() => $@"
        Order ID: {ID}
        Customer name: {CustomerName}
    	Email: {CustomerEmail}
        Address: {CustomerAddress}
        Status: {Status}
        Order Date: {OrderDate}
        Ship Date: {ShipDate}
        Delivery Date: {DeliveryDate}  
        Items: {string.Join(", ", Items!)}
        TotalPrice: {TotalPrice}
";
    }
}
