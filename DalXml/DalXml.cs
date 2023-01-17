using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    /// <summary>
    /// Thread-safe singleton example without using locks
    /// </summary>
    sealed internal class DalXml : IDal
    {
        private static readonly DalXml instance = new DalXml();
        public IOrder order { get; } = new Dal.DalOrder();
        public IProduct product { get; } = new Dal.DalProduct();
        public IOrderItem orderItem { get; } = new Dal.DalOrderItem();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DalXml()
        {
        }

        DalXml()
        {
        }

        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static DalXml Instance
        {
            get { return instance; }
        }
    }    
}
