using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlApi;
using Dal;

namespace BlImplementation
{
    internal class Order : BlApi.IOrder
    {
        private DalApi.IDal Dal = new DalList();
        private BO.Enums.OrderStatus GetStatus(DO.Order order)
        {
            return order.ShipDate == DateTime.MinValue ? BO.Enums.OrderStatus.Approved : order.DeliveryDate == DateTime.MinValue ? BO.Enums.OrderStatus.Shipped : BO.Enums.OrderStatus.Delivered;
        }

        private List<BO.OrderItem> GetLogicItems(IEnumerable<DO.OrderItem> listD)
        {
            List<BO.OrderItem> listB=new List<BO.OrderItem>();
            foreach (DO.OrderItem item in listD)
            {
                BO.OrderItem orderItem = new BO.OrderItem()
                {
                    ID = item.ID,
                    ProductId = item.ProductID,
                    Name = Dal._product.Get(item.ProductID)?.Name,
                    Price = item.Price,
                    Amount = item.Amount,
                    TotalPrice = item.Amount * item.Price
                };
                listB.Add(orderItem);
            }
            return listB;
        }
        public IEnumerable<BO.OrderForList> Get()
        {
            var orders = Dal._order.Get();
            var ordersList = new List<BO.OrderForList>();
            foreach (var order in orders)
            {
                BO.OrderForList orderForList = new BO.OrderForList()
                {
                    ID = order?.ID ?? throw new NullReferenceException(),
                    CustomerName = order?.CustomerName,
                    Status = GetStatus((DO.Order)order!),
                    AmountOfItems = Dal._orderItem.GetOrderItems((int)(order?.ID!)).Count(),
                    TotalPrice = (double)Dal._orderItem.GetOrderItems((int)(order?.ID!)).Sum(x => x?.Price)!
                };
                ordersList.Add(orderForList);
            }
            return ordersList;
        }
        public BO.Order GetOrderDetails(int ID)
        {
            try
            {
                if (ID > 0)
                {
                    var orderD = Dal._order.Get(ID);
                    var orderB = new BO.Order()
                    {
                        ID = ID,
                        CustomerName = orderD?.CustomerName,
                        CustomerEmail = orderD?.CustomerEmail,
                        CustomerAddress = orderD?.CustomerAddress,
                        Status = GetStatus((DO.Order)orderD!),
                        OrderDate = orderD?.OrderDate,
                        ShipDate = orderD?.ShipDate,
                        DeliveryDate = orderD?.DeliveryDate,
                        Items = GetLogicItems((IEnumerable<DO.OrderItem>)Dal._orderItem.GetOrderItems((int)(orderD?.ID!)))!,
                        TotalPrice = (double)Dal._orderItem.GetOrderItems((int)(orderD?.ID!)).Sum(x => x?.Price)!
                    };
                    return orderB;
                }
                else throw new InvalidDataException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.Order UpdateShipping(int ID)
        {
            try
            {
                var orderD = Dal._order.Get(ID);
                if (orderD?.ShipDate == DateTime.MinValue)
                {
                    orderD.ShipDate = DateTime.Now;
                    var orderB = GetOrderDetails(ID);
                    orderB.ShipDate = orderD?.ShipDate;
                    Dal._order.Update(orderD ?? throw new NullReferenceException());
                    return orderB;
                }
                else throw new BO.Exceptions.DoneAlreadyException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.Order UpdateDelivery(int ID)
        {
            try
            {
                var orderD = Dal._order.Get(ID);
                if (orderD?.ShipDate == DateTime.MinValue) throw new BO.Exceptions.NotShippedYetException();
                if (orderD?.DeliveryDate == DateTime.MinValue)
                {
                    orderD.DeliveryDate = DateTime.Now;
                    var orderB = GetOrderDetails(ID);
                    orderB.DeliveryDate = orderD?.DeliveryDate;
                    Dal._order.Update(orderD ?? throw new NullReferenceException());
                    return orderB;
                }
                else throw new BO.Exceptions.DoneAlreadyException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.OrderTracking Track(int ID)
        {
            try
            {
                var order = Dal._order.Get(ID);
                BO.OrderTracking orderTracking = new BO.OrderTracking()
                {
                    ID = order?.ID ?? throw new NullReferenceException(),
                    Status = GetStatus(order ?? throw new NullReferenceException()),
                    OrderDiary = new Dictionary<DateTime, BO.Enums.OrderStatus>() 
                };
                orderTracking.OrderDiary.Add(order?.OrderDate ?? throw new NullReferenceException(), BO.Enums.OrderStatus.Approved);//TODO if this outputs a number, then use toStirng, and change orderDiary def to string
                if (order?.ShipDate != DateTime.MinValue)
                {
                    orderTracking.OrderDiary.Add(order?.ShipDate ?? throw new NullReferenceException(), BO.Enums.OrderStatus.Shipped);
                    if (order?.DeliveryDate != DateTime.MinValue) orderTracking.OrderDiary.Add(order?.DeliveryDate ?? throw new NullReferenceException(), BO.Enums.OrderStatus.Delivered);
                }
                return orderTracking;
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.OrderItem Update(int orderID, int productID, int newAmount)
        {
            try
            {
                var orderItem = Dal._orderItem.Get(productID, orderID);
                var product = Dal._product.Get(productID);
                if (product?.InStock >= newAmount - orderItem?.Amount)
                {
                    orderItem.Amount = newAmount;
                    Dal._orderItem.Update((DO.OrderItem)orderItem!);
                    product.InStock -= newAmount - orderItem?.Amount;
                    Dal._product.Update(product ?? throw new NullReferenceException());
                    orderItem = Dal._orderItem.Get(productID, orderID);
                    product = Dal._product.Get(productID);
                    return new BO.OrderItem()
                    {
                        ID = orderItem?.ID ?? throw new ArgumentNullException(),
                        ProductId = orderItem?.ProductID ?? throw new ArgumentNullException(),
                        Name = product?.Name,
                        Price = orderItem?.Price ?? throw new NullReferenceException(),
                        Amount = orderItem?.Amount ?? throw new NullReferenceException(),
                        TotalPrice = orderItem?.Price * orderItem?.Amount ?? throw new NullReferenceException()
                    };
                }
                else throw new BO.Exceptions.InsufficientStockException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
    }
}
