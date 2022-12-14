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
            Money,
            Blessings,
            Diseases,
            Dreams,
            Children,
            Disasters,
            Particles
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
