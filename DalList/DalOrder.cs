using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrder : IOrder
{    
    public int Add(Order order)
    {
        order.ID = Config.orderItemId;
        orders.Add(order);
        return order.ID;
    }
    public void Delete(int ID)
    {
        orders.Remove(Get(ID));
    }
    public void Update(Order order)
    {
        var index = orders.FindIndex(x => x?.ID == order.ID);
        if (index == -1) throw new ObjectNotFoundException();
        orders[index] = order;
    }
    public Order? Get(int ID)
    {
        try { return orders.First(o => o?.ID == ID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
    public IEnumerable<Order?> Get(Func<Order?, bool>? f = null)
    {
        if (f == null) return orders;
        return orders.Where(o => f(o));
    }
    public Order? GetSingle(Func<Order?, bool>? f)
    {
        try { return orders.First(o => f!(o)); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
}