using System;
using System.Collections.Generic;

class Order1
{
    // Attributes (Encapsulation using private variables)
    private string order_details;
    private int quantity;
    private double bill;
    private int order_no;

    // Properties
    public string OrderDetails
    {
        get { return order_details; }
        set { order_details = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public double Bill
    {
        get { return bill; }
        set { bill = value; }
    }

    public int OrderNo
    {
        get { return order_no; }
        set { order_no = value; }
    }

    // Constructor
    public Order(int no, string details, int qty)
    {
        order_no = no;
        order_details = details;
        quantity = qty;
    }

    // Method to calculate bill
    public double pay_bill(double price)
    {
        bill = price * quantity;
        return bill;
    }

    // Display order
    public void place_order()
    {
        Console.WriteLine("\nORDER PLACED SUCCESSFULLY!");
        Console.WriteLine("Order Number: " + order_no);
    }

    // Collect order
    public void collect_order()
    {
        Console.WriteLine("Order " + order_no + " collected.");
    }
}

class Churros
{
    Queue<Order> orders = new Queue<Order>();
    int orderCounter = 1;

    public void place_order()
    {
        Console.WriteLine("\nDelicious Churros:");
        Console.WriteLine("1. Plain sugar (€6)");
        Console.WriteLine("2. Cinnamon sugar (€6)");
        Console.WriteLine("3. Chocolate sauce (€8)");
        Console.WriteLine("4. Nutella (€8)");

        Console.Write("\nChoose item: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        string item = "";
        double price = 0;

        switch (choice)
        {
            case 1:
                item = "Plain Sugar";
                price = 6;
                break;

            case 2:
                item = "Cinnamon Sugar";
                price = 6;
                break;

            case 3:
                item = "Chocolate Sauce";
                price = 8;
                break;

            case 4:
                item = "Nutella";
                price = 8;
                break;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Order o = new Order(orderCounter, item, qty);
        double total = o.pay_bill(price);

        o.place_order();

        Console.WriteLine("Total Bill: €" + total);

        orders.Enqueue(o);
        orderCounter++;
    }

    public void deliver_order()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No orders in queue.");
        }
        else
        {
            Order o = orders.Dequeue();
            o.collect_order();
        }
    }
}

class Program
{
    static void Main()
    {
        Churros system = new Churros();
        int option;

        do
        {
            Console.WriteLine("\nChoose your option:");
            Console.WriteLine("1. Place order");
            Console.WriteLine("2. Deliver order");
            Console.WriteLine("0. Exit");

            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    system.place_order();
                    break;

                case 2:
                    system.deliver_order();
                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        } while (option != 0);
    }
}


// --- Unit Test Class ---
class Test
{
    public static void RunTest()
    {
        Order o = new Order(1, "Nutella", 2);  // create an order
        double total = o.pay_bill(8);          // calculate bill

        if (total == 16)
        {
            Console.WriteLine("Unit Test Passed: pay_bill() works correctly.");
        }
        else
        {
            Console.WriteLine("Unit Test Failed: pay_bill() returned " + total);
        }
    }
}