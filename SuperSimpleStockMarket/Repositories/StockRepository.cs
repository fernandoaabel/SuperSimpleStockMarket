using SuperSimpleStockMarket.Interfaces;
using SuperSimpleStockMarket.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.Repositories
{
    public class StockRepository : IStockRepository
    {
        private List<Stock> _stocks = new List<Stock>()
        {
            new CommonStock() { Symbol = "TEA", LastDividend = 0, ParValue = 100 },
            new CommonStock() { Symbol = "POP", LastDividend = 8, ParValue = 100 },
            new CommonStock() { Symbol = "ALE", LastDividend = 23, ParValue = 60 },
            new PreferredStock() { Symbol = "GIN", LastDividend = 8, ParValue = 100, FixedDividend = 2 },
            new CommonStock() { Symbol = "JOE", LastDividend = 13, ParValue = 250 }
        };

        /// <summary>
        /// Get all existing <see cref="Stock"/>
        /// </summary>
        /// <returns>List of <see cref="Stock"/></returns>
        public List<Stock> GetAll()
        {
            return _stocks;
        }

        /// <summary>
        /// Get a specific <see cref="Stock"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns><see cref="Stock"/></returns>
        public Stock GetBySymbol(string symbol)
        {
            return _stocks.FirstOrDefault(x => x.Symbol.Equals(symbol));
        }
    }
}
