using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal
{
    sealed public class DalList : IDal
    {
        public IProduct _product => new DalProduct();
        public IOrder _order => new DalOrder();
        public IOrderItem _orderItem => new DalOrderItem();
    }
}
