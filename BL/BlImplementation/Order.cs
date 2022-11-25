using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IEnumerable<BO.OrderForList> Get()
        {
            var orders = Dal._order.Get();
            IEnumerable<BO.OrderForList> ordersList = new List<BO.OrderForList>();
            foreach (var order in orders)
            {
                BO.OrderForList orderForList = new BO.OrderForList()
                {
                    ID = order.ID,
                    CustomerName = order.CustomerName,
                    Status = GetStatus(order),
                    AmountOfItems = Dal._orderItem.GetOrderItems(order.ID).Count(),
                    TotalPrice = Dal._orderItem.GetOrderItems(order.ID).Sum(x => x.Price)
                };
                ordersList.Append(orderForList);
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
                        CustomerName = orderD.CustomerName,
                        CustomerEmail = orderD.CustomerEmail,
                        CustomerAddress = orderD.CustomerAddress,
                        Status = GetStatus(orderD),
                        OrderDate = orderD.OrderDate,
                        ShipDate = orderD.ShipDate,
                        DeliveryDate = orderD.DeliveryDate,
                        Items = (List<BO.OrderItem>)Dal._orderItem.GetOrderItems(orderD.ID),
                        TotalPrice = Dal._orderItem.GetOrderItems(orderD.ID).Sum(x => x.Price)
                    };
                    return orderB;
                }
                else throw new BO.Exceptions.IdNotValidException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
        public BO.Order UpdateShippping(int ID)
        {
            try
            {
                var orderD = Dal._order.Get(ID);
                if (orderD.ShipDate == DateTime.MinValue)
                {
                    orderD.ShipDate = DateTime.Now;
                    var orderB = GetOrderDetails(ID);
                    orderB.ShipDate = orderD.ShipDate;
                    Dal._order.Update(orderD);
                    return orderB;
                }
                else throw new BO.Exceptions.DoneAlreadyException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
        public BO.Order UpdateDelivery(int ID)
        {
            try
            {
                var orderD = Dal._order.Get(ID);
                if (orderD.ShipDate == DateTime.MinValue) throw new BO.Exceptions.NotShippedYetException();
                if (orderD.DeliveryDate == DateTime.MinValue)
                {
                    orderD.DeliveryDate = DateTime.Now;
                    var orderB = GetOrderDetails(ID);
                    orderB.DeliveryDate = orderD.DeliveryDate;
                    Dal._order.Update(orderD);
                    return orderB;
                }
                else throw new BO.Exceptions.DoneAlreadyException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
        public BO.OrderTracking Track(int ID)
        {
            try
            {
                var order = Dal._order.Get(ID);
                BO.OrderTracking orderTracking = new BO.OrderTracking()
                {
                    ID = order.ID,
                    Status = GetStatus(order)
                };
                orderTracking.OrderDiary.Add(order.OrderDate, BO.Enums.OrderStatus.Approved);//TODO if this outputs a number, then use toStirng, and change orderDiary def to string
                if (order.ShipDate != DateTime.MinValue)
                {
                    orderTracking.OrderDiary.Add(order.ShipDate, BO.Enums.OrderStatus.Shipped);
                    if (order.DeliveryDate != DateTime.MinValue) orderTracking.OrderDiary.Add(order.DeliveryDate, BO.Enums.OrderStatus.Delivered);
                }
                return orderTracking;
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
        public BO.OrderItem Update(int orderID, int productID, int newAmount)
        {
            try
            {
                var orderItem = Dal._orderItem.Get(productID, orderID);
                var product = Dal._product.Get(productID);
                if (product.InStock >= newAmount - orderItem.Amount)
                {
                    orderItem.Amount = newAmount;
                    Dal._orderItem.Update(orderItem);
                    product.InStock -= newAmount - orderItem.Amount;
                    Dal._product.Update(product);
                    return new BO.OrderItem()
                    {
                        ID = orderItem.ID,
                        ProductId = orderItem.ProductID,
                        Name = product.Name,
                        Price = orderItem.Price,
                        Amount = orderItem.Amount,
                        TotalPrice = orderItem.Price * newAmount
                    };
                }
                else throw new BO.Exceptions.insufficientStockException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
    }
}
