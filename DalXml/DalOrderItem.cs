using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DalOrderItem:IOrderItem
    {
        const string s_OrderItems = @"OrderItems"; //XML Serializer

        //todo fix the following to actually do their work
        public OrderItem? Get(int productID, int OrderID) { return new OrderItem(); }
        public IEnumerable<OrderItem?> GetOrderItems(int ID) { return new List<OrderItem?>(); }
        public DO.OrderItem? GetSingle(Func<DO.OrderItem?, bool>? filter = null) { return new DO.OrderItem?(); }

        //up to here. and do the same for product and order

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
            List<DO.OrderItem?> listOrderItems = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(s_OrderItems);

            if (listOrderItems.FirstOrDefault(lec => lec?.ID == OrderItem.ID) != null)
                throw new Exception("id already exist"); //new DalAlreadyExistIdException(pr.ID, "Product");

            listOrderItems.Add(OrderItem);

            XMLTools.SaveListToXMLSerializer(listOrderItems, s_OrderItems);

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
