using SuperSimpleStockMarket.Models.Enum;

namespace SuperSimpleStockMarket.Models
{
    /// <summary>
    /// Class representing a Preferred Stock
    /// </summary>
    public class PreferredStock : Stock
    {
        public PreferredStock()
        {
            Type = StockType.Preferred;
        }

        public override float DividendYield(float price)
        {
            if (price > 0)
                return (FixedDividend * ParValue) / price;
            return 0;
        }
    }
}
