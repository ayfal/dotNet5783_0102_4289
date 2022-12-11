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
        //object Get(int productID, int? orderID);//todo why is this returning object, and why one of the params is nullable? I don't remember writing this
        IEnumerable<OrderItem?> GetOrderItems(int ID);
    }
}
