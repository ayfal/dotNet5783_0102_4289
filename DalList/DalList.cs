using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal
{
    sealed internal class DalList : IDal
    {
        public static IDal Instance { get; } = new DalList();
        public IProduct product { get; } = new Dal.DalProduct();
        public IOrder order { get; } = new Dal.DalOrder();
        public IOrderItem orderItem { get; } = new Dal.DalOrderItem();
        private DalList() { }
    }
}
