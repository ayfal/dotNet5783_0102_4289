using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface ICrud<T>
    {
        int Add(T t);
        void Delete(T t);
        void Update(T t);
        IEnumerable<T> Get();
        T Get(T t);

    }
}
