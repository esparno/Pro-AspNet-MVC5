using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discountHelper;
        private static int counter = 0;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            this.discountHelper = discountHelper;
            System.Diagnostics.Debug.WriteLine(string.Format("Instance {0} created", ++counter));
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discountHelper.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}