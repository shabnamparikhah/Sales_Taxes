using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxWin
{
    public abstract class SalesTax
    {
        abstract public bool IsApplicable(Product item);
        abstract public decimal Rate { get; }

        public decimal Calculate(Product item)
        {
            if (IsApplicable(item))
            {
                var tax = (item.ShelfPrice * Rate) / 100;
                tax = Math.Ceiling(tax / 0.05m) * 0.05m;
                return tax;
            }
           

            return 0;
        }
    }
}
