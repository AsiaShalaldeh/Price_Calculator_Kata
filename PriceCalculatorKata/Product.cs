namespace PriceCalculatorKata
{
    public class Product
    {
        public string Name { get; set; }
        public long UPC { get; set; }
        public decimal Price { get; set; }
        public string CurrencyCode { get; set; }
        public decimal UpdatedPrice { get; set; }
        public string Type { get; set; }
        Discount discount;
        Discount UPCdiscount;
        Tax tax;
        IList<Cost> costs = null;
        Cap cap = null; // I will move this to Discount class (it's a discount property)

        public Product(string Name, long UPC, decimal Price, string Type,
            Tax tax, Discount discount, Discount UPCdiscount, IList<Cost> costs,Cap cap,
            string CurrencyCode)
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
            this.cap = cap;
            this.CurrencyCode = CurrencyCode;
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
            return Price - CalculateReducedAmount() + CalculateTax(Price) +
                Cost.CalculateCosts(costs, Price);
        }
        public decimal CalculateReducedAmount()
        {
            decimal totalDiscounts = 0;
            if (discount.Method == DiscountMethod.Multiplicative)
            {
                totalDiscounts = discount.CalculateDiscount(Price, discount, UPCdiscount)
                    + CalculateTax(Price);
            }
            else if ((discount.DiscountPrecedence == Precedence.NoPrecedence &&
                UPCdiscount.DiscountPrecedence == Precedence.NoPrecedence)
                || discount.Method == DiscountMethod.Additive)
            {
                totalDiscounts = CalculateDiscount(Price) + CalculateUPCDiscount(Price);
            }
            else
            {
                if (discount.DiscountPrecedence == Precedence.Before)
                {
                    totalDiscounts += CalculateDiscount(UpdatedPrice);
                }
                if (UPCdiscount.DiscountPrecedence == Precedence.Before)
                {
                    totalDiscounts+= CalculateUPCDiscount(UpdatedPrice);
                }
                UpdatedPrice += CalculateTax(UpdatedPrice);
                if (discount.DiscountPrecedence == Precedence.After)
                {
                    totalDiscounts += CalculateDiscount(UpdatedPrice);
                }
                if (UPCdiscount.DiscountPrecedence == Precedence.After)
                {
                    totalDiscounts += CalculateUPCDiscount(UpdatedPrice);
                }
            }
            return Math.Min(totalDiscounts, cap.CalculateCap(Price));
        }
        public void PrintProductInformation()
        {
            Console.WriteLine($"{Type} With Name = {Name}, UPC = {UPC}, Price = ${Price}");
      
            Console.WriteLine($"Price Before ${Price} {CurrencyCode}");
            Console.WriteLine($"Price After = ${CalculatePrice()} {CurrencyCode}");

            Console.WriteLine($"Tax Amount = ${tax.TaxAmount} {CurrencyCode}");

            Console.WriteLine($"Amount that was deduced = " +
            $"${CalculateReducedAmount()} {CurrencyCode}");

            if (costs != null)
            {
                foreach (Cost cost in costs)
                {
                    Console.WriteLine($"{cost.Description} = ${cost.Amount} {CurrencyCode}");
                }
            }
            else
                Console.WriteLine("No Costs !!");
        }
    }
}
