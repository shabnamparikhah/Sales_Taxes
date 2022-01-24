using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxWin
{
    public class Product
    {
        private static readonly IDictionary<EnumProduct, string[]> itemTypeDic = new Dictionary<EnumProduct, string[]>
    {
        {EnumProduct.Food, new[]{ "chocolate", "chocolates" }},
        {EnumProduct.Medical, new[]{ "pills" }},
        {EnumProduct.Book, new[]{ "book" }}
    };

        public decimal ShelfPrice { get; set; }

        public string Name { get; set; }

        public bool IsImported { get { return Name.Contains("Imported "); } }

        public bool IsTypeOf(EnumProduct productType)
        {
            return itemTypeDic.ContainsKey(productType) &&
                itemTypeDic[productType].Any(x => Name.Contains(x));
        }
        public override string ToString()
        {
            return string.Format("{0} at {1}", Name, ShelfPrice);
        }

    }

}

