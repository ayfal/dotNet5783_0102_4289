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
        OrderItem? Get(int productID, int OrderID);
        object Get(int productID, int? orderID);
        IEnumerable<OrderItem?> GetOrderItems(int ID);
    }
}
