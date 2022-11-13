using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{
    public int Add(Order order)
    {
        order.ID = Config.orderId;//check what happens with config.orderID
        orders[Config.orders] = order;
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
        for (int i = 0; i < Config.orders; i++)
        {
            if (orders[i].ID == ID) return orders[i];
        }
        throw new Exception("key not found");
    }
    public Order[] Get()
    {
        return orders.Where(i => i.ID != 0).ToArray();
    }

    //TODO add more methods from the general description file. all should be public
}