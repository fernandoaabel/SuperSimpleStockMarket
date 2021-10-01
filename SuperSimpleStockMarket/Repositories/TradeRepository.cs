using SuperSimpleStockMarket.Interfaces;
using SuperSimpleStockMarket.Models;
using SuperSimpleStockMarket.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private List<Trade> _trades = new List<Trade>()
        {
            new Trade() { StockSymbol = "TEA", Operation = TradeOperation.Buy, Price = 77, Quantity = 10, Timestamp = DateTime.Now.AddMinutes(-1) },
            new Trade() { StockSymbol = "TEA", Operation = TradeOperation.Sell, Price = 100, Quantity = 4, Timestamp = DateTime.Now.AddMinutes(-5) },
            new Trade() { StockSymbol = "TEA", Operation = TradeOperation.Sell, Price = 64, Quantity = 5, Timestamp = DateTime.Now.AddMinutes(-20) },
            new Trade() { StockSymbol = "TEA", Operation = TradeOperation.Buy, Price = 54, Quantity = 6, Timestamp = DateTime.Now.AddMinutes(-25) },
            new Trade() { StockSymbol = "POP", Operation = TradeOperation.Buy, Price = 19, Quantity = 7 , Timestamp = DateTime.Now.AddMinutes(-1)},
            new Trade() { StockSymbol = "POP", Operation = TradeOperation.Sell, Price = 20, Quantity = 1, Timestamp = DateTime.Now.AddMinutes(-4) },
            new Trade() { StockSymbol = "POP", Operation = TradeOperation.Buy, Price = 16, Quantity = 12, Timestamp = DateTime.Now.AddMinutes(-5) },
            new Trade() { StockSymbol = "POP", Operation = TradeOperation.Buy, Price = 15, Quantity = 100, Timestamp = DateTime.Now.AddMinutes(-16) },
            new Trade() { StockSymbol = "POP", Operation = TradeOperation.Buy, Price = 14, Quantity = 15, Timestamp = DateTime.Now.AddMinutes(-10) },
            new Trade() { StockSymbol = "ALE", Operation = TradeOperation.Sell, Price = 59, Quantity = 55, Timestamp = DateTime.Now.AddMinutes(-9) },
            new Trade() { StockSymbol = "ALE", Operation = TradeOperation.Buy, Price = 57, Quantity = 20, Timestamp = DateTime.Now.AddMinutes(-5) },
            new Trade() { StockSymbol = "ALE", Operation = TradeOperation.Buy, Price = 64, Quantity = 10, Timestamp = DateTime.Now.AddMinutes(-10) },
            new Trade() { StockSymbol = "ALE", Operation = TradeOperation.Buy, Price = 64, Quantity = 30, Timestamp = DateTime.Now.AddMinutes(-15) },
            new Trade() { StockSymbol = "ALE", Operation = TradeOperation.Sell, Price = 57, Quantity = 35, Timestamp = DateTime.Now.AddMinutes(-20) },
            new Trade() { StockSymbol = "ALE", Operation = TradeOperation.Buy, Price = 58, Quantity = 40, Timestamp = DateTime.Now.AddMinutes(-21) },
            new Trade() { StockSymbol = "GIN", Operation = TradeOperation.Sell, Price = 100, Quantity = 1, Timestamp = DateTime.Now.AddMinutes(-11) },
            new Trade() { StockSymbol = "GIN", Operation = TradeOperation.Buy, Price = 102, Quantity = 2, Timestamp = DateTime.Now.AddMinutes(-10) },
            new Trade() { StockSymbol = "GIN", Operation = TradeOperation.Buy, Price = 110, Quantity = 5, Timestamp = DateTime.Now.AddMinutes(-9) },
            new Trade() { StockSymbol = "GIN", Operation = TradeOperation.Buy, Price = 104, Quantity = 10, Timestamp = DateTime.Now.AddMinutes(-5) },
            new Trade() { StockSymbol = "GIN", Operation = TradeOperation.Buy, Price = 99, Quantity = 7, Timestamp = DateTime.Now.AddMinutes(-5) },
            new Trade() { StockSymbol = "JOE", Operation = TradeOperation.Sell, Price = 75, Quantity = 80, Timestamp = DateTime.Now.AddMinutes(-1) },
            new Trade() { StockSymbol = "JOE", Operation = TradeOperation.Buy, Price = 70, Quantity = 86, Timestamp = DateTime.Now.AddMinutes(-5) },
            new Trade() { StockSymbol = "JOE", Operation = TradeOperation.Buy, Price = 74, Quantity = 87, Timestamp = DateTime.Now.AddMinutes(-10) },
            new Trade() { StockSymbol = "JOE", Operation = TradeOperation.Sell, Price = 78, Quantity = 85, Timestamp = DateTime.Now.AddMinutes(-20) },
            new Trade() { StockSymbol = "JOE", Operation = TradeOperation.Buy, Price = 79, Quantity = 84, Timestamp = DateTime.Now.AddMinutes(-30) },
        };

        /// <summary>
        /// Get all existing Trade transactions
        /// </summary>
        /// <returns>List of <see cref="Trade"/></returns>
        public List<Trade> GetAll()
        {
            return _trades;
        }

        /// <summary>
        /// Get most recent trades within {intervalInMinutes} minutes
        /// </summary>
        /// <param name="stock"><see cref="Stock"/></param>
        /// <param name="intervalInMinutes">Interval in Minutes</param>
        /// <returns>List of <see cref="Trade"/></returns>
        public List<Trade> GetRecentTradesPerStock(Stock stock, int intervalInMinutes)
        {
            if (stock is null || intervalInMinutes == 0)
            {
                return new List<Trade>();
            }

            return _trades
                .Where(x => x.StockSymbol.Equals(stock.Symbol) &&
                x.Timestamp >= DateTime.Now.AddMinutes(-intervalInMinutes)).ToList();
        }

        /// <summary>
        /// Get all existing Trade transactions for a specific Stock
        /// </summary>
        /// <param name="stockSymbol"><see cref="Stock"/>.Symbol</param>
        /// <returns>List of <see cref="Trade"/></returns>
        public List<Trade> GetByStockSymbol(string stockSymbol)
        {
            return _trades.Where(x => x.StockSymbol.Equals(stockSymbol)).ToList();
        }

        /// <summary>
        /// Creates a new Trade transaction of Buy
        /// </summary>
        /// <param name="stock">Traded <see cref="Stock"/></param>
        /// <param name="price">Traded Price</param>
        /// <param name="quantity">Traded Quantity</param>
        /// <returns><see cref="Trade"/></returns>
        public Trade Buy(Stock stock, float price, int quantity)
        {
            var newTrade = new Trade()
            {
                StockSymbol = stock.Symbol,
                Operation = TradeOperation.Buy,
                Price = price,
                Quantity = quantity,
            };

            _trades.Add(newTrade);
            return newTrade;
        }

        /// <summary>
        /// Creates a new Trade transaction of Sell
        /// </summary>
        /// <param name="stock">Traded <see cref="Stock"/></param>
        /// <param name="price">Traded Price</param>
        /// <param name="quantity">Traded Quantity</param>
        /// <returns><see cref="Trade"/></returns>
        public Trade Sell(Stock stock, float price, int quantity)
        {
            var newTrade = new Trade()
            {
                StockSymbol = stock.Symbol,
                Operation = TradeOperation.Sell,
                Price = price,
                Quantity = quantity,
            };

            _trades.Add(newTrade);
            return newTrade;
        }

        /// <summary>
        /// Get Volume Weighted Stock Price for a specific <see cref="Stock"/> based on trades in past 15 minutes
        /// </summary>
        /// <param name="stock"><see cref="Stock"/></param>
        /// <returns>Volume Weighted Stock Price value</returns>
        public float GetVolumeWeightedStockPrice(Stock stock)
        {
            const int intervalInMinutes = 15;

            var latestTrades = GetRecentTradesPerStock(stock, intervalInMinutes);

            if (!latestTrades.Any())
            {
                return 0;
            }

            var sumPriceTimesQuantity = latestTrades.Sum(x => (x.Price * x.Quantity));
            var sumQuantities = latestTrades.Sum(x => x.Quantity);
            float vwsp = sumPriceTimesQuantity / sumQuantities;

            return vwsp;
        }

        /// <summary>
        /// Get GBCE All Share Index using the geometric mean of prices for all stocks
        /// </summary>
        /// <returns>GBCE All Share Index value</returns>
        public double GetGBCEAllShareIndex()
        {
            if (!_trades.Any())
            {
                return 0;
            }

            double geometricMean = 1;

            foreach (var trade in _trades.Where(x => x.Price > 0))
            {
                geometricMean *= trade.Price;
            }

            var gbceIndex = Math.Pow(geometricMean, (float) 1 / _trades.Count);

            return gbceIndex;
        }
    }
}
