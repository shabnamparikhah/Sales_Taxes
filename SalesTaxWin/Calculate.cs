using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxWin
{
    public class Calculate
    {
        private SalesTax[] _Taxes = new SalesTax[] { new BasicTax(), new ImportedTax() };

        public void CalculateIn(CardItem shoppringCart)
        {
            foreach (var cartItem in shoppringCart.CartItems)
            {
                try
                {
                    cartItem.Tax = _Taxes.Sum(x => x.Calculate(cartItem.Product));
                }
                catch (Exception)
                {
                  
                }
                
            }
        }
    }
    
}
