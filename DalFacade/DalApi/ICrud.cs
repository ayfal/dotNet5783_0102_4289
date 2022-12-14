using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface ICrud<T> where T : struct
    {
        /// <summary>
        /// adds an object
        /// </summary>
        /// <param name="t"></param>
        /// <returns>the ID of the added object</returns>
        int Add(T t);
        /// <summary>
        /// deletes an object
        /// </summary>
        /// <param name="ID">the object's ID</param>
        void Delete(int ID);
        /// <summary>
        /// updates an object's details
        /// </summary>
        /// <param name="t">the object</param>
        void Update(T t);
        /// <summary>
        /// gets a collection of objects
        /// </summary>
        /// <param name="f">filtering criteria (optional)</param>
        /// <returns>the collection</returns>
        IEnumerable<T?> Get(Func<T?, bool>? f=null);
        /// <summary>
        /// gets an object
        /// </summary>
        /// <param name="ID">the object's ID</param>
        /// <returns>the object</returns>
        T? Get(int ID);//this function is unnecessary, because of the next one. but is required, it seems.
        /// <summary>
        /// gets an object
        /// </summary>
        /// <param name="f">filtering criteria</param>
        /// <returns>the object</returns>
        T? GetSingle(Func<T?, bool>? f);

    }
}
