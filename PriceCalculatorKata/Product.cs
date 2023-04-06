namespace PriceCalculatorKata
{
    public class Product
    {
        public string Name { get; set; }
        public long UPC { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }

        public Product()
        {

        }
        public Product(string Name, long UPC, decimal Price, string Type, decimal Tax, decimal Discount)
        {
            this.Name = Name;
            this.UPC = UPC;
            this.Price = Price;
            this.Type = Type;
            this.Tax = Tax;
            this.Discount = Discount;
        }

        public decimal CalculateTax()
        {
            return Math.Round(Price * (Tax / 100m), 2);
            //return Math.Round(Price + tax, 2);
        }
        public decimal CalculateDiscount()
        {
            return Math.Round(Price * (Discount / 100m), 2);
        }

        public decimal ApplyUPCDiscount(long UPC, decimal UPCDiscount)
        {
            if (this.UPC == UPC)
            {
                return Math.Round(Price * (UPCDiscount / 100m), 2);
            }
            return 0;
        }
        public decimal CalculatePrice(long UPC,decimal UPCDiscount)
        {
            decimal price = 0;
            price = Price + CalculateTax() - CalculateDiscount() - 
                ApplyUPCDiscount(UPC, UPCDiscount);
            return price;
        }
        public decimal CalculateReducedAmount(long UPC, decimal UPCDiscount)
        {
            decimal amount = ApplyUPCDiscount(UPC, UPCDiscount);
            if (Discount != 0)
                amount += Math.Round(Price * (Discount / 100m), 2);
            return amount;
        }
        public void PrintProductInformation(long UPC, decimal UPCDiscount)
        {
            Console.WriteLine($"{Type} With Name = {Name}, UPC = {UPC}, Price = ${Price}");
            Console.Write($"Tax Amount = ${CalculateTax()}, ");
            if (Discount != 0)
                Console.Write($"Discount = ${CalculateDiscount()}");
            else
                Console.Write($"No Discount");
            Console.WriteLine($", UPC Discount = ${ApplyUPCDiscount(UPC,UPCDiscount)}");
            Console.WriteLine($"{Type} price reported as ${Price}.");
            Console.WriteLine($"And after, Price = ${CalculatePrice(UPC, UPCDiscount)}");
            Console.WriteLine($"Amount that was deduced = " +
            $"${CalculateReducedAmount(UPC, UPCDiscount)}");
        }
    }
}
