﻿using System;
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
        public BO.Cart AddProduct(BO.Cart cart, int productID)
        {
            try
            {
                var product = Dal._product.Get(productID);
                if (product.InStock == 0) throw new BO.Exceptions.InsufficientStockException();
                BO.OrderItem? item;
                try
                {
                    item = cart.Items.First(p => p.ID == productID);
                    item.Amount++;//TODO check if this updates the item in the list in the cart
                    item.TotalPrice += product.Price;
                }
                catch (ArgumentNullException)
                {
                    item = new BO.OrderItem()
                    {
                        ID = 0,
                        ProductId = productID,
                        Name = product.Name,
                        Price = product.Price,
                        Amount = 1,
                        TotalPrice = product.Price
                    };
                    cart.Items.Add(item); //TODO לעשות את בקשת פרטי מוצר ולקחת משם                     
                }
                cart.TotalPrice += product.Price;
                return cart;
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.Cart UpdateAmount(BO.Cart cart, int productID, int amount)
        {
            if (amount < 0) throw new InvalidDataException();
            try
            {
                var item = cart.Items.First(p => p.ID == productID);
                double difference = (amount - item.Amount);
                if (Dal._product.Get(productID).InStock < difference) throw new BO.Exceptions.InsufficientStockException();
                if (amount > 0)
                {
                    item.Amount = amount;//TODO check if this updates the item in the list in the cart
                    item.TotalPrice = amount * item.Price;
                }
                else
                {
                    //difference*=item.Price;
                    cart.Items.Remove(item);
                }
                cart.TotalPrice += difference * item.Price;
                return cart;
            }
            catch (ArgumentNullException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public void Checkout(BO.Cart cart, string customerName, string Email, string address)
        {
            try
            {
                foreach (var item in cart.Items)
                {
                    if (Dal._product.Get(item.ID).InStock<item.Amount) throw new BO.Exceptions.InsufficientStockException();//check that all the products exist and that there's enough in stock
                    if (item.Amount <= 0 || customerName=="" || Email=="" || address=="") throw new InvalidDataException();
                    try { new System.Net.Mail.MailAddress(Email); } catch (FormatException) { throw new InvalidDataException(); }//the definition of a valid Email address is disputed (google it),and we settled for .NET's defintion
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
