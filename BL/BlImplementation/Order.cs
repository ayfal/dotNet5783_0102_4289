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
        public DO.Order UpdateDelivery(int ID)
        {
            var order = Dal._order.Get(ID);//TODO where to catch and throw the BL exception?
            if (order.ShipDate != DateTime.MinValue && order.DeliveryDate==DateTime.MinValue)
            {
                order.DeliveryDate = DateTime.Now;//TODO check if this updates the Dal entity too
                //Dal._order.Get(ID).DeliveryDate = DateTime.Now;//this doesn't work
                //the specs aren't clear about updating the data, they mention it twice
                Dal._order.Update(order);//TODO where to catch and throw the BL exception?
                return order;
            }
        }
        public Order UpdateShippping(int ID);
        public OrderTracking Track(int ID);
        public void Update(Order order);
    }
}
