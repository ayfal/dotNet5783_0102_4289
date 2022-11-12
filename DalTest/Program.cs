

namespace Dal;//I guess
class Program
{
    private DalProduct dalProduct = new DalProduct();
    private DalOrder dalOrder = new DalOrder();
    private DalOrderItem dalOrderItem = new DalOrderItem();

    void OrdersSubMenu()
    {
        char option;
        Console.WriteLine("Please choose one of the following options:\n" +
            "a. add an order\n" +
            "b. get an order\n" +
            "c. get all orders" +
            "d. update an order" +
            "e. delete an order");
        bool success = char.TryParse(Console.ReadLine(), out option);
        switch (option)
        {
            case 'a':
                Console.WriteLine("please enter th following details:");
                Console.Write("Customer name: ");
                string customerName = Console.ReadLine();

                \tEmail: {CustomerEmail}\r\n        Address: {CustomerAddress}\r\n        Order Date: {OrderDate}\r\n        Ship Date: {ShipDate}\r\n        Delivery Date: {DeliveryDate}    \t");

            default:
                if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                break;
        }
    } while (!(success && option == 0));
    }

    void main()
    {
        int option;
        bool success;
        do
        {
            Console.WriteLine("Welcome to the test menu!\n" +
                "Please choose one of the following options:\n" +
                "keep in mind to use valid data only\n" +
                "0. Exit\n" +
                "1. Check Products\n" +
                "2. Check Orders\n" +
                "3. Check Order Items");
            success = int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1:

                default:
                    if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                    break;
            }
        } while (!(success && option == 0));

    }
}