using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderItem
    {
        /// <summary>
        /// the order-item's ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the product's ID
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// the product's name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// the product's price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// the product's amount
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// the product's total price
        /// </summary>
        public double TotalPrice { get; set; }

        public override string ToString() => this.AutoToString();
    }
}
