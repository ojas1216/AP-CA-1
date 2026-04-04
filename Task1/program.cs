using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static Queue<Order> orderQueue = new Queue<Order>();
    static List<Churros> menu = new List<Churros>();
    static List<Order> deliveredOrders = new List<Order>();
    static int orderCounter = 1;
    static string menuFile = "churros_menu.json";
    static string ordersFile = "orders.json";

    static void Main()
    {
        LoadMenu();
        LoadDeliveredOrders();

        if (deliveredOrders.Count > 0)
            orderCounter = deliveredOrders.Count + 1;

        while (true)
        {
            Console.WriteLine("\n--- Delicious Churros ---");
            Console.WriteLine("1. Place Order");
            Console.WriteLine("2. Deliver Order");
            Console.WriteLine("0. Exit");

            string input = Console.ReadLine()?.Trim();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Please enter 0, 1, or 2.");
                continue;
            }

            if (choice == 1)
                PlaceOrder();
            else if (choice == 2)
                DeliverOrder();
            else if (choice == 0)
                break;
            else
                Console.WriteLine("Please select a valid option.");
        }

        Console.WriteLine("Goodbye!");
    }

    static void LoadMenu()
    {
        if (File.Exists(menuFile))
        {
            try
            {
                string json = File.ReadAllText(menuFile);
                menu = JsonSerializer.Deserialize<List<Churros>>(json) ?? new List<Churros>();
            }
            catch
            {
                menu = GetDefaultMenu();
                SaveMenu();
            }
        }
        else
        {
            menu = GetDefaultMenu();
            SaveMenu();
        }
    }

    static void SaveMenu()
    {
        string json = JsonSerializer.Serialize(menu, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(menuFile, json);
    }

    static List<Churros> GetDefaultMenu()
    {
        return new List<Churros>
        {
            new Churros("Plain", 6),
            new Churros("Cinnamon", 6),
            new Churros("Chocolate", 8),
            new Churros("Nutella", 8)
        };
    }

    static void LoadDeliveredOrders()
    {
        if (File.Exists(ordersFile))
        {
            try
            {
                string json = File.ReadAllText(ordersFile);
                deliveredOrders = JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
            }
            catch
            {
                deliveredOrders = new List<Order>();
            }
        }
    }

    static void SaveDeliveredOrders()
    {
        string json = JsonSerializer.Serialize(deliveredOrders, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ordersFile, json);
    }

    static void PlaceOrder()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("Menu is not available.");
            return;
        }

        Console.WriteLine("Choose a churros option:");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i].Name} (€{menu[i].Price})");
        }

        Console.Write("Option: ");
        string optionInput = Console.ReadLine()?.Trim();
        if (!int.TryParse(optionInput, out int option) || option < 1 || option > menu.Count)
        {
            Console.WriteLine("Invalid option. Please try again.");
            return;
        }

        Console.Write("Quantity: ");
        string qtyInput = Console.ReadLine()?.Trim();
        if (!int.TryParse(qtyInput, out int qty) || qty <= 0)
        {
            Console.WriteLine("Quantity must be a positive number.");
            return;
        }

        Churros item = menu[option - 1];
        Order order = new Order(orderCounter++, item.Name, qty);
        double total = order.PayBill(item.Price);

        Console.WriteLine($"Bill: €{total}");
        orderQueue.Enqueue(order);
    }

    static void DeliverOrder()
    {
        if (orderQueue.Count > 0)
        {
            Order order = orderQueue.Dequeue();
            Console.WriteLine("Delivered:");
            order.DisplayOrder();
            deliveredOrders.Add(order);
            SaveDeliveredOrders();
        }
        else
        {
            Console.WriteLine("No orders in queue.");
        }
    }
}