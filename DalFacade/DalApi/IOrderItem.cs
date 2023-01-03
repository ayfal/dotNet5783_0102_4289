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
        OrderItem? Get(int productID, int OrderID); //the returned object can't be null, because the functions throws an exception, therefor we didn't use the nullable operator
        /// <summary>
        /// returns a collection of the order items of an order
        /// </summary>
        /// <param name="ID">the order's ID</param>
        /// <returns>the collection</returns>
        IEnumerable<OrderItem?> GetOrderItems(int ID); //the list cannot contain null objects, because they all have ID, therefor we didn't use the nullable operator 
    }
}
