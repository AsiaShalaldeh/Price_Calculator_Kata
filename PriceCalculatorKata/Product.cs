namespace PriceCalculatorKata
{
    public class Product
    {
        public string Name { get; set; }
        public long UPC { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public decimal CalculatePriceWithTax(decimal taxRate = 20)
        {
            decimal tax = Math.Round(Price * (taxRate / 100m), 2);
            return Math.Round(Price + tax, 2);
        }
        public void PrintProductInformation(decimal taxRate)
        {
            Console.WriteLine($"{Type} With Name = {Name}, UPC= {UPC}, Price= ${Price}");
            Console.WriteLine($"{Type} price reported as ${Price} before tax " +
                $"and ${CalculatePriceWithTax(taxRate)} after {taxRate}% tax.");
        }
    }
}
