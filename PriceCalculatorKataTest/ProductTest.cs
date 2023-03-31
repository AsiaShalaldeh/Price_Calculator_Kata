using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculatorKata;

namespace PriceCalculatorKataTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void CalculatePriceWithTaxTest(decimal taxRate)
        {
            Product product = new Product()
            {
                Name = "The Little Prince",
                Price = 20.25,
                Type = "Book",
                UPC = 12345
            };
            decimal price = product.CalculatePriceWithTax(20);
            Assert.AreEqual(price, 24.30);
        }
    }
}
