using System.Collections.Generic;
using System.Linq;

namespace SalesTaxWin
{

    public class CardItem
    {
        public IList<ShoppringCartItem> CartItems { get; set; }

        public decimal TotalTax { get { return CartItems.Sum(x => x.Tax); } }

        public decimal TotalCost { get { return CartItems.Sum(x => x.Cost); } }
    }
}
