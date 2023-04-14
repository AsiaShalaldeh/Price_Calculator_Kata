namespace PriceCalculatorKata
{
    public class Discount
    {
        public decimal DiscountRate { get; set; }
        public Precedence DiscountPrecedence { get; set; }
        public decimal DiscountAmount { get; set; }

        public Discount(decimal discountRate, Precedence discountPrecedence)
        {
            DiscountRate = discountRate;
            DiscountPrecedence = discountPrecedence;
        }

        public decimal CalculateDiscount(decimal price)
        {
            //DiscountAmount = Math.Round(price * (rate / 100m), 2);
            //return DiscountAmount;
            if (DiscountPrecedence == Precedence.Before)
            {
                DiscountAmount = Math.Round(price * (DiscountRate / 100m), 2);
                return DiscountAmount;
            }
            else if (DiscountPrecedence == Precedence.After)
            {
                DiscountAmount = Math.Round(price * (DiscountRate / 100m), 2);
                return DiscountAmount;
            }
            else
                return 0;
        }
    }
}
