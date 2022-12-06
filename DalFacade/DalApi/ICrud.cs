using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface ICrud<T> where T : struct
    {
        int Add(T t);
        void Delete(int ID);
        void Update(T t);
        IEnumerable<T?> Get(Func<T?, bool>? f=null);
        T? Get(int ID);

    }
}
