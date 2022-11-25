using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using Dal;
using DalApi;
using DO;

namespace BlImplementation
{
    internal class Order : IOrder
    {
        private IDal Dal = new DalList();
        private BO.Enums.OrderStatus GetStatus(DO.Order order)
        {
            return order.ShipDate == DateTime.MinValue ? BO.Enums.OrderStatus.Approved : order.DeliveryDate == DateTime.MinValue ? BO.Enums.OrderStatus.Shipped : BO.Enums.OrderStatus.Delivered;
        }
        public IEnumerable<OrderForList> Get()
        {
            var orders = Dal._order.Get();
            IEnumerable<OrderForList> ordersList = new List<OrderForList>();
            foreach (var order in orders)
            {
                BO.OrderForList orderForList = new BO.OrderForList();
                orderForList.ID = order.ID;
                orderForList.CustomerName = order.CustomerName;
                orderForList.Status = GetStatus(order);
                orderForList.AmountOfItems = Dal._orderItem.GetOrderItems(order.ID).Count();
                orderForList.TotalPrice = Dal._orderItem.GetOrderItems(order.ID).Sum(x => x.Price);
                ordersList.Append(orderForList);
            }
            return ordersList;
        }
        public BO.Order GetOrderDetails(int ID)
        {
            try
            {

                var orderB = new BO.Order();
                orderB.ID = ID;
                if (ID > 0)
                {
                    var orderD = Dal._order.Get(ID);
                    orderB.CustomerName = orderD.CustomerName;
                    orderB.CustomerEmail = orderD.CustomerEmail;
                    orderB.CustomerAddress = orderD.CustomerAddress;
                    orderB.Status = GetStatus(orderD);
                    orderB.OrderDate = orderD.OrderDate;
                    orderB.ShipDate = orderD.ShipDate;
                    orderB.DeliveryDate = orderD.DeliveryDate;
                    orderB.Items = (List<BO.OrderItem>)Dal._orderItem.GetOrderItems(orderD.ID);
                    orderB.TotalPrice = Dal._orderItem.GetOrderItems(orderD.ID).Sum(x => x.Price);
                    return orderB;
                }//TODO should all of this be done with "quick initialize"?
                else throw new BO.Exceptions.IdNotValidException();
            }
            catch (ObjectNotFoundException)
            {
                throw new DO.ObjectNotFoundException();
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
        public OrderTracking Track(int ID)
        {
            try
            {
                var order = Dal._order.Get(ID);
                OrderTracking orderTracking = new OrderTracking();
                orderTracking.ID = order.ID;
                orderTracking.Status = GetStatus(order);
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
        public void Update(int orderID, int productID, int newAmount)
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
