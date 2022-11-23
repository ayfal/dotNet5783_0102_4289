using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Order:IOrder
    {
        private IDal Dal = new DalList();
        public IEnumerable<OrderForList> Get()
        {
            
            DO.Order.
        }
        public Order GetOrderDetails(int ID);
        public Order UpdateDelivery(int ID);
        public Order UpdateShippping(int ID);
        public OrderTracking Track(int ID);
        public void Update(Order order);
    }
}
