using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    /// <summary>
    /// handles the shopping cart
    /// </summary>
    public interface ICart
    {
        /// <summary>
        /// add a product to the cart
        /// </summary>
        /// <param name="cart">the shopping cart</param>
        /// <param name="productID">the product's ID</param>
        /// <returns>the updated cart</returns>
        public Cart AddProduct(Cart cart, int productID);
        /// <summary>
        /// updates the amount of a product in the cart
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="productID"></param>
        /// <param name="amount">the new amount</param>
        /// <returns>the updated cart</returns>
        public Cart UpdateAmount(Cart cart, int productID, int amount);
        /// <summary>
        /// checkout and make and order
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="customerName"></param>
        /// <param name="Email"></param>
        /// <param name="address"></param>
        /// <returns>the order made from cart</returns>
        public BO.Order Checkout(Cart cart, string customerName, string Email, string address);
    }
}
