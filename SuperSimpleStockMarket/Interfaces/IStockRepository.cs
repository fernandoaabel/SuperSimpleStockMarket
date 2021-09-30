using SuperSimpleStockMarket.Models;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Interfaces
{
    public interface IStockRepository
    {
        /// <summary>
        /// Get all existing <see cref="Stock"/>
        /// </summary>
        /// <returns>List of <see cref="Stock"/></returns>
        List<Stock> GetAll();

        /// <summary>
        /// Get a specific <see cref="Stock"/>
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns><see cref="Stock"/></returns>
        Stock GetBySymbol(string symbol);
    }
}
