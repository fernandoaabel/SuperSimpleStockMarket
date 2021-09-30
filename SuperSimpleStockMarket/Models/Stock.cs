using SuperSimpleStockMarket.Helper;
using SuperSimpleStockMarket.Models.Enum;
namespace SuperSimpleStockMarket.Models
{
    /// <summary>
    /// Class for Stock (abstract)
    /// </summary>
    public abstract class Stock
    {
        public string Symbol { get; set; }        
        public StockType Type { get; set; }        
        public float LastDividend { get; set; }        
        public float FixedDividend { get; set; }        
        public float ParValue { get; set; }
        
        /// <summary>
        /// Calculate the Dividend Yield value for a specific price
        /// </summary>
        /// <param name="price">Price</param>
        /// <returns>Dividend Yield value</returns>
        public abstract float DividendYield(float price);

        /// <summary>
        /// Calculate the Price To Earnings Ratio for a specific price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public float PriceToEarningsRatio(float price)
        {
            if (LastDividend > 0)
                return price / LastDividend;
            return 0;
        }

        public override string ToString()
        {
            return $"{Symbol,ConsoleHelper.Padding} | {Type,ConsoleHelper.Padding} | {LastDividend,ConsoleHelper.Padding} | {FixedDividend,ConsoleHelper.Padding} | {ParValue,ConsoleHelper.Padding}";
        }
    }
}
