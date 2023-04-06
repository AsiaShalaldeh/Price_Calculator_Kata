namespace PriceCalculatorKata
{
    class Program
    {
        public static void Main()
        {
            Product product = new Product();
            product.UPC = 12345;
            product.Type = "Book";
            product.Name = "The Little Prince";
            product.Price = 20.25m;
            product.Tax = 21;
            //product.Discount = 15;
            product.PrintProductInformation(12345, 7);
        }
    }
}
