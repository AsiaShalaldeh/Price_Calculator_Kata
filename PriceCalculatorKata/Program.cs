namespace PriceCalculatorKata
{
    class Program
    {
        public static void Main()
        {
            Discount discount = new Discount(15, Precedence.After);
            Discount UPCdiscount = new Discount(7, Precedence.Before);
            Tax tax = new Tax(20);
            Product product = new Product("The Little Prince", 12345, 20.25m,
                "Book", tax, discount, UPCdiscount);
            product.PrintProductInformation();
        }
    }
}
