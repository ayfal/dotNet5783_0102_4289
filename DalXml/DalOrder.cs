namespace Dal;
using DalApi;
using DO;
using System.Security.Principal;
using System.Xml.Linq;

//this code is mostly copied from the files the staff provided, slightly modified. 

internal class DalOrder : IOrder
{

    const string s_Orders = "Orders"; //Linq to XML

    static DO.Order? createOrderfromXElement(XElement s)
    {
        return new DO.Order()
        {
            ID = s.ToIntNullable("ID") ?? throw new FormatException("id"), //fix to: DalXmlFormatException(id)),
            CustomerName = (string?)s.Element("CustomerName"),
            CustomerEmail = (string?)s.Element("CustomerEmail"),
            CustomerAddress = (string?)s.Element("CustomerAddress"),
            OrderDate = s.ToDateTimeNullable("OrderDate"),
            ShipDate = s.ToDateTimeNullable("ShipDate"),
            DeliveryDate = s.ToDateTimeNullable("DeliveryDate"),
        };
    }
    public IEnumerable<DO.Order?> Get(Func<DO.Order?, bool>? filter = null)
    {
        XElement? OrdersRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

        //return OrdersRootElem.Elements().Select(s => createOrderfromXElement(s)).Where(filter);

        if (filter != null)
        {
            return from s in OrdersRootElem.Elements()
                   let doStud = createOrderfromXElement(s)
                   where filter(doStud)
                   select (DO.Order?)doStud;
        }
        else
        {
            return from s in OrdersRootElem.Elements()
                   select createOrderfromXElement(s);
        }

    }
    public DO.Order? GetSingle(Func<DO.Order?, bool>? filter = null)
    {
        XElement? OrdersRootElem = XMLTools.LoadListFromXMLElement(s_Orders);
        //return new DO.Order();
        //return OrdersRootElem.Elements().Select(s => createOrderfromXElement(s)).Where(filter);

        if (filter != null)
        {
            return (from s in OrdersRootElem.Elements()
                   let doStud = createOrderfromXElement(s)
                   where filter(doStud)
                   select (DO.Order?)doStud).FirstOrDefault();
        }
        else
        {
            return (from s in OrdersRootElem.Elements()
                   select createOrderfromXElement(s)).FirstOrDefault();
        }

    }

    public DO.Order? Get(int id)
    {
        XElement OrdersRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

        return (from s in OrdersRootElem?.Elements()
                where s.ToIntNullable("ID") == id
                select (DO.Order?)createOrderfromXElement(s)).FirstOrDefault()
                ?? throw new Exception("missing id"); // fix to: throw new DalMissingIdException(id);
    }
    public int Add(DO.Order doOrder)
    {
        XMLTools.config = XElement.Load(XMLTools.configPath);
        doOrder.ID = int.Parse(XMLTools.config.Element("orderID").Value);
        XElement OrdersRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

        XElement? stud = (from st in OrdersRootElem.Elements()
                          where st.ToIntNullable("ID") == doOrder.ID //where (int?)st.Element("ID") == doOrder.ID
                          select st).FirstOrDefault();
        if (stud != null)
            throw new Exception("id already exist"); // fix to: throw new DalMissingIdException(id);

        XElement OrderElem = new XElement("Order",
                                   new XElement("ID", doOrder.ID),
                                   new XElement("CustomerName", doOrder.CustomerName),
                                   new XElement("CustomerEmail", doOrder.CustomerEmail),
                                   new XElement("CustomerAddress", doOrder.CustomerAddress),
                                   new XElement("OrderDate", doOrder.OrderDate),
                                   new XElement("ShipDate", doOrder.ShipDate),
                                   new XElement("DeliveryDate", doOrder.DeliveryDate)
                                   );

        OrdersRootElem.Add(OrderElem);

        XMLTools.SaveListToXMLElement(OrdersRootElem, s_Orders);
        XMLTools.config.Element("orderID").Value = (doOrder.ID + 1).ToString();
        XMLTools.config.Save(XMLTools.configPath);

        return doOrder.ID; ;
    }

    public void Delete(int id)
    {
        XElement OrdersRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

        XElement? stud = (from st in OrdersRootElem.Elements()
                          where (int?)st.Element("ID") == id
                          select st).FirstOrDefault() ?? throw new Exception("missing id"); // fix to: throw new DalMissingIdException(id);

        stud.Remove(); //<==>   Remove stud from OrdersRootElem

        XMLTools.SaveListToXMLElement(OrdersRootElem, s_Orders);
    }

    public void Update(DO.Order doOrder)
    {
        Delete(doOrder.ID);
        Add(doOrder);
    }
    //const string s_Orders = @"Order"; //XML Serializer

    //public IEnumerable<DO.Order?> Get(Func<DO.Order?, bool>? filter = null)
    //{
    //    List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

    //    if (filter == null)
    //        return listOrders.Select(lec => lec).OrderBy(lec => lec?.ID);
    //    else
    //        return listOrders.Where(filter).OrderBy(lec => lec?.ID);
    //}
    //public int Add(Order order) 
    //{
    //    List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

    //    if (listOrders.FirstOrDefault(lec => lec?.ID == order.ID) != null)
    //        throw new Exception("id already exist"); //new DalAlreadyExistIdException(pr.ID, "Product");

    //    listOrders.Add(order);

    //    XMLTools.SaveListToXMLSerializer(listOrders, s_Orders);

    //    return order.ID;
    //}
    //public void Delete(int id)
    //{
    //    List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

    //    if (listOrders.RemoveAll(lec => lec?.ID == id) == 0)
    //        throw new Exception("missing id"); //new DalMissingIdException(id, "Order");

    //    XMLTools.SaveListToXMLSerializer(listOrders, s_Orders);
    //}
    //public void Update(DO.Order order)
    //{
    //    Delete(order.ID);
    //    Add(order);
    //}

    //public DO.Order? Get(int id)
    //{
    //    List<DO.Order?> listOrders = XMLTools.LoadListFromXMLSerializer<DO.Order>(s_Orders);

    //    return listOrders.FirstOrDefault(lec => lec?.ID == id) ??
    //        throw new Exception("missing id"); //new DalMissingIdException(id, "Order");
    //}
    ///// <summary>
    ///// gets an object
    ///// </summary>
    ///// <param name="f">filtering criteria</param>
    ///// <returns>the object</returns>
    //public DO.Order? GetSingle(Func<DO.Order?, bool>? f) { return new DO.Order(); }
}