using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//this code is mostly copied from the files the staff provided, slightly modified. 
namespace Dal
{
    internal class DalProduct:IProduct
    {
        const string s_Products = @"Products"; //XML Serializer

        public IEnumerable<DO.Product?> Get(Func<DO.Product?, bool>? filter = null)
        {
            List<DO.Product?> listProducts = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_Products);

            if (filter == null)
                return listProducts.Select(lec => lec).OrderBy(lec => lec?.ID);
            else
                return listProducts.Where(filter).OrderBy(lec => lec?.ID);
        }

        public DO.Product? Get(int id)
        {
            List<DO.Product?> listProducts = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_Products);

            return listProducts.FirstOrDefault(lec => lec?.ID == id) ??
                throw new Exception("missing id"); //new DalMissingIdException(id, "Product");
        }
        public DO.Product? GetSingle(Func<DO.Product?, bool>? filter = null) 
        {
            List<DO.Product?> listProducts = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_Products);
            try { return listProducts.First(oi => filter!(oi)); }
            catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
        }
        public int Add(DO.Product Product)
        {
            List<DO.Product?> listProducts = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_Products);

            if (listProducts.FirstOrDefault(lec => lec?.ID == Product.ID) != null)
                throw new Exception("id already exist"); //new DalAlreadyExistIdException(pr.ID, "Product");

            listProducts.Add(Product);

            XMLTools.SaveListToXMLSerializer(listProducts, s_Products);

            return Product.ID;
        }

        public void Delete(int id)
        {
            List<DO.Product?> listProducts = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_Products);

            if (listProducts.RemoveAll(lec => lec?.ID == id) == 0)
                throw new Exception("missing id"); //new DalMissingIdException(id, "Product");

            XMLTools.SaveListToXMLSerializer(listProducts, s_Products);
        }
        public void Update(DO.Product Product)
        {
            Delete(Product.ID);
            Add(Product);
        }
    }
}
