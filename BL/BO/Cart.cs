using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Cart
    {
        /// <summary>
        /// customer's name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// customer's Email
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// customer's address
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// a list of all the products in the order
        /// </summary>
        public List<OrderItem> Items { get; set; }
        /// <summary>
        /// the total price of the order
        /// </summary>
        public double TotalPrice { get; set; }

        public override string ToString() => $@"
        Customer name: {CustomerName}
    	Email: {CustomerEmail}
        Address: {CustomerAddress}
        Items: {string.Join(", ",Items)}
        TotalPrice: {TotalPrice}
";
    }
}
