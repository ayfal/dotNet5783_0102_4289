
namespace Dal;

internal static class _DataSource
{
    static _DataSource() { s_Initialize(); }
    static readonly int  Num;
    internal static DO.Order[] orders = new DO.Order[100];
    internal static DO.Product[] products = new DO.Product[50];
    internal static DO.OrderItem[] orderItems = new DO.OrderItem[200];
    private static void AddOrder(DO.Order newOrder)
    {
        for (int i = 0; i < 100; i++)
        {
            if (orders[i] == null)
            {
                orders[i] = newOrder;
                break;
            }
        }
    }
    private static void AddProduct(DO.Product newProduct)
    {
        for (int i = 0; i < 50; i++)
        {
            if (products[i] == null)
            {
                products[i] = newProduct;
                break;
            }
        }
    }
    private static void AddOrderItem(DO.OrderItem newOrderItem)
    {
        for (int i = 0; i < 200; i++)
        {
            if (orderItems[i] == null)
            {
                orderItems[i] = newOrderItem;
                break;
            }
        }
    }
    private static void  s_Initialize() { AddProduct(), AddOrder(),AddOrderItem(); } 
}
