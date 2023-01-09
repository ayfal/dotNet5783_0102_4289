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
            public DoneAlreadyException() : base("Oh wow, I had no idea. I've been living under a rock for the past decade and somehow missed that piece of information. Thank you for enlightening me with your groundbreaking revelation.") { }
        }
        [Serializable]
        public class NotShippedYetException : Exception { }
        [Serializable]
        public class InsufficientStockException : Exception
        {
            public InsufficientStockException() : base("Oh, I'm so sorry we're out of stock. I'm sure it's just a coincidence that it happened as soon as you wanted to buy something") { }
        }
    }
}
