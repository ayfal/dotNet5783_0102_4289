using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    sealed public class Bl : IBl
    {
        public IProduct _product => new Product(); 
        public IOrder _order => new Order(); 
        public ICart _cart => new Cart();
    }
}
