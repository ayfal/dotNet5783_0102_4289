using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

internal class DalOrder : IOrder
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
        var obj = Get(order.ID);
        obj = order;//TODO check if this updates the object inside the list
        //for (int i = 0; i < Config.products; i++)
        //{
        //    if (products[i].ID == pro.ID) products[i] = pro;
        //}
    }
    public Order Get(int ID)
    {
        try { return orders.First(o => o.ID == ID); }
        catch (InvalidOperationException) { throw new ObjectNotFoundException(); }
    }
    public Order[] Get()
    {
        return orders.Where(i => i.ID != 0).ToArray();
    }
}