using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class ObjectNotFoundException : Exception { }
    
    [Serializable]
    public class ObjectAlreadyExistsException : Exception { }
}
