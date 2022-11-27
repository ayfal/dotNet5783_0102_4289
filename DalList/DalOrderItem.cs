using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem : IOrderItem
{
    public int Add(OrderItem orderItem)
    {
        orderItem.ID = Config.orderItemId;
        orderItems.Add(orderItem);
        return orderItem.ID;
    }
    public void Delete(int ID)
    {
        orderItems.Remove(Get(ID));

    }
    public void Update(OrderItem orderItem)
    {
        var index = orderItems.FindIndex(x => x.ID == orderItem.ID);
        if (index == -1) throw new ObjectNotFoundException();
        orderItems[index] = orderItem;
    }
    public OrderItem Get(int ID)
    {
        try { return orderItems.First(oi => oi.ID == ID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
    public IEnumerable<OrderItem> Get()
    {
        return orderItems.Where(i => i.ID != 0);
    }

    public OrderItem Get(int productID, int orderID)
    {
        try { return orderItems.First(oi => oi.ProductID == productID && oi.OrderID == orderID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }

    public IEnumerable<OrderItem> GetOrderItems(int ID)
    {
        IEnumerable<OrderItem> detailedOrder = orderItems.Where(i => i.OrderID == ID);
        if (detailedOrder.Count() > 0) return detailedOrder;
        else throw new ObjectNotFoundException();//is this exception needed? should there be a different exceptions for non existant order?
    }
}