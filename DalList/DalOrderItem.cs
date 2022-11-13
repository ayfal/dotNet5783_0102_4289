using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{
    public int Add(OrderItem orderItem)
    {
        orderItems[Config.orderItems] = orderItem;//the requirements state not to check that productID and orderID exist
        orderItems[Config.orderItems].ID = Config.orderItemId;
        Config.orderItems++;
        return orderItem.ID;
    }
    public void Delete(int ID)
    {
        Get(ID);
        orderItems = orderItems.Where(i => i.ID != ID).ToArray();
        Config.orderItems--;
    }
    public void Update(OrderItem orderItem)
    {
        Get(orderItem.ID);
        for (int i = 0; i < Config.orderItems; i++)
        {
            if (orderItems[i].ID == orderItem.ID) orderItems[i] = orderItem;
        }
    }
    public OrderItem Get(int ID)
    {
        try { return orderItems.First(oi => oi.ID == ID); }
        catch (InvalidOperationException) { throw new Exception("Order item not found!"); }
    }
    public OrderItem[] Get()
    {
        return orderItems.Where(i => i.ID != 0).ToArray();
    }

    public OrderItem Get(int productID, int orderID)
    {
        try { return orderItems.First(oi => oi.ProductID == productID && oi.OrderID == orderID); }
        catch (InvalidOperationException) { throw new Exception("Order item not found!"); }
    }

    public OrderItem[] GetOrderItems(int ID)
    {
        OrderItem[] detailedOrder = orderItems.Where(i => i.OrderID == ID).ToArray();
        if (detailedOrder.Length > 0) return detailedOrder;
        else throw new Exception("None found!");//is this exception needed? should there be a different exceptions for non existant order?
    }
}