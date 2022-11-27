using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    public interface IProduct
    {
        /// <summary>
        /// handles the products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductForList> GetProductsList();
        public Product GetProdcutDetails(int ID);
        public ProductItem GetProductDetails(int ID, Cart cart);
        public Product Add(Product product);
        public IEnumerable<ProductForList> Delete(int ID);
        public Product Update(Product product);


    }
}
