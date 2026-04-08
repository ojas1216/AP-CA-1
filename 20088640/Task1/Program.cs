using System;
using System.Collections.Generic;

class Program
{
    static Queue<Order> q = new Queue<Order>();
    static int count = 1;

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\nDelicious Churros:");
            Console.WriteLine("1. Place Order");
            Console.WriteLine("2. Deliver Order");
            Console.WriteLine("0. Exit");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                place_order();
            else if (choice == 2)
                deliver_order();

        } while (choice != 0);

        // Unit test
        Console.WriteLine("\nRunning Test:");
        Order test = new Order(0, "Test", 2);
        double result = test.pay_bill(5);

        if (result == 10)
            Console.WriteLine("Test Passed");
        else
            Console.WriteLine("Test Failed");
    }

    static void place_order()
    {
        Console.WriteLine("1. Plain (€6)");
        Console.WriteLine("2. Cinnamon (€6)");
        Console.WriteLine("3. Chocolate (€8)");
        Console.WriteLine("4. Nutella (€8)");

        int opt = int.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        int qty = int.Parse(Console.ReadLine());

        Churros c = null;

        if (opt == 1) c = new Churros("Plain", 6);
        else if (opt == 2) c = new Churros("Cinnamon", 6);
        else if (opt == 3) c = new Churros("Chocolate", 8);
        else c = new Churros("Nutella", 8);

        Order o = new Order(count++, c.name, qty);

        o.place_order();

        double total = o.pay_bill(c.price);

        Console.WriteLine("Total Bill: €" + total);

        q.Enqueue(o);
    }

    static void deliver_order()
    {
        if (q.Count > 0)
        {
            Order o = q.Dequeue();
            o.collect_order();
            o.display();
        }
        else
        {
            Console.WriteLine("No orders in queue");
        }
    }
}