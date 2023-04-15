namespace PriceCalculatorKata
{
    public class Discount
    {
        public decimal DiscountRate { get; set; }
        public Precedence DiscountPrecedence { get; set; }
        public decimal DiscountAmount { get; set; }
        public DiscountMethod Method { get; set; }

        public Discount(decimal discountRate, Precedence discountPrecedence)
        {
            DiscountPrecedence = discountPrecedence;
            DiscountRate = discountRate;
        }

        public Discount(decimal discountRate, Precedence discountPrecedence, DiscountMethod discountMethod)
        {
            DiscountRate = discountRate;
            DiscountPrecedence = discountPrecedence;
            Method = discountMethod;
        }

        // Additive Discount
        public decimal CalculateDiscount(decimal price)
        {
            DiscountAmount = Math.Round(price * (DiscountRate / 100m), 2);
            Console.WriteLine("Dis " + DiscountRate);
            return DiscountAmount;
        }

        // Multiplicative Discount
        public decimal CalculateDiscount(decimal price, Discount discount, Discount UPCdiscount)
        {
            decimal totalDiscounts = CalculateDiscount(price);
            UPCdiscount.DiscountAmount = Math.Round((price - totalDiscounts) * (UPCdiscount.DiscountRate / 100m), 2);
            totalDiscounts += UPCdiscount.DiscountAmount;
            return totalDiscounts;
        }
    }
}
