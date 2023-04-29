namespace PriceCalculatorKata
{
    public class Tax
    {
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }

        public Tax(decimal taxRate)
        {
            TaxRate = taxRate;
        }

        public decimal CalculateTax(decimal Price,decimal tax)
        {
            TaxAmount = Math.Round(Price * (tax / 100m), 2);
            return TaxAmount;
        }
    }
}
