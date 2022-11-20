using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

internal class DalOrderItem
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

        var obj = Get(orderItem.ID);
        obj = orderItem;//TODO check if this updates the object inside the list
        //for (int i = 0; i < Config.products; i++)
        //{
        //    if (products[i].ID == pro.ID) products[i] = pro;
        //}
    }
    public OrderItem Get(int ID)
    {
        try { return orderItems.First(oi => oi.ID == ID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
    public OrderItem[] Get()
    {
        return orderItems.Where(i => i.ID != 0).ToArray();
    }

    public OrderItem Get(int productID, int orderID)
    {
        try { return orderItems.First(oi => oi.ProductID == productID && oi.OrderID == orderID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }

    public OrderItem[] GetOrderItems(int ID)
    {
        OrderItem[] detailedOrder = orderItems.Where(i => i.OrderID == ID).ToArray();
        if (detailedOrder.Length > 0) return detailedOrder;
        else throw new ObjectNotFoundException();//is this exception needed? should there be a different exceptions for non existant order?
    }
}