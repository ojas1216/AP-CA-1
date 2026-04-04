using System;

public class Order
{
    public string OrderDetails { get; set; }
    public int Quantity { get; set; }
    public double Bill { get; set; }
    public int OrderNo { get; set; }

    public Order(int orderNo, string details, int qty)
    {
        OrderNo = orderNo;
        OrderDetails = details;
        Quantity = qty;
    }

    public double PayBill(double price)
    {
        Bill = price * Quantity;
        return Bill;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"Order No: {OrderNo}, Item: {OrderDetails}, Qty: {Quantity}, Bill: €{Bill}");
    }
}