using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Enums
    {
        /// <summary>
        /// the categories in the store
        /// </summary>
        public enum Category
        {
            Sages,
            Rishonim,
            Achronim,
            Halacha,
            Mussar,
            Hassidut
        }
        /// <summary>
        /// the order's status options
        /// </summary>
        public enum OrderStatus
        {
            Approved,
            Delivered,
            Shipped
        }
    }
}
