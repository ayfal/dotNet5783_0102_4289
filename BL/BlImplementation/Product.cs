using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using Dal;
using DalApi;
using DO;

namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        private IDal Dal = new DalList();
        public IEnumerable<ProductForList> GetProductsList()
        {
            var products = Dal._product.Get();
            IEnumerable<ProductForList> list = new List<ProductForList>();
            foreach (var product in products)
            {
                ProductForList listItem = new ProductForList();
                listItem.ID = product.ID;
                listItem.Name = product.Name;
                listItem.Price = product.Price;
                listItem.Category = product.Category;
                list.Append(listItem);
            }
            return list;
        }


        public BO.Product GetProdcutDetails(int ID)
        {
            try
            {

                if (ID > 0)
                {
                    var productD = Dal._product.Get(ID);
                    BO.Product productB = new BO.Product();
                    productB.ID = productD.ID;
                    productB.Name = productD.Name;
                    productB.Price = productD.Price;
                    productB.Category = (BO.Enums.Category)productD.Category;
                    productB.InStock = productD.InStock;
                    return productB;
                }
                else throw new InvalidDataException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
        public ProductItem GetProductDetails(int ID, BO.Cart cart)
        {
            try
            {
                if (ID > 0)
                {
                    DO.Product productD = Dal._product.Get(ID);
                    BO.ProductItem productB = new BO.ProductItem();
                    productB.ID = productD.ID;
                    productB.Name = productD.Name;
                    productB.Price = productD.Price;
                    productB.Category = productD.Category;
                    productB.InStock = productD.InStock > 0 ? true : false;
                    productB.Amount = cart.Items.First(x => x.ID == ID).Amount;
                    return productB;
                }
                else throw new InvalidDataException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
        public void Add(BO.Product product)
        {
            if (product.ID > 0 && product.Name != "" && product.Price > 0 && product.InStock >= 0)
            {
                DO.Product productD = new DO.Product();
                productD.ID = product.ID;
                productD.Name = product.Name;
                productD.Price = product.Price;
                productD.Category = (DO.Enums.Category)product.Category;
                productD.InStock = product.InStock;
                try { Dal._product.Add(productD); }
                catch (DO.ObjectAlreadyExistsException) { throw new BO.Exceptions.ObjectAlreadyExistsException(); }
            }
            else throw new InvalidDataException();
        }
        public void Delete(int ID)
        {
            if (Dal._orderItem.Get().ToList().Exists(x => x.ID == ID)) throw new BO.Exceptions.ObjectAlreadyExistsException();
            try { Dal._product.Delete(ID); }
            catch (DO.ObjectNotFoundException) { throw new BO.Exceptions.ObjectNotFoundException(); }
        }
        public void Update(BO.Product product)
        {
            if (product.ID > 0 && product.Name != "" && product.Price > 0 && product.InStock >= 0)
            {
                DO.Product productD = new DO.Product();
                productD.ID = product.ID;
                productD.Name = product.Name;
                productD.Price = product.Price;
                productD.Category = (DO.Enums.Category)product.Category;
                productD.InStock = product.InStock;
                try { Dal._product.Update(productD); }
                catch (DO.ObjectNotFoundException) { throw new BO.Exceptions.ObjectNotFoundException(); }
            }
            else throw new InvalidDataException();
        }//TODO check casting instead
    }
}

