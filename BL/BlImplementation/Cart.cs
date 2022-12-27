using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;

namespace BlImplementation
{
    internal class Cart : BlApi.ICart
    {
        private DalApi.IDal? dal = DalApi.Factory.Get();
        public BO.Cart AddProduct(BO.Cart cart, int productID)
        {
            try
            {
                var product = dal?.product.Get(productID) ?? throw new NullReferenceException();
                if (product.InStock == 0) throw new BO.Exceptions.InsufficientStockException();
                BO.OrderItem? item;
                try
                {
                    item = cart.Items?.First(p => p?.ProductID == productID);
                    item!.Amount++;
                    item.TotalPrice += product.Price;
                }
                catch
                {
                    item = new BO.OrderItem()
                    {
                        ID = 0,
                        ProductID = productID,
                        //Name = product.Name,
                        //Price = product.Price,
                        Amount = 1,
                        TotalPrice = product.Price
                    };
                    item.CopyProperties(product);
                    cart.Items?.Add(item);
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
                var item = cart.Items?.First(p => p?.ProductID == productID);
                int difference = amount - item?.Amount ?? throw new NullReferenceException();
                if (dal?.product.Get(productID)?.InStock < difference) throw new BO.Exceptions.InsufficientStockException();
                if (amount > 0)
                {
                    item!.Amount = amount;//TODO check if this updates the item in the list in the cart
                    item.TotalPrice = amount * item.Price;
                }
                else
                {
                    //difference*=item.Price;
                    cart.Items?.Remove(item);
                }
                cart.TotalPrice += difference * item!.Price;
                return cart;
            }
            catch (InvalidOperationException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }        
        public BO.Order Checkout(BO.Cart cart, string customerName, string Email, string address)
        {
            try
            {
                foreach (var item in cart.Items!)
                {
                    if (dal?.product.Get(item!.ProductID)?.InStock < item?.Amount) throw new BO.Exceptions.InsufficientStockException();//check that all the products exist and that there's enough in stock
                    if (item?.Amount <= 0 || customerName == "" || Email == "" || address == "") throw new InvalidDataException();
                    try { new System.Net.Mail.MailAddress(Email); } catch (FormatException) { throw new InvalidDataException(); }//the definition of a valid Email address is disputed (google it),and we settled for .NET's defintion
                }
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
            DO.Order order = new DO.Order()
            {
                ID = 0,
                CustomerName = customerName,
                CustomerEmail = Email,
                CustomerAddress = address,
                OrderDate = DateTime.Now,
                ShipDate = null,
                DeliveryDate = null,
            };
            int orderID = dal?.order.Add(order) ?? throw new NullReferenceException();
            foreach (var item in cart.Items)
            {
                DO.OrderItem orderItem = new DO.OrderItem()
                {
                    ID = 0,
                    //ProductID = item!.ProductID,
                    OrderID = orderID,
                    //Price = item.Price,
                    //Amount = item.Amount
                };
                orderItem.CopyProperties(item);
                dal?.orderItem.Add(orderItem);
                int inStock = dal?.product.Get(item.ProductID)?.InStock ?? throw new NullReferenceException();
                if (inStock < item.Amount) throw new BO.Exceptions.InsufficientStockException();
                inStock -= item.Amount;
            }
            BlImplementation.Order orderb = new BlImplementation.Order();
            return orderb.GetOrderDetails(orderID);
        }
    }
}
