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
        public class IdNotValidException : Exception { }// why not use InvalidDataException which already exists?
        
        [Serializable]
        public class ObjectNotFoundException : Exception { }
        [Serializable]
        public class ObjectAlreadyExistsException : Exception { }
    }
}
