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
            public ObjectNotFoundException() { }
            public ObjectNotFoundException(Exception innerException) { }
        }
        [Serializable]
        public class ObjectAlreadyExistsException : Exception
        {
            public ObjectAlreadyExistsException(Exception innerException) { }
        }
        [Serializable]
        public class DoneAlreadyException : Exception 
        {
            public DoneAlreadyException(string message) { }
            public DoneAlreadyException(string message, Exception inner)
        : base(message, inner) { }
        }
        [Serializable]
        public class NotShippedYetException : Exception { }
        [Serializable]
        public class InsufficientStockException : Exception
        {
            public InsufficientStockException(string message) { }
            public InsufficientStockException(string message, Exception inner)
        : base(message, inner) { }
        }
    }
}
