namespace PriceCalculatorKata
{
    public class Cost
    {
        public bool IsPercentage { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Cost(decimal amount, bool isPercentage, string description)
        {
            Amount = amount;
            IsPercentage = isPercentage;
            Description = description;
        }

        public static decimal CalculateCosts(IList<Cost> costs, decimal price)
        {
            decimal sum = 0;
            if (costs != null)
            {
                foreach (Cost cost in costs)
                {
                    if (cost.IsPercentage)
                    {
                        cost.Amount = Math.Round(price * (cost.Amount / 100), 2);
                        sum += cost.Amount;
                    }
                    else
                        sum += cost.Amount;
                }
            }
            return sum;
        }

    }
}
