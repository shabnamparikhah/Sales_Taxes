using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxWin
{
    public class ImportedTax : SalesTax
    {
        public override bool IsApplicable(Product item)
        {
            return item.IsImported;
        }

        public override decimal Rate { get { return 5.00M; } }
    }
}
