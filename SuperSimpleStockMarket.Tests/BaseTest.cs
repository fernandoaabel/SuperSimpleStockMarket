using Microsoft.Extensions.DependencyInjection;
using SuperSimpleStockMarket.Interfaces;
using SuperSimpleStockMarket.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStockMarket.Tests
{
    public class BaseTest
    {
        public readonly ServiceProvider serviceProvider;

        public BaseTest()
        {
            // Setup our DI
            serviceProvider = new ServiceCollection()
                .AddSingleton<IStockRepository, StockRepository>()
                .AddSingleton<ITradeRepository, TradeRepository>()
                .AddSingleton<IStockMarketService, StockMarketService>()
                .BuildServiceProvider();
        }
    }
}
