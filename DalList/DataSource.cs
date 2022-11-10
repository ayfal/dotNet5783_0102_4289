using DO;
namespace Dal;

internal static class DataSource
{
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
    static void AddOrder(Order newOrder)
    {
        orders[Config.orders] = newOrder;
        Config.orders++;
    }
    static void AddProduct(Product newProduct)
    {
        products[Config.products] = newProduct;
        Config.products++;
    }
    static void AddOrderItem(OrderItem newOrderItem)
    {
        orderItems[Config.orderItems] = newOrderItem;
        Config.orderItems++;
    }
    static private void s_Initialize()
    {
        for (int i = 0; i < 10; i++)//initialize 10 products
        {
            int id = rnd.Next(100000, 1000000);//TODO check uniquness
            Product product = new Product
            {
                ID = id,
                Name = "TESTName" + i,
                Category = (Enums.Category)(i % 6),
                Price = id / 10000,
                InStock = id / 100000,
            };
            AddProduct(product);
        }
        products[9].InStock = 0;//one product is out of stock
        for (int i = 0; i < 20; i++)//initialize 20 orders
        {
            Order order = new Order
            {
                ID = Config.orderId,
                CustomerName = "TESTCustomerName" + i,
                CustomerEmail = "TESTCustomerEmail" + i + "@jct.ac.il",
                CustomerAddress = "TESTCustomerAddress" + i,
                OrderDate = DateTime.MinValue,
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue
            };
            AddOrder(order);
        }
        for (int i = 0; i < 40; i++)//initialize 40 orders items
        {
            OrderItem orderItem = new OrderItem
            {
                ID = Config.orderItemId,
                ProductID = products[i % 9].ID,//TODO check if a product is ordered twice
                OrderID = orders[i % 20].ID,
                Price = products[i % 9].Price,
                Amount = 1 + i % 4
            };
            AddOrderItem(orderItem);
        }
    }
}
