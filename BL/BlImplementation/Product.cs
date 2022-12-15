using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BO;
using Dal;


namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        private DalApi.IDal Dal = new DalList();
        public IEnumerable<BO.ProductForList> GetProductsList(Predicate<DO.Product?>? f = null)
        {
            var products = Dal._product.Get();
            var list = new List<BO.ProductForList>();
            foreach (var product in products)
            {
                if (f == null || f(product))
                {
                    BO.ProductForList listItem = new BO.ProductForList();
                    //{
                    //    ID = product?.ID ?? throw new NullReferenceException(),
                    //    Name = product?.Name,
                    //    Price = product?.Price ?? throw new NullReferenceException(),
                    //    Category = product?.Category
                    //};
                    listItem.CopyProperties(product!);
                    list.Add(listItem);
                }
            }
            return list;
        }


        public BO.Product GetProdcutDetails(int ID)
        {
            try
            {

                if (ID > 0)
                {
                    var productD = Dal._product.Get(ID) ?? throw new NullReferenceException();
                    BO.Product productB = new BO.Product()
                    {
                        //ID = productD.ID,
                        //Name = productD.Name,
                        //Price = productD.Price,
                        Category = (BO.Enums.Category)productD.Category!,
                        //InStock = productD.InStock
                    };
                    productB.CopyProperties(productD);
                    return productB;
                }
                else throw new InvalidDataException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.ProductItem GetProductDetails(int ID, BO.Cart cart)
        {
            try
            {
                if (ID > 0)
                {
                    DO.Product productD = Dal._product.Get(ID) ?? throw new NullReferenceException();
                    BO.ProductItem productB = new BO.ProductItem()
                    {
                        //ID = productD.ID,
                        //Name = productD.Name,
                        //Price = productD.Price,
                        Category = (BO.Enums.Category)productD.Category!,
                        InStock = productD.InStock > 0 ? true : false,
                        Amount = cart.Items?.First(x => x?.ID == ID)?.Amount ?? throw new NullReferenceException()
                    };
                    productB.CopyProperties(productD);
                    return productB;
                }
                else throw new InvalidDataException();
            }
            catch (DO.ObjectNotFoundException)
            {
                throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException());
            }
        }
        public BO.Product Add(BO.Product product)
        {
            if (product.ID > 0 && product.Name != "" && product.Price > 0 && product.InStock >= 0)
            {
                DO.Product productD = new DO.Product()
                {
                    //ID = product.ID,
                    //Name = product.Name,
                    //Price = product.Price,
                    Category = (DO.Enums.Category)product.Category!,
                    //InStock = product.InStock
                };
                productD.CopyProperties(product);
                try { Dal._product.Add(productD); }
                catch (DO.ObjectAlreadyExistsException) { throw new BO.Exceptions.ObjectAlreadyExistsException(new DO.ObjectAlreadyExistsException()); }
                return GetProdcutDetails(product.ID);
            }
            else throw new InvalidDataException();
        }
        public IEnumerable<ProductForList> Delete(int ID)
        {
            if (Dal._orderItem.Get().ToList().Exists(x => x?.ID == ID)) throw new BO.Exceptions.ObjectAlreadyExistsException(new DO.ObjectAlreadyExistsException());
            try { Dal._product.Delete(ID); }
            catch (DO.ObjectNotFoundException) { throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException()); }
            return GetProductsList();
        }

        public BO.Product Update(BO.Product product)
        {
            if (product.ID > 0 && product.Name != "" && product.Price > 0 && product.InStock >= 0)
            {
                DO.Product productD = new DO.Product()
                {
                    //ID = product.ID,
                    //Name = product.Name,
                    //Price = product.Price,
                    Category = (DO.Enums.Category)product.Category!,
                    //InStock = product.InStock
                };
                productD.CopyProperties(product);
                try { Dal._product.Update(productD); }
                catch (DO.ObjectNotFoundException) { throw new BO.Exceptions.ObjectNotFoundException(new DO.ObjectNotFoundException()); }
                return GetProdcutDetails(product.ID);
            }
            else throw new InvalidDataException();
        }
    }
}

