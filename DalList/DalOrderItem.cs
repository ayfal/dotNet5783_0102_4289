using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{
    public int Add(OrderItem orderItems)
    {
        try
        {
            Get(orderItems.ID);
            throw new Exception("orderItems ID already exists!");
        }
        catch (KeyNotFoundException)
        {
            orderItems[Config.orderItems] = orderItems;
            Config.orderItems++;
            return orderItems.ID;
        }
    }

    public void Delete(int ID)
    {
        try
        {
            Get(ID);
            orderItems = orderItems.Where(i => i.ID != ID).ToArray();

        }
        catch (KeyNotFoundException)
        {


        }
    }

    public void Update()
    {

    }

    public OrderItem Get(int ID) // TODO חריגות
    {
        for (int i = 0; i < DataSource.Config.orderItems; i++)
        {
            if (DataSource.orderItems[i].ID == ID)
                return DataSource.orderItems[i];
        }
        throw new KeyNotFoundException();
    }
}
