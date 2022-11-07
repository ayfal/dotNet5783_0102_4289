using DO;
namespace Dal;

internal static class _DataSource
{
    internal static class Config
    {
        internal static int products = 0, orders = 0, orderItems = 0;
        private static int _orderID = 0, _orderItemID = 0;
        internal static int orderId { get => ++_orderID; }
        internal static int orderItemId { get => ++_orderItemID; }
    }
    static _DataSource() { s_Initialize(); }
    static readonly int  Num;
    internal static Order[] orders = new Order[100];
    internal static Product[] Products = new Product[50];
    internal static OrderItem[] orderItems = new OrderItem[200];
    static void AddOrder(Order newOrder)
    {
                orders[Config.orders] = newOrder;
    }
    static void AddProduct(Product newProduct)
    {
        Products[Config.products] = newProduct;
    }
    static void AddOrderItem(OrderItem newOrderItem)
    {
        orderItems[Config.orderItems] = newOrderItem;
    }
    static private void s_Initialize() 
    {
        Random rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            int id = rnd.Next(100000, 1000000);//TODO check uniquness
            Order order = new Order {
                ID = id,
                CustomerName = "TESTCustomerName" + i,
                CustomerEmail = "TESTCustomerEmail" + i+"@jct.ac.il",
                CustomerAddress = "TESTCustomerAddress" + i,
                OrderDate = DateTime.MinValue,
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue
            };
        }
        for (int i = 0; i < 10; i++)
        {           
            Product product = new Product
            {
                ID = Config.orderId,
                Name = "TESTName" + i,
                Category = "TESTCustomerEmail" + i + "@jct.ac.il",
                Price= "TESTCustomerAddress" + i,
                InStock= DateTime.MinValue,           };
        }
        AddProduct()
            , AddOrder(),AddOrderItem()
    } 
}
