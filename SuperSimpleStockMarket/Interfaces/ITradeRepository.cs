using SuperSimpleStockMarket.Models;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Interfaces
{
    public interface ITradeRepository
    {
        /// <summary>
        /// Get all existing Trade transactions
        /// </summary>
        /// <returns>List of <see cref="Trade"/></returns>
        List<Trade> GetAll();

        /// <summary>
        /// Get all existing Trade transactions for a specific Stock
        /// </summary>
        /// <param name="stockSymbol"><see cref="Stock"/>.Symbol</param>
        /// <returns>List of <see cref="Trade"/></returns>
        List<Trade> GetByStockSymbol(string stockSymbol);

        /// <summary>
        /// Creates a new Trade transaction of buy
        /// </summary>
        /// <param name="stock">Traded <see cref="Stock"/></param>
        /// <param name="price">Traded Price</param>
        /// <param name="quantity">Traded Quantity</param>
        /// <returns><see cref="Trade"/></returns>
        Trade Buy(Stock stock, float price, int quantity);

        /// <summary>
        /// Creates a new Trade transaction of sell
        /// </summary>
        /// <param name="stock">Traded <see cref="Stock"/></param>
        /// <param name="price">Traded Price</param>
        /// <param name="quantity">Traded Quantity</param>
        /// <returns><see cref="Trade"/></returns>
        Trade Sell(Stock stock, float price, int quantity);

        /// <summary>
        /// Get Volume Weighted Stock Price for a specific <see cref="Stock"/> based on trades in past 15 minutes
        /// </summary>
        /// <param name="stock"><see cref="Stock"/></param>
        /// <returns>Volume Weighted Stock Price value</returns>
        float GetVolumeWeightedStockPrice(Stock stock);

        /// <summary>
        /// Get GBCE All Share Index using the geometric mean of prices for all stocks
        /// </summary>
        /// <returns>GBCE All Share Index value</returns>
        float GetGBCEAllShareIndex();
    }
}
