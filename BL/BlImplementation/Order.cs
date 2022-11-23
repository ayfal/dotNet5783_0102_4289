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
    internal class Order:IOrder
    {
        private IDal Dal = new DalList();
        public IEnumerable<OrderForList> Get()
        {
            var orders = Dal._order.Get();
            foreach (var order in orders)
            {
                BO.OrderForList orderForList = new BO.OrderForList();
                orderForList.ID = order.ID;
                orderForList.CustomerName = order.CustomerName;
                orderForList.Status = order.ShipDate == DateTime.MinValue ? BO.Enums.OrderStatus.Approved : order.DeliveryDate == DateTime.MinValue ? BO.Enums.OrderStatus.Shipped : BO.Enums.OrderStatus.Delivered;
                orderForList.AmountOfItems=order.
            }

            return 
        }
        public Order GetOrderDetails(int ID);
        public Order UpdateDelivery(int ID);
        public Order UpdateShippping(int ID);
        public OrderTracking Track(int ID);
        public void Update(Order order);
    }
}
