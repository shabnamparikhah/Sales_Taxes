using System.Linq;
using System.Text.RegularExpressions;

namespace SalesTaxWin
{
    public class ItemParser
    {
        private static readonly string Input_Regex = "(\\d+) ([\\w\\s]* )at (\\d+.\\d{2})";
        private static readonly string Input_RegexWithOutDecimal = "(\\d+) ([\\w\\s]* )at (\\d+)";
        private static readonly string[] food = { "chocolate", "chocolates" };
        private static readonly string[] medical = { "pills" };
        private static readonly string[] book = { "book" };

        public static CardItem Parse(string[] listOfItemfull)
        {
            return new CardItem
            {
                CartItems = listOfItemfull.Select(Parse).ToList(),
            };
        }
        public static ShoppringCartItem Parse(string listOItem)
        {
            var regex = new Regex(Input_Regex);
            var match = regex.Match(listOItem);

            if (match.Success)
            {
                var quantity = int.Parse(match.Groups[1].Value);
                var price = decimal.Parse(match.Groups[3].Value);
                var itemName = match.Groups[2].Value.Trim();

                var shopcard = new ShoppringCartItem
                {
                    Quantity = quantity,
                    Product = new Product { Name = itemName, ShelfPrice = price }
                };

                return shopcard;
            }
            else
            {
                var regexNew = new Regex(Input_RegexWithOutDecimal);
                var matchWithOutDecimal = regexNew.Match(listOItem);

                if (matchWithOutDecimal.Success)
                {
                    var quantity = int.Parse(matchWithOutDecimal.Groups[1].Value);
                    var price = decimal.Parse(matchWithOutDecimal.Groups[3].Value);
                    var itemName = matchWithOutDecimal.Groups[2].Value.Trim();

                    var shopcard = new ShoppringCartItem
                    {
                        Quantity = quantity,
                        Product = new Product { Name = itemName, ShelfPrice = price }
                    };

                    return shopcard;
                }
                return null;
            }
            
        }
    }
}