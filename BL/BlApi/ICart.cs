using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
/// <summary>
/// 
/// </summary>
    public interface ICart
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Cart AddProduct(Cart cart, int productID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="productID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Cart UpdateAmount(Cart cart, int productID, int amount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="customerName"></param>
        /// <param name="Email"></param>
        /// <param name="address"></param>
        public BO.Order Checkout(Cart cart, string customerName, string Email, string address);
    }
}
