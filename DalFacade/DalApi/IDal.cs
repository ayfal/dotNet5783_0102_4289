using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    internal interface IDal
    {
        IProduct _product { get; }
        IOrder _order { get; }
        IOrderItem _orderItem { get; }
    }
}
