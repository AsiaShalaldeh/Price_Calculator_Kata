namespace PriceCalculatorKata
{
    public class Discount
    {
        public decimal DiscountRate { get; set; }
        public Precedence DiscountPrecedence { get; set; }
        public decimal DiscountAmount { get; set; }
        public DiscountMethod Method { get; set; }

        public Discount(decimal discountRate)
        {
            DiscountRate = discountRate;
        }
        public Discount(decimal discountRate, Precedence discountPrecedence)
        {
            DiscountRate = discountRate;
            DiscountPrecedence = discountPrecedence;
        }

        public decimal CalculateDiscount(decimal price)
        {
            DiscountAmount = Math.Round(price * (DiscountRate / 100m), 2);
            return DiscountAmount;  
        }
    }
}
