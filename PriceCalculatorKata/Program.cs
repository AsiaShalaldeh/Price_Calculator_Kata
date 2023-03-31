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
            product.PrintProductInformation(20);
        }
    }
}
