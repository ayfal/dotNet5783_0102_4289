using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductItem
    {
        /// <summary>
        /// the product's ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the product's name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// the product's price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// the product's category
        /// </summary>
        public BO.Enums.Category? Category { get; set; }
        /// <summary>
        /// is the product in stock
        /// </summary>
        public bool InStock { get; set; }
        /// <summary>
        /// the product's amount int the shopping cart
        /// </summary>
        public int Amount { get; set; }
        public override string ToString() => this.AutoToString();
        //$@"
        //ID: {ID}
        //Name {Name}
        //Price {Price}
        //Category {Category}
        //In Stock {InStock}
        //Amount {Amount}";
    }
}
