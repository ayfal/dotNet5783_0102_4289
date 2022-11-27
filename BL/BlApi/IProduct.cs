using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi
{
    /// <summary>
    /// handles the products
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// gets a list of all the products (catalog)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductForList> GetProductsList();
        /// <summary>
        /// get a product details (for the manager)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Product GetProdcutDetails(int ID);
        /// <summary>
        /// gets a product details from a cart (for a customer)
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        public ProductItem GetProductDetails(int ID, Cart cart);
        /// <summary>
        /// add a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>the add product</returns>
        public Product Add(Product product);
        /// <summary>
        /// deletes a product
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>an updated list of all the products</returns>
        public IEnumerable<ProductForList> Delete(int ID);
        /// <summary>
        /// updated a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>the updated product</returns>
        public Product Update(Product product);


    }
}
