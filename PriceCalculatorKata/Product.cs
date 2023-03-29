using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculatorKata
{
    public class Product
    {
        public string Name { get; set; }
        public long UPC { get; set; }
        public decimal Price { get; set; }

        public decimal CalculatePriceWithTax(decimal taxRate)
        {
            decimal tax = Math.Round(Price * (taxRate / 100m), 2);
            return Math.Round(Price + tax, 2);
        }
        public void PrintProductInformation()
        {
            Console.WriteLine($"Product With Name= {Name}, UPC= {UPC}, Price= ${Price}");
            Console.WriteLine($"Product price reported as {Price} before tax " +
                $"and {CalculatePriceWithTax} after 20% tax.");
        }
    }
}
