
namespace Dal;

internal static class _DataSource
{
    static readonly int  Num;
    static DO.Order[] orders = new DO.Order[100];
    static DO.Prodact[] prodacts = new DO.Prodact[50];
    static DO.OrderItem[] orderItems = new DO.OrderItem[200];
    static void AddOrder(DO.Order)
    {
        for (int i = 0; i < 100; i++)
        {
            if (orders[i] != null)
            {

            }
        }
    }
    static void AddProdact(DO.Prodact);
    static void AddOrderItem(DO.OrderItem);
}
