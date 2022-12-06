using DO;
namespace Dal;

internal static class DataSource
{
    const int CATEGORIES = 6;
    internal static class Config
    {
        //internal static int products = 0, orders = 0, orderItems = 0;
        private static int _orderID = 0, _orderItemID = 0;
        internal static int orderId { get => ++_orderID; }
        internal static int orderItemId { get => ++_orderItemID; }
    }
    static DataSource() { s_Initialize(); }//TODO static class shouldn't have a constructor
    static readonly Random rnd = new Random();
    internal static List<Order?> orders = new List<Order?>();
    internal static List<Product?> products = new List<Product?>();
    internal static List<OrderItem?> orderItems = new List<OrderItem?>();
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
                //the instructions say:
                //כל התאריכים יהיו לפני הזמן של הפעלת התכנית (DateTime.Now)
                //לכולם יהיה תאריך יצירת הזמנה
                //לכ - 80 % מההזמנות יהיה תאריך משלוח שחייב להיות אחרי זמן יצירת הזמנה
                //לכ - 60 % מההזמנות שנשלחו יהיה תאריך מסירה             
                //כל התאריכים החסרים(מטיפוס DateTime) בנתוני הישויות יאותחלו ל - DateTime.MinValue
                //כל התאריכים שיש ביניהם סדר - יש להשתמש ב - TimeSpan עם פרק זמן מוגרל רנדומלית(ע"פ היגיון בריא) שיוסף לתאריך "הקודם" לפי משמעות התאריכים בישות הרלוונטית
                OrderDate = DateTime.Now.AddMonths(-1),
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue
            };
            orders.Add(order);
        }
        for (int i = 0; i < 20 * 0.8; i++)
        {
            Order order = orders[i] ?? throw new NullReferenceException();
            order.ShipDate = orders[i]?.OrderDate?.AddHours(rnd.Next(1, 4));
            orders[i] = order;
        }
        for (int i = 0; i < 20 * 0.8 * 0.6; i++)
        {
            Order order = orders[i] ?? throw new NullReferenceException();
            order.DeliveryDate = orders[i]?.ShipDate?.AddDays(rnd.Next(3, 6));
            orders[i] = order;
        }

    }
    static void InitializeProducts()
    {
        int id;
        for (int i = 0; i < 10; i++)
        {
            do id = rnd.Next(100000, 1000000);
            while (products.Exists(p => p?.ID == id));//validate uniqueness
            Product product = new Product
            {
                ID = id,
                Name = "TESTName" + i,
                Category = (Enums.Category)(i % CATEGORIES),
                Price = id / 10000,
                InStock = id / 100000,
            };
            products.Add(product);
        }
        Product outOfStockProduct = products[9] ?? throw new NullReferenceException();
        outOfStockProduct.InStock = 0;//one product is out of stock
        products[9] = outOfStockProduct;
    }
    static void InitialzieOrderItems()
    {
        for (int i = 0; i < 40; i++)
        {
            OrderItem orderItem = new OrderItem
            {
                ID = Config.orderItemId,
                ProductID = products[i % 9]?.ID ?? throw new NullReferenceException(),//TODO check if a product is ordered twice
                OrderID = orders[i % 20]?.ID ?? throw new NullReferenceException(),
                Price = products[i % 9]?.Price ?? throw new NullReferenceException(),
                Amount = 1 + i % 4
            };
            orderItems.Add(orderItem);
        }
    }
    static private void s_Initialize()
    {
        InitializeProducts();
        InitializeOrders();
        InitialzieOrderItems();
    }
}
