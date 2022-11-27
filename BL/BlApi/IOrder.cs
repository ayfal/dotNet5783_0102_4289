using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// handles the orders
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// gets a list of all the orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderForList> Get();
        /// <summary>
        /// get an order's details
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Order GetOrderDetails(int ID);
        /// <summary>
        /// report a delivery
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>updated order</returns>
        public Order UpdateDelivery(int ID);
        /// <summary>
        /// report shipping
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>updated order</returns>
        public Order UpdateShipping(int ID);
        /// <summary>
        /// gets a report about the order's progress
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public OrderTracking Track(int ID);
        /// <summary>
        /// updates a product's amount in the order
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="productID"></param>
        /// <param name="newAmount"></param>
        /// <returns>updated order item</returns>
        public OrderItem Update(int orderID, int productID, int newAmount);
    }
}
