using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DalApi;
using Dal;

namespace BlImplementation
{
    internal class Cart : ICart
    {
        private IDal Dal = new DalList();
        public BO.Cart Add(BO.Cart cart, int productID)
        {
            if (cart.Items.Exists(p => p.ID == productID))
            {
                var item = cart.Items.First(p => p.ID == productID);
                if (Dal._product.Get(productID).InStock == 0)
                    throw new Exception("out of stock");
                else
                {
                    item.Amount++;
                    item.TotalPrice += item.Price;
                    cart.TotalPrice += item.Price;
                }
            }
            else if (cart.Items.Exists(p => p.ID == productID) && Dal._product.Get(productID).InStock > 0) // בודק אם המוצר קיים וישנו במלאי 
            {
                cart.TotalPrice += 
            }
        }
        public Cart UpdateAmount(Cart cart, int productID, int amount);
        public void Checkout(Cart cart, string customerName, string Email, string address);

    }
}
