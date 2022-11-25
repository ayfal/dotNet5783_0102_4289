using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using Dal;

namespace BlImplementation
{
    internal class Cart : BlApi.ICart
    {
        private DalApi.IDal Dal = new DalList();
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
                var item = Dal._product.Get(productID);
                cart.Items.Add(item); //TODO לעשות את בקשת פרטי מוצר ולקחת משם 
                
                cart.TotalPrice += item.Price;

            }
        }
        public Cart UpdateAmount(Cart cart, int productID, int amount);
        public void Checkout(Cart cart, string customerName, string Email, string address);

    }
}
