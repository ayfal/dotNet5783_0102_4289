using BlApi;
using BlImplementation;
using BO;
using Dal;
using DalApi;
using System.Collections.Generic;
using System.Numerics;

namespace BlTest
{
    internal class Program
    {
        static int integer;
        static double dbl;
        static DateTime date;
        static string s;
        static IBl bl = new Bl();
        static Cart demoCart = new Cart() { CustomerName = "demo name", CustomerEmail = "demo@email.com", CustomerAddress = "demo address" };

        static void ProductsSubMenu()
        {
            try
            {
                char option;
                Console.WriteLine("Please choose one of the following options:\n" +
                    "a. add a product\n" +
                    "b. get a product (manager screen)\n" +
                    "c. get a product (client screen)\n" +
                    "d. get all products\n" +
                    "e. update a product\n" +
                    "f. delete a product");
                bool success = char.TryParse(Console.ReadLine(), out option);
                switch (option)//TODO eliminate needless repetition with functions
                {
                    case 'a':
                        Product newProduct = new Product();
                        Console.WriteLine("please enter the following details:");
                        Console.Write("Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out integer) && integer >= 100000) newProduct.ID = integer;
                        else throw new InvalidDataException();
                        Console.Write("Product Name: ");
                        s = Console.ReadLine();
                        if (s != "") newProduct.Name = s;
                        else throw new InvalidDataException();
                        Console.Write("Category Number: ");
                        if (int.TryParse(Console.ReadLine(), out integer) && Enum.IsDefined(typeof(Enums.Category), integer)) newProduct.Category = (Enums.Category)integer;
                        else throw new InvalidDataException();
                        Console.Write("Price: ");
                        if (double.TryParse(Console.ReadLine(), out dbl)) newProduct.Price = dbl;
                        else throw new InvalidDataException();
                        Console.Write("Amount in stock: ");
                        if (int.TryParse(Console.ReadLine(), out integer)) newProduct.InStock = integer;
                        else throw new InvalidDataException();
                        bl._product.Add(newProduct);
                        break;
                    case 'b':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer >= 100000)) throw new InvalidDataException();
                        Console.WriteLine(bl._product.GetProdcutDetails(integer));
                        break;
                    case 'c':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer >= 100000)) throw new InvalidDataException();
                        Console.WriteLine(bl._product.GetProductDetails(integer, demoCart));
                        break;
                    case 'd':
                        foreach (var o in bl._product.GetProductsList())
                        {
                            Console.WriteLine(o);
                        }
                        break;
                    case 'e':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer >= 100000)) throw new InvalidDataException();
                        Product product = bl._product.GetProdcutDetails(integer);
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
                            else throw new InvalidDataException();
                        }
                        Console.Write("Price: ");
                        s = Console.ReadLine();
                        if (s != "")
                        {
                            if (double.TryParse(s, out dbl)) product.Price = dbl;
                            else throw new InvalidDataException();
                        }
                        Console.Write("Amount in stock: ");
                        s = Console.ReadLine();
                        if (s != "")
                        {
                            if (int.TryParse(s, out integer)) product.InStock = integer;
                            else throw new InvalidDataException();
                        }
                        bl._product.Update(product);
                        break;
                    case 'f':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer >= 100000)) throw new InvalidDataException();
                        bl._product.Delete(integer);
                        break;
                    default:
                        if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e/*.Message*/);
            }
        }

        static void OrdersSubMenu()
        {
            try
            {
                char option;
                Console.WriteLine("Please choose one of the following options:\n" +
                    "a. get all orders\n" +
                    "b. get an order\n" +
                    "c. report shipping\n" +
                    "d. report delivery\n" +
                    "e. update an order\n" +
                    "f. track an order");
                bool success = char.TryParse(Console.ReadLine(), out option);
                switch (option)//TODO eliminate needless repetition with functions
                {
                    case 'a':
                        foreach (var o in bl._order.Get())
                        {
                            Console.WriteLine(o);
                        }
                        break;
                    case 'b':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer > 0)) throw new InvalidDataException();
                        Console.WriteLine(bl._order.GetOrderDetails(integer));
                        break;
                    case 'c':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer > 0)) throw new InvalidDataException();
                        Console.WriteLine(bl._order.UpdateShipping(integer));
                        break;
                    case 'd':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer > 0)) throw new InvalidDataException();
                        Console.WriteLine(bl._order.UpdateDelivery(integer));
                        break ;
                    case 'e':
                        int orderID, productID, newAmount;
                        Console.Write("Please insert an order ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out orderID) && integer > 0)) throw new InvalidDataException();
                        Order order = bl._order.GetOrderDetails(orderID);
                        Console.WriteLine(order);
                        Console.Write("Please insert a product ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out productID) && integer >= 100000)) throw new InvalidDataException();
                        Console.Write("Please insert a new amount: ");
                        if (!(int.TryParse(Console.ReadLine(), out newAmount) && integer >= 0)) throw new InvalidDataException();
                        bl._order.Update(orderID,productID,newAmount);
                        break;
                    case 'f':
                        Console.Write("Please insert an ID: ");
                        if (!(int.TryParse(Console.ReadLine(), out integer) && integer > 0)) throw new InvalidDataException();
                        Console.WriteLine(bl._order.Track(integer));                       
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

        static void CartsSubMenu()
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
                        idal._orderItem.Add(newOrderItem);
                        break;
                    case 'b':
                        do
                        {
                            Console.Write("Please insert an ID: ");
                        } while (!int.TryParse(Console.ReadLine(), out integer));
                        Console.WriteLine(idal._orderItem.Get(integer));
                        break;
                    case 'c':
                        foreach (var o in idal._orderItem.Get())
                        {
                            Console.WriteLine(o);
                        }
                        break;
                    case 'd':
                        do
                        {
                            Console.Write("Please insert an ID: ");
                        } while (!int.TryParse(Console.ReadLine(), out integer));
                        OrderItem orderItem = idal._orderItem.Get(integer);
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
                        idal._orderItem.Update(orderItem);
                        break;
                    case 'e':
                        do
                        {
                            Console.Write("Please insert an ID: ");
                        } while (!int.TryParse(Console.ReadLine(), out integer));
                        idal._orderItem.Delete(integer);
                        break;
                    case 'f':
                        Console.WriteLine("Please insert order ID press enter and then product ID");
                        int oID, pID;
                        if (!int.TryParse(Console.ReadLine(), out oID) || !int.TryParse(Console.ReadLine(), out pID)) throw new Exception("Not a valid ID");
                        Console.WriteLine(idal._orderItem.Get(pID, oID));
                        break;
                    case 'g':
                        Console.WriteLine("Please insert order ID:");
                        if (!int.TryParse(Console.ReadLine(), out integer)) throw new Exception("Not a valid ID");
                        Console.WriteLine(idal._orderItem.Get(integer));
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
                    "0. Exit\n" +
                    "1. Check Products\n" +
                    "2. Check Carts\n" +
                    "3. Check Orders");
                success = int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        ProductsSubMenu();
                        break;
                    case 2:
                        CartsSubMenu();
                        break;
                    case 3:
                        OrdersSubMenu();
                        break;
                    default:
                        if (!(success && option == 0)) Console.WriteLine("Bad command! Go stand in the corner!");
                        break;
                }
            } while (!(success && option == 0));

        }
    }

}