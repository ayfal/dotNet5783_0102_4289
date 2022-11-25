using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using Dal;


namespace BlImplementation
{
    internal class Product : IProduct
    {
        private DalApi.IDal Dal = new DalList();
        public IEnumerable<BO.ProductForList> GetProductsList()
        {
            var products = Dal._product.Get();
            IEnumerable<BO.ProductForList> list = new List<BO.ProductForList>();
            foreach (var product in products)
            {
                BO.ProductForList listItem = new BO.ProductForList()
                {
                    ID = product.ID,
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category
                };
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
                    BO.Product productB = new BO.Product()
                    {
                        ID = productD.ID,
                        Name = productD.Name,
                        Price = productD.Price,
                        Category = (BO.Enums.Category)productD.Category,
                        InStock = productD.InStock
                    };
                    return productB;
                }
                else throw new InvalidDataException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException();
            }
        }
        public BO.ProductItem GetProductDetails(int ID, BO.Cart cart)
        {
            try
            {
                if (ID > 0)
                {
                    DO.Product productD = Dal._product.Get(ID);
                    BO.ProductItem productB = new BO.ProductItem()
                    {
                        ID = productD.ID,
                        Name = productD.Name,
                        Price = productD.Price,
                        Category = productD.Category,
                        InStock = productD.InStock > 0 ? true : false,
                        Amount = cart.Items.First(x => x.ID == ID).Amount
                    };
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
                DO.Product productD = new DO.Product()
                {
                    ID = product.ID,
                    Name = product.Name,
                    Price = product.Price,
                    Category = (DO.Enums.Category)product.Category,
                    InStock = product.InStock
                };
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
                DO.Product productD = new DO.Product()
                {
                    ID = product.ID,
                    Name = product.Name,
                    Price = product.Price,
                    Category = (DO.Enums.Category)product.Category,
                    InStock = product.InStock
                };
                try { Dal._product.Update(productD); }
                catch (DO.ObjectNotFoundException) { throw new BO.Exceptions.ObjectNotFoundException(); }
            }
            else throw new InvalidDataException();
        }
    }
}

