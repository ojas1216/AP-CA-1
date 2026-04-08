using System;

public class Order
{
    public int order_no;
    public string order_details;
    public int quantity;
    public double bill;

    public Order(int no, string details, int qty)
    {
        order_no = no;
        order_details = details;
        quantity = qty;
    }

    public void place_order()
    {
        Console.WriteLine("Order placed: " + order_details);
    }

    public double pay_bill(double price)
    {
        bill = price * quantity;
        return bill;
    }

    public void collect_order()
    {
        Console.WriteLine("Order collected: " + order_no);
    }

    public void display()
    {
        Console.WriteLine("Order No: " + order_no);
        Console.WriteLine("Item: " + order_details);
        Console.WriteLine("Quantity: " + quantity);
        Console.WriteLine("Bill: €" + bill);
    }
}