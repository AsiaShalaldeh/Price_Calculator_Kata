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

        public Product(string Name, long UPC, decimal Price, string Type,
            Tax tax, Discount discount, Discount UPCdiscount)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Price;
            this.Type = Type;
            this.UpdatedPrice = Price;
            this.tax = tax;
            this.discount = discount;
            this.UPCdiscount = UPCdiscount;
        }

        public decimal CalculateTax()
        {
            tax.TaxAmount = tax.CalculateTax(UpdatedPrice, tax.TaxRate);
            return tax.TaxAmount;
        }
        public decimal CalculateDiscount()
        {
            return discount.CalculateDiscount(UpdatedPrice);
        }

        public decimal CalculateUPCDiscount()
        {
            if (this.UPC == UPC)
            {
                return UPCdiscount.CalculateDiscount(UpdatedPrice);
            }
            return 0;
        }
        public decimal CalculatePrice()
        {
            if (discount.DiscountPrecedence == Precedence.Before)
            {
                UpdatedPrice -= CalculateDiscount();
            }
            if (UPCdiscount.DiscountPrecedence == Precedence.Before)
            {
                UpdatedPrice -= CalculateUPCDiscount();
            }
            UpdatedPrice += CalculateTax();
            if (discount.DiscountPrecedence == Precedence.After)
            {
                UpdatedPrice -= CalculateDiscount();
            }
            if (UPCdiscount.DiscountPrecedence == Precedence.After)
            {
                UpdatedPrice -= CalculateUPCDiscount();
            }
            return UpdatedPrice;
        }
        public decimal CalculateReducedAmount()
        {
            return discount.DiscountAmount + UPCdiscount.DiscountAmount;
        }
        public void PrintProductInformation()
        {
            Console.WriteLine($"{Type} With Name = {Name}, UPC = {UPC}, Price = ${Price}");
      
            Console.WriteLine($"{Type} price reported as ${Price}.");
            Console.WriteLine($"And after, Price = ${CalculatePrice()}");

            Console.Write($"Tax Amount = ${tax.TaxAmount}, ");
            if (discount.DiscountAmount != 0)
                Console.Write($"Discount = ${discount.DiscountAmount}");
            else
                Console.Write($"No Discount");
            Console.WriteLine($", UPC Discount = ${UPCdiscount.DiscountAmount}");

            Console.WriteLine($"Amount that was deduced = " +
            $"${CalculateReducedAmount()}");
        }
    }
}
