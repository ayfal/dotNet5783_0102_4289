using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{
    public int Add(OrderItem orderItem)
    {
        orderItem.ID = Config.orderItemId;//check what happens with config.orderID
        orderItems[Config.orderItems] = orderItem;
        Config.orderItems++;
        return orderItem.ID;
    }
    public void Delete(int ID)
    {
        Get(ID);
        orderItems = orderItems.Where(i => i.ID != ID).ToArray();
        Config.orderItems--;
    }
    public void Update(Order orderItem)
    {
        Get(orderItem.ID);
        for (int i = 0; i < Config.orderItems; i++)
        {
            if (orderItems[i].ID == orderItem.ID) orders[i] = orderItem;
        }
    }
    public OrderItem Get(int ID)
    {
        for (int i = 0; i < Config.orderItems; i++)
        {
            if (orderItems[i].ID == ID) return orderItems[i];
        }
        throw new Exception("key not found");
    }
    public OrderItem[] Get()
    {
        return orderItems.ToArray();
    }

    //TODO add more methods from the general description file. all should be public
}