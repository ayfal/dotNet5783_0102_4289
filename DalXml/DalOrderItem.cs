using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//this code is mostly copied from the files the staff provided, slightly modified. 
namespace Dal
{
    internal class DalOrderItem:IOrderItem
    {
        const string s_OrderItems = @"OrderItems"; //XML Serializer

        
        public OrderItem? Get(int productID, int orderID) 
        {
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);

            return listOrderItems.FirstOrDefault(oi => oi?.ProductID == productID && oi?.OrderID == orderID) ??
                throw new Exception("missing id"); //new DalMissingIdException(id, "OrderItem");
        }
        public IEnumerable<OrderItem?> GetOrderItems(int ID) 
        {
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);

            return listOrderItems.Where(i => i?.OrderID == ID) ??
                throw new Exception("missing id"); //new DalMissingIdException(id, "OrderItem");
         }
        public DO.OrderItem? GetSingle(Func<DO.OrderItem?, bool>? filter = null) 
        {
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);
            try { return listOrderItems.First(oi => filter!(oi)); }
            catch (InvalidOperationException) { throw new ObjectNotFoundException(); }            
        }


        public IEnumerable<DO.OrderItem?> Get(Func<DO.OrderItem?, bool>? filter = null)
        {
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);

            if (filter == null)
                return listOrderItems.Select(lec => lec).OrderBy(lec => lec?.ID);
            else
                return listOrderItems.Where(filter).OrderBy(lec => lec?.ID);
        }

        public DO.OrderItem? Get(int id)
        {
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);

            return listOrderItems.FirstOrDefault(lec => lec?.ID == id) ??
                throw new Exception("missing id"); //new DalMissingIdException(id, "OrderItem");
        }
        public int Add(DO.OrderItem OrderItem)
        {
            XMLTools.config = XElement.Load(XMLTools.configPath);
            OrderItem.ID = int.Parse(XMLTools.config.Element("orderItemID").Value);
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);

            if (listOrderItems.FirstOrDefault(lec => lec?.ID == OrderItem.ID) != null)
                throw new Exception("id already exist"); //new DalAlreadyExistIdException(pr.ID, "Product");

            listOrderItems.Add(OrderItem);

            XMLTools.SaveListToXMLSerializer(listOrderItems, s_OrderItems);
            XMLTools.config.Element("orderItemID").Value = (OrderItem.ID + 1).ToString();
            XMLTools.config.Save(XMLTools.configPath);

            return OrderItem.ID;
        }

        public void Delete(int id)
        {
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);

            if (listOrderItems.RemoveAll(lec => lec?.ID == id) == 0)
                throw new Exception("missing id"); //new DalMissingIdException(id, "OrderItem");

            XMLTools.SaveListToXMLSerializer(listOrderItems, s_OrderItems);
        }
        public void Update(DO.OrderItem OrderItem)
        {
            Delete(OrderItem.ID);
            Add(OrderItem);
        }
    }
}
