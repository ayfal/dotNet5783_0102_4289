using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{    
    public int Add(Order order)
    {
        orders[Config.orders] = order;
        orders[Config.orders].ID = Config.orderId;//check what happens with config.orderID
        Config.orders++;
        return order.ID;
    }
    public void Delete(int ID)
    {
        Get(ID);
        orders = orders.Where(i => i.ID != ID).ToArray();
        Config.orders--;
    }
    public void Update(Order order)
    {
        Get(order.ID);
        for (int i = 0; i < Config.orders; i++)
        {
            if (orders[i].ID == order.ID) orders[i] = order;
        }
    }
    public Order Get(int ID)
    {
        try { return orders.First(o => o.ID == ID); }
        catch (InvalidOperationException) { throw new Exception("Order not found!"); }
    }
    public Order[] Get()
    {
        return orders.Where(i => i.ID != 0).ToArray();
    }
}