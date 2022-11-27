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
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Cart AddProduct(Cart cart, int productID);
        public Cart UpdateAmount(Cart cart, int productID, int amount);
        public void Checkout(Cart cart, string customerName, string Email, string address);
    }
}
