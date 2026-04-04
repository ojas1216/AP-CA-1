using System;
using System.Collections.Generic;

class Program
{
    static Queue<Order> orderQueue = new Queue<Order>();
    static int orderCounter = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Delicious Churros ---");
            Console.WriteLine("1. Place Order");
            Console.WriteLine("2. Deliver Order");
            Console.WriteLine("0. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                PlaceOrder();
            else if (choice == 2)
                DeliverOrder();
            else
                break;
        }
    }

    static void PlaceOrder()
    {
        Console.WriteLine("1. Plain (€6)");
        Console.WriteLine("2. Cinnamon (€6)");
        Console.WriteLine("3. Chocolate (€8)");
        Console.WriteLine("4. Nutella (€8)");

        int option = int.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        int qty = int.Parse(Console.ReadLine());

        Churros item = null;

        if (option == 1) item = new Churros("Plain", 6);
        else if (option == 2) item = new Churros("Cinnamon", 6);
        else if (option == 3) item = new Churros("Chocolate", 8);
        else item = new Churros("Nutella", 8);

        Order order = new Order(orderCounter++, item.Name, qty);
        double total = order.PayBill(item.Price);

        Console.WriteLine("Bill: €" + total);
        orderQueue.Enqueue(order);
    }

    static void DeliverOrder()
    {
        if (orderQueue.Count > 0)
        {
            Order order = orderQueue.Dequeue();
            Console.WriteLine("Delivered:");
            order.DisplayOrder();
        }
        else
        {
            Console.WriteLine("No orders in queue.");
        }
    }
}