using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal class Exceptions
    {
        [Serializable]
        public class ObjectNotFoundException : Exception
        {
            ObjectNotFoundException(Exception innerException) { }
        }
        [Serializable]
        public class ObjectAlreadyExistsException : Exception
        {
            ObjectAlreadyExistsException(Exception innerException) { }
        }
        [Serializable]
        public class DoneAlreadyException : Exception { }
        [Serializable]
        public class NotShippedYetException : Exception { }
        [Serializable]
        public class InsufficientStockException : Exception { }
    }
}
