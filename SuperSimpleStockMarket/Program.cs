using Microsoft.Extensions.DependencyInjection;
using SuperSimpleStockMarket.Interfaces;
using SuperSimpleStockMarket.Repositories;

namespace SuperSimpleStockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IStockRepository, StockRepository>()
                .AddSingleton<ITradeRepository, TradeRepository>()
                .AddSingleton<IStockMarketService, StockMarketService>()
                .BuildServiceProvider();

            // Do the actual work here
            var stockMarket = serviceProvider.GetService<IStockMarketService>();
            stockMarket.StartMenu();
        }
    }
}
