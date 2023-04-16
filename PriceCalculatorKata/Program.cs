namespace PriceCalculatorKata
{
    class Program
    {
        public static void Main()
        {
            Discount discount = new Discount(0, Precedence.NoPrecedence, DiscountMethod.Additive);
            Discount UPCdiscount = new Discount(0, Precedence.NoPrecedence);
            Tax tax = new Tax(20);
            Cost packaging = new Cost(1, true, "Packaging");
            Cost transport = new Cost(2.2m, false, "Transport");

            IList<Cost> costs = new List<Cost>();
            costs.Add(packaging);
            costs.Add(transport);

            Cap cap = new Cap(4, false);

            Product product = new Product("The Little Prince", 12345, 17.76m,
                "Book", tax, discount, UPCdiscount, null, cap, "GBP");
            product.PrintProductInformation();
        }
    }
}
