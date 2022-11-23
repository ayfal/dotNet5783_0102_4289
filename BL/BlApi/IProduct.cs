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
        public IEnumerable<ProductForList> GetProductsList();
        public Product GetProdcutDetails(int ID);
        public ProductItem GetProductDetails(int ID, Cart cart);
        public void Add(Product product);
        public void Delete(int ID);
        public void Update(Product product);


    }
}
