using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    sealed internal class Bl : IBl
    {
        public IProduct product { get; } = new BlImplementation.Product(); 
        public IOrder order { get; } = new BlImplementation.Order(); 
        public ICart cart { get; } = new BlImplementation.Cart();
    }
}
