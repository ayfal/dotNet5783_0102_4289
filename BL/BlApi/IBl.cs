using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace BlApi
{//TODO add documentation in all the BLApi
    //TODO this is not like nurit's wiki. check the specs
    /// <summary>
    /// An interface that will bring together all the interfaces of the layer.
    /// </summary>
    public interface IBl
    {
        ICart cart { get; }
        IOrder order { get; }
        IProduct product { get; }
    }
}
