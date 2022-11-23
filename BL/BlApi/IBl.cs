using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{//TODO add documentation in all the BLApi
    public interface IBl
    {
        ICart cart { get; }
        IOrder Order { get; }
        IProduct product { get; }
    }
}
