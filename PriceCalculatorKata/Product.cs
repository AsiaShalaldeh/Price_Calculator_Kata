namespace PriceCalculatorKata
{
    public class Product
    {
        public string Name { get; set; }
        public long UPC { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        //public decimal Discount { get; set; }

        public decimal CalculatePriceWithTax(decimal taxRate = 20)
        {
            decimal tax = Math.Round(Price * (taxRate / 100m), 2);
            return Math.Round(Price + tax, 2);
        }
        public decimal CalculatePriceWithDiscount(decimal taxRate,decimal discountRate)
        {
            decimal priceWithTax = CalculatePriceWithTax(taxRate);
            decimal discount = Math.Round(Price * (discountRate / 100m), 2);
            return priceWithTax - discount;
        }
        public void PrintProductInformation(decimal taxRate, decimal discountRate)
        {
            Console.WriteLine($"{Type} With Name = {Name}, UPC= {UPC}, Price= ${Price}");
            Console.WriteLine($"{Type} price reported as ${Price} before tax " +
                $"and ${CalculatePriceWithTax(taxRate)} after {taxRate}% tax.");
            Console.WriteLine($"And after %{discountRate} discount, Price = " +
                $"${CalculatePriceWithDiscount(taxRate,discountRate)}");
        }
    }
}
