namespace PriceCalculatorKata
{
    public class Cap
    {
        public decimal Amount { get; set; }
        public bool IsPercentage { get; set; }

        public Cap(decimal amount, bool isPercentage)
        {
            Amount = amount;
            IsPercentage = isPercentage;
        }
        public decimal CalculateCap(decimal price)
        {
            if (IsPercentage)
                return Math.Round(price * (Amount / 100), 2);
            else
                return Amount;
        }
    }
}
