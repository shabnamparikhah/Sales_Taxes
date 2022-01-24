using System.Linq;

namespace SalesTaxWin
{
    public class BasicTax : SalesTax
    {
        private EnumProduct[] _taxExcemptions = new[] { EnumProduct.Food, EnumProduct.Medical, EnumProduct.Book };

        public override bool IsApplicable(Product item)
        {
            return !(_taxExcemptions.Any(x => item.IsTypeOf(x)));
        }

        public override decimal Rate { get { return 10.00M; } }
    }
}
