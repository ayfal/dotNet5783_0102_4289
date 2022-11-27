using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{//TODO add documentation in all the BLApi
    //TODO this is not like nurit's wiki. check the specs
    public interface IBl
    {
        ICart _cart { get; }
        IOrder _order { get; }
        IProduct _product { get; }
    }
}
