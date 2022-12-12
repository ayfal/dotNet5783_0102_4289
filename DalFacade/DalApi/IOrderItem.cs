using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IOrderItem:ICrud<OrderItem>
    {
        /// <summary>
        /// get an order item acoording to product ID and order ID
        /// </summary>
        /// <param name="productID">prodcut ID</param>
        /// <param name="OrderID">order ID</param>
        /// <returns>the order ID</returns>
        OrderItem? Get(int productID, int OrderID);
        //object Get(int productID, int? orderID);//todo why is this returning object, and why one of the params is nullable? I don't remember writing this
        /// <summary>
        /// returns a collection of the order items of an order
        /// </summary>
        /// <param name="ID">the order's ID</param>
        /// <returns>the collection</returns>
        IEnumerable<OrderItem?> GetOrderItems(int ID);
    }
}
