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
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public Enums.OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderItem Items { get; set; }
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
        Items: {Items}
        TotalPrice: {TotalPrice}
";
    }
}
