

namespace Dal;//I guess
class Program
{
    private DalProduct dalProduct = new DalProduct();
    private DalOrder dalOrder = new DalOrder();
    private DalOrderItem dalOrderItem = new DalOrderItem();

    void main()
    {
        int option;
        bool success;
        do
        {
            Console.WriteLine("Welcome to the test menu\n" +
                "Please choose one of the following options:\n" +
                "keep in mind to use valid data only\n" +
                "0. Exit\n" +
                "1. Check Products\n" +
                "2. Check Orders\n" +
                "3. Check Order Items");
            success = int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 0:

                default:
                    if (!(success && (option == 0))) Console.WriteLine("Bad command! Go stand in the corner!");
                    break;
            }
        } while (success && (option==0));

    }
}