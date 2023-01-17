namespace Dal;
using DalApi;
using DO;
using System.Security.Principal;

internal class DalOrder : IOrder
{
    const string s_Orders = @"Order"; //XML Serializer

    public IEnumerable<DO.Order?> Get(Func<DO.Order?, bool>? filter = null)
    {
        List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

        if (filter == null)
            return listOrders.Select(lec => lec).OrderBy(lec => lec?.ID);
        else
            return listOrders.Where(filter).OrderBy(lec => lec?.ID);
    }
    public int Add(Order order) 
    {
        List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

        if (listOrders.FirstOrDefault(lec => lec?.ID == order.ID) != null)
            throw new Exception("id already exist"); //new DalAlreadyExistIdException(pr.ID, "Product");

        listOrders.Add(order);

        XMLTools.SaveListToXMLSerializer(listOrders, s_Orders);

        return order.ID;
    }
    public void Delete(int id)
    {
        List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

        if (listOrders.RemoveAll(lec => lec?.ID == id) == 0)
            throw new Exception("missing id"); //new DalMissingIdException(id, "Order");

        XMLTools.SaveListToXMLSerializer(listOrders, s_Orders);
    }
    public void Update(DO.Order order)
    {
        Delete(order.ID);
        Add(order);
    }

    public DO.Order? Get(int id)
    {
        List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

        return listOrders.FirstOrDefault(lec => lec?.ID == id) ??
            throw new Exception("missing id"); //new DalMissingIdException(id, "Order");
    }
    /// <summary>
    /// gets an object
    /// </summary>
    /// <param name="f">filtering criteria</param>
    /// <returns>the object</returns>
    public DO.Order? GetSingle(Func<DO.Order?, bool>? f) { return new DO.Order(); }
}