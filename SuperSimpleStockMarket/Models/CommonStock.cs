using SuperSimpleStockMarket.Models.Enum;

namespace SuperSimpleStockMarket.Models
{
    /// <summary>
    /// Class representing a Common Stock
    /// </summary>
    public class CommonStock : Stock
    {
        public CommonStock()
        {
            Type = StockType.Common;
        }

        public override float DividendYield(float price)
        {
            if (price > 0)
                return LastDividend / price;
            return 0;
        }
    }
}
