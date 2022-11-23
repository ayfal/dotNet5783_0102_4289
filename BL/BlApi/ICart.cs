using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    public interface ICart
    {
        public Cart AddProduct(Cart cart, int productID);
        public Cart UpdateAmount(Cart cart, int productID, int amount);
        public void Checkout(Cart cart, string customerName, string Email, string address);
    }
}
