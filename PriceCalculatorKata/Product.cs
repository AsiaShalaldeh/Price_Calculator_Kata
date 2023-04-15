namespace PriceCalculatorKata
{
    public class Product
    {
        public string Name { get; set; }
        public long UPC { get; set; }
        public decimal Price { get; set; }
        public decimal UpdatedPrice { get; set; }
        public string Type { get; set; }
        Discount discount;
        Discount UPCdiscount;
        Tax tax;
        IList<Cost> costs = null;

        public Product(string Name, long UPC, decimal Price, string Type,
            Tax tax, Discount discount, Discount UPCdiscount, IList<Cost> costs)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Price;
            this.Type = Type;
            this.UpdatedPrice = Price;
            this.tax = tax;
            this.discount = discount;
            this.UPCdiscount = UPCdiscount;
            this.costs = costs;
        }

        public decimal CalculateTax(decimal price)
        {
            tax.TaxAmount = tax.CalculateTax(price, tax.TaxRate);
            return tax.TaxAmount;
        }
        public decimal CalculateDiscount(decimal price)
        {
            return discount.CalculateDiscount(price);
        }

        public decimal CalculateUPCDiscount(decimal price)
        {
            if (this.UPC == UPC)
            {
                return UPCdiscount.CalculateDiscount(price);
            }
            return 0;
        }
        public decimal CalculatePrice()
        {
            if (discount.Method == DiscountMethod.Multiplicative)
            {
                return Price - discount.CalculateDiscount(Price, discount, UPCdiscount)
                    + CalculateTax(Price) + Cost.CalculateCosts(costs, Price);
            }
            else if ((discount.DiscountPrecedence == Precedence.NoPrecedence &&
                UPCdiscount.DiscountPrecedence == Precedence.NoPrecedence)
                || discount.Method == DiscountMethod.Additive)
            {
                return Price - CalculateDiscount(Price) - CalculateUPCDiscount(Price) +
                    CalculateTax(Price) + Cost.CalculateCosts(costs, Price);
            }
            else
            {
                if (discount.DiscountPrecedence == Precedence.Before)
                {
                    UpdatedPrice -= CalculateDiscount(UpdatedPrice);
                }
                if (UPCdiscount.DiscountPrecedence == Precedence.Before)
                {
                    UpdatedPrice -= CalculateUPCDiscount(UpdatedPrice);
                }
                UpdatedPrice += CalculateTax(UpdatedPrice);
                if (discount.DiscountPrecedence == Precedence.After)
                {
                    UpdatedPrice -= CalculateDiscount(UpdatedPrice);
                }
                if (UPCdiscount.DiscountPrecedence == Precedence.After)
                {
                    UpdatedPrice -= CalculateUPCDiscount(UpdatedPrice);
                }
                UpdatedPrice += Cost.CalculateCosts(costs, Price);
                return UpdatedPrice;
            }
        }
        public decimal CalculateReducedAmount()
        {
            return discount.DiscountAmount + UPCdiscount.DiscountAmount;
        }
        public void PrintProductInformation()
        {
            Console.WriteLine($"{Type} With Name = {Name}, UPC = {UPC}, Price = ${Price}");
      
            Console.WriteLine($"Price Before ${Price}");
            Console.WriteLine($"Price After = ${CalculatePrice()}");

            Console.Write($"Tax Amount = ${tax.TaxAmount}, ");
            if (discount.DiscountAmount != 0)
                Console.Write($"Discount = ${discount.DiscountAmount}");
            else
                Console.Write($"No Discount");
            Console.WriteLine($", UPC Discount = ${UPCdiscount.DiscountAmount}");

            Console.WriteLine($"Amount that was deduced = " +
            $"${CalculateReducedAmount()}");

            if (costs != null)
            {
                foreach (Cost cost in costs)
                {
                    Console.WriteLine($"{cost.Description} = ${cost.Amount}");
                }
            }
            else
                Console.WriteLine("No Costs !!");
        }
    }
}
