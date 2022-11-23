using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using Dal;
using DalApi;

namespace BlImplementation
{
    internal class Product:IProduct
    {
        private IDal Dal = new DalList();
        public IEnumerable<ProductForList> GetProductsList();
        public Product GetProdcutDetails(int ID);
        public ProductItem GetProductDetails(int ID, Cart cart);
        public void Add(Product product);
        public void Delete(int ID);
        public void Update(Product product);
    }
}
