using System;
using System.Collections.Generic;

class Churros
{
    public string Flavour { get; private set; }
    public double Price { get; private set; }

    public Churros(string flavour, double price)
    {
        Flavour = flavour;
        Price = price;
    }
}

class Order
{
    private static int _nextOrderNo = 1;

    public int    order_no      { get; private set; }
    public string order_details { get; private set; }
    public int    quantity      { get; private set; }
    public double bill          { get; private set; }

    public Order(string details, int qty, double unitPrice)
    {
        order_no      = _nextOrderNo++;
        order_details = details;
        quantity      = qty;
        bill          = 0;
    }

    public void place_order()
    {
        Console.WriteLine($"\n  Order #{order_no} placed!");
        Console.WriteLine($"  Item    : {order_details}");
        Console.WriteLine($"  Quantity: {quantity}");
    }

    public double pay_bill(double unitPrice)
    {
        bill = unitPrice * quantity;
        Console.WriteLine($"  Total Bill: €{bill:F2} — Payment received, thank you!");
        return bill;
    }

    public void collect_order()
    {
        Console.WriteLine($"\n  Order #{order_no} is ready — enjoy your Churros!");
    }
}

class Program
{
    static List<Churros> menu = new List<Churros>
    {
        new Churros("Churros with plain sugar",     6.00),
        new Churros("Churros with cinnamon sugar",  6.00),
        new Churros("Churros with chocolate sauce", 8.00),
        new Churros("Churros with Nutella",         8.00)
    };

    static Queue<Order> orderQueue = new Queue<Order>();

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("              Delicious Churros");
            Console.WriteLine("--------------------------------------------------");
            for (int i = 0; i < menu.Count; i++)
                Console.WriteLine($"  {i + 1}. {menu[i].Flavour}: €{menu[i].Price:F2}");

            Console.WriteLine("\n  1. Place order");
            Console.WriteLine("  2. Deliver order");
            Console.WriteLine("  0. Exit");
            Console.Write("\nEnter choice: ");

            switch (Console.ReadLine())
            {
                case "0": running = false; Console.WriteLine("\n  Goodbye!"); break;
                default:  Console.WriteLine("  Coming soon."); break;
            }
        }
    }
}