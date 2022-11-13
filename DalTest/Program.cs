using DO;
using System.Diagnostics;
using System.Numerics;

namespace Dal;
class Program
{
    static private DalProduct dalProduct = new DalProduct();
    static private DalOrder dalOrder = new DalOrder();
    static private DalOrderItem dalOrderItem = new DalOrderItem();
    static int integer;
    static double dbl;
    static DateTime date;
    static string s;

    static void ProductsSubMenu()
    {
        try
        {
            char option;
            Console.WriteLine("Please choose one of the following options:\n" +
                "a. add a product\n" +
                "b. get a product\n" +
                "c. get all products\n" +
                "d. update a product\n" +
                "e. delete a product");
            bool success = char.TryParse(Console.ReadLine(), out option);
            switch (option)//TODO eliminate needless repetition with functions
            {
                case 'a':
                    Product newProduct = new Product();
                    Console.WriteLine("please enter the following details:");
                    Console.Write("Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out integer)) newProduct.ID = integer;
                    else throw new Exception("Not a valid ID");
                    Console.Write("Product Name: ");
                    newProduct.Name = Console.ReadLine();
                    Console.Write("Category Number: ");
                    if (int.TryParse(Console.ReadLine(), out integer) && Enum.IsDefined(typeof(Enums.Category), integer)) newProduct.Category = (Enums.Category)integer;
                    else throw new Exception("Not a valid category");
                    Console.Write("Price: ");
                    if (double.TryParse(Console.ReadLine(), out dbl)) newProduct.Price = dbl;
                    else throw new Exception("Not a valid Price");
                    Console.Write("Amount in stock: ");
                    if (int.TryParse(Console.ReadLine(), out integer)) newProduct.InStock = integer;
                    else throw new Exception("Not a valid amount");
                    dalProduct.Add(newProduct);
                    break;
                case 'b':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    Console.WriteLine(dalProduct.Get(integer));
                    break;
                case 'c':
                    foreach (var o in dalProduct.Get())
                    {
                        Console.WriteLine(o);
                    }
                    break;
                case 'd':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    Product product = dalProduct.Get(integer);
                    Console.WriteLine(product);
                    Console.WriteLine("please enter the following details:\n" +
                        "insert values only in details you want to change");
                    Console.Write("Name: ");
                    s = Console.ReadLine();
                    if (s != "") product.Name = s;
                    Console.Write("Category: ");
                    s = Console.ReadLine();
                    if (s != "")
                    {
                        if (int.TryParse(s, out integer) && Enum.IsDefined(typeof(Enums.Category), integer)) product.Category = (Enums.Category)integer;
                        else throw new Exception("Not a valid category");
                    }
                    Console.Write("Price: ");
                    s = Console.ReadLine();
                    if (s != "")
                    {
                        if (double.TryParse(s, out dbl)) product.Price = dbl;
                        else throw new Exception("Not a valid Price");
                    }
                    Console.Write("Amount in stock: ");
                    s = Console.ReadLine();
                    if (s != "")
                    {
                        if (int.TryParse(s, out integer)) product.InStock = integer;
                        else throw new Exception("Not a valid amount");
                    }
                    dalProduct.Update(product);
                    break;
                case 'e':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    dalProduct.Delete(integer);
                    break;
                default:
                    if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void OrdersSubMenu()
    {
        try
        {
            char option;
            Console.WriteLine("Please choose one of the following options:\n" +
                "a. add an order\n" +
                "b. get an order\n" +
                "c. get all orders\n" +
                "d. update an order\n" +
                "e. delete an order");
            bool success = char.TryParse(Console.ReadLine(), out option);
            switch (option)//TODO eliminate needless repetition with functions
            {
                case 'a':
                    Order newOrder = new Order();
                    Console.WriteLine("please enter the following details:");
                    Console.Write("Customer name: ");
                    newOrder.CustomerName = Console.ReadLine();
                    Console.Write("Customer Email: ");
                    newOrder.CustomerEmail = Console.ReadLine();
                    Console.Write("Customer address: ");
                    newOrder.CustomerAddress = Console.ReadLine();
                    do
                    {
                        Console.Write("Order date: ");
                    } while (!DateTime.TryParse(Console.ReadLine(), out date));//the program mustn't conatain logic. is this logic?
                    newOrder.OrderDate = date;
                    do
                    {
                        Console.Write("Ship date: ");
                    } while (!DateTime.TryParse(Console.ReadLine(), out date));
                    newOrder.ShipDate = date;
                    do
                    {
                        Console.Write("Delivery date: ");
                    } while (!DateTime.TryParse(Console.ReadLine(), out date));
                    newOrder.DeliveryDate = date;
                    dalOrder.Add(newOrder);
                    break;
                case 'b':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    Console.WriteLine(dalOrder.Get(integer));
                    break;
                case 'c':
                    foreach (var o in dalOrder.Get())
                    {
                        Console.WriteLine(o);
                    }
                    break;
                case 'd':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    Order order = dalOrder.Get(integer);
                    Console.WriteLine(order);
                    Console.WriteLine("please enter the following details:\n" +
                        "insert values only in details you want to change");
                    Console.Write("Customer name: ");
                    s = Console.ReadLine();
                    if (s != "") order.CustomerName = s;
                    Console.Write("Customer Email: ");
                    s = Console.ReadLine();
                    if (s != "") order.CustomerEmail = s;
                    Console.Write("Customer address: ");
                    s = Console.ReadLine();
                    if (s != "") order.CustomerAddress = s;
                    do
                    {
                        Console.Write("Order date: ");
                        s = Console.ReadLine();
                    } while (!DateTime.TryParse(s, out date) && s != "");
                    if (s != "") order.OrderDate = date;
                    do
                    {
                        Console.Write("Ship date: ");
                        s = Console.ReadLine();
                    } while (!DateTime.TryParse(s, out date) && s != "");
                    if (s != "") order.ShipDate = date;
                    do
                    {
                        Console.Write("Delivery date: ");
                        s = Console.ReadLine();
                    } while (!DateTime.TryParse(s, out date) && s != "");
                    if (s != "") order.DeliveryDate = date;
                    dalOrder.Update(order);
                    break;
                case 'e':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    dalOrder.Delete(integer);
                    break;
                default:
                    if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void OrderItemsSubMenu()
    {
        try
        {
            char option;
            Console.WriteLine("Please choose one of the following options:\n" +
                "a. add an order item\n" +
                "b. get an order item\n" +
                "c. get all order items\n" +
                "d. update an order item\n" +
                "e. delete an order item\n" +
                "f. get order item by product ID and order ID\n" +
                "g. get order items by order ID");
            bool success = char.TryParse(Console.ReadLine(), out option);
            switch (option)//TODO eliminate needless repetition with functions
            {
                case 'a':
                    OrderItem newOrderItem = new OrderItem();
                    Console.WriteLine("please enter the following details:");
                    Console.Write("Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out integer)) newOrderItem.ProductID = integer;
                    else throw new Exception("Not a valid ID");
                    Console.Write("Order ID: ");
                    if (int.TryParse(Console.ReadLine(), out integer)) newOrderItem.OrderID = integer;
                    else throw new Exception("Not a valid ID");
                    Console.Write("Price: ");
                    if (double.TryParse(Console.ReadLine(), out dbl)) newOrderItem.Price = dbl;
                    else throw new Exception("Not a valid Price");
                    Console.Write("Amount of product: ");
                    if (int.TryParse(Console.ReadLine(), out integer)) newOrderItem.Amount = integer;
                    else throw new Exception("Not a valid amount"); Console.Write("Customer name: ");
                    dalOrderItem.Add(newOrderItem);
                    break;
                case 'b':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    Console.WriteLine(dalOrderItem.Get(integer));
                    break;
                case 'c':
                    foreach (var o in dalOrderItem.Get())
                    {
                        Console.WriteLine(o);
                    }
                    break;
                case 'd':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    OrderItem orderItem = dalOrderItem.Get(integer);
                    Console.WriteLine(orderItem);
                    Console.WriteLine("please enter the following details:\n" +
                        "insert values only in details you want to change");
                    Console.Write("Product ID: ");
                    s = Console.ReadLine();
                    if (s != "")
                    {
                        if (int.TryParse(s, out integer)) orderItem.ProductID = integer;
                        else throw new Exception("Not a valid ID");
                    }
                    Console.Write("Order ID: ");
                    s = Console.ReadLine();
                    if (s != "")
                    {
                        if (int.TryParse(s, out integer)) orderItem.OrderID = integer;
                        else throw new Exception("Not a valid ID");
                    }
                    Console.Write("Price: ");
                    s = Console.ReadLine();
                    if (s != "")
                    {
                        if (double.TryParse(s, out dbl)) orderItem.Price = dbl;
                        else throw new Exception("Not a valid Price");
                    }
                    Console.Write("Amount in stock: ");
                    s = Console.ReadLine();
                    if (s != "")
                    {
                        if (int.TryParse(s, out integer)) orderItem.Amount = integer;
                        else throw new Exception("Not a valid amount");
                    }
                    dalOrderItem.Update(orderItem);
                    break;
                case 'e':
                    do
                    {
                        Console.Write("Please insert an ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out integer));
                    dalOrderItem.Delete(integer);
                    break;
                case 'f':
                    Console.WriteLine("Please insert order ID press enter and then product ID");
                    int oID, pID;
                    if (!int.TryParse(Console.ReadLine(), out oID) || !int.TryParse(Console.ReadLine(), out pID)) throw new Exception("Not a valid ID");
                    Console.WriteLine(dalOrderItem.Get(pID, oID));
                    break;
                case 'g':
                    Console.WriteLine("Please insert order ID:");
                    if (!int.TryParse(Console.ReadLine(), out integer)) throw new Exception("Not a valid ID");
                    Console.WriteLine(dalOrderItem.Get(integer));
                    break;
                default:
                    if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Main(string[] args)
    {
        int option;
        bool success;
        do
        {
            Console.WriteLine("Welcome to the test menu!\n" +//TODO menues should use enums
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
                    ProductsSubMenu();
                    break;
                case 2:
                    OrdersSubMenu();
                    break;
                case 3:
                    OrderItemsSubMenu();
                    break;
                default:
                    if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                    break;
            }
        } while (!(success && option == 0));

    }
}