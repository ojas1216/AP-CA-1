using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class OrderTests
{
    [TestMethod]
    public void PayBill_CalculatesCorrectTotal()
    {
        // Arrange
        var order = new Order(1, "Plain Churros", 5);
        double price = 6.0;

        // Act
        double bill = order.PayBill(price);

        // Assert
        Assert.AreEqual(30.0, bill);
        Assert.AreEqual(30.0, order.Bill);
    }
}
