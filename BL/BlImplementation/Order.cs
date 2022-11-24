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
            var orderB = new BO.Order();
            orderB.ID = ID;
            if (ID > 0)//we've no clue why this is needed, as it's handled by the get method. but it's part of the specifications
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
            }//TODO should all of this be done with "quick initialize"?
            return orderB;
        }
        public Order UpdateDelivery(int ID);
        public Order UpdateShippping(int ID);
        public OrderTracking Track(int ID);
        public void Update(Order order);
    }
}
