using DO;
namespace Dal;

internal static class DataSource
{
    const int CATEGORIES = 6;
    internal static class Config
    {
        internal static int products = 0, orders = 0, orderItems = 0;
        private static int _orderID = 0, _orderItemID = 0;
        internal static int orderId { get => ++_orderID; }
        internal static int orderItemId { get => ++_orderItemID; }
    }
    static DataSource() { s_Initialize(); }
    static readonly Random rnd = new Random();
    internal static Order[] orders = new Order[100];
    internal static Product[] products = new Product[50];
    internal static OrderItem[] orderItems = new OrderItem[200];
    static void InitializeOrders()
    {
        for (int i = 0; i < 20; i++)
        {
            Order order = new Order
            {
                ID = Config.orderId,
                CustomerName = "TESTCustomerName" + i,
                CustomerEmail = "TESTCustomerEmail" + i + "@jct.ac.il",
                CustomerAddress = "TESTCustomerAddress" + i,
                OrderDate = DateTime.MinValue,
                ShipDate = DateTime.MinValue.AddHours(rnd.Next(1, 4)),
                DeliveryDate = DateTime.MinValue.AddDays(rnd.Next(3, 6))
            };
            orders[Config.orders] = order;
            Config.orders++;
        }
    }
    static void InitializeProducts()
    {
        for (int i = 0; i < 10; i++)
        {
            int id = rnd.Next(100000, 1000000);//TODO check uniquness
            Product product = new Product
            {
                ID = id,
                Name = "TESTName" + i,
                Category = (Enums.Category)(i % CATEGORIES),
                Price = id / 10000,
                InStock = id / 100000,
            };
            products[Config.products] = product;
            Config.products++;
        }
        products[9].InStock = 0;//one product is out of stock
    }
    static void InitialzieOrderItems()
    {
        for (int i = 0; i < 40; i++)
        {
            OrderItem orderItem = new OrderItem
            {
                ID = Config.orderItemId,
                ProductID = products[i % 9].ID,//TODO check if a product is ordered twice
                OrderID = orders[i % 20].ID,
                Price = products[i % 9].Price,
                Amount = 1 + i % 4
            };
            orderItems[Config.orderItems] = orderItem;
            Config.orderItems++;            
        }
    }
    static private void s_Initialize()
    {
        InitializeProducts();
        InitializeOrders();
        InitialzieOrderItems();
    }
}
