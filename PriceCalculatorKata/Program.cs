﻿namespace PriceCalculatorKata
{
    class Program
    {
        public static void Main()
        {
            Discount discount = new Discount(15, Precedence.NoPrecedence);
            Discount UPCdiscount = new Discount(7, Precedence.NoPrecedence);
            Tax tax = new Tax(21);
            Cost packaging = new Cost(1, true,"Packaging");
            Cost transport = new Cost(2.2m, false, "Transport");

            IList<Cost> costs = new List<Cost>();
            costs.Add(packaging);
            costs.Add(transport);

            Product product = new Product("The Little Prince", 12345, 20.25m,
                "Book", tax, discount, UPCdiscount,costs);
            product.PrintProductInformation();
        }
    }
}
