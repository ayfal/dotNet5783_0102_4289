using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
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
        public Enums.Category? Category { get; set; }
        /// <summary>
        /// the product's amount in the stock
        /// </summary>
        public int InStock { get; set; }

        public override string ToString() => this.AutoToString();// $@"
//        Product ID: {ID}, 
//        Name: {Name}, 
//        category: {Category}
//    	Price: {Price}
//    	Amount in stock: {InStock}
//";
    }
}
