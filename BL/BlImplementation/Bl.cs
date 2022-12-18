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
        public IProduct product => new Product(); 
        public IOrder order => new Order(); 
        public ICart cart => new Cart();
    }
}
