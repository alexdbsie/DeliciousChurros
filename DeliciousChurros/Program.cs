using System;
using System.Collections.Generic;

class Churros
{
    public string Flavour { get; private set; }
    public double Price { get; private set; }

    public Churros(string Flavour, double price)
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