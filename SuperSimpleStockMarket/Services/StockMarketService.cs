using SuperSimpleStockMarket.Helper;
using SuperSimpleStockMarket.Interfaces;
using SuperSimpleStockMarket.Models;
using SuperSimpleStockMarket.Models.Enum;
using System;
using System.Linq;

namespace SuperSimpleStockMarket
{
    public class StockMarketService : IStockMarketService
    {
        IStockRepository _stockRepository;
        ITradeRepository _tradeRepository;

        public StockMarketService(IStockRepository stockRepository, ITradeRepository tradeRepository)
        {
            _stockRepository = stockRepository;
            _tradeRepository = tradeRepository;
        }

        public void StartMenu()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private bool MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select an option:");
            Console.WriteLine("1) List all stocks");
            Console.WriteLine("2) List all trades");
            Console.WriteLine("3) Record trade");
            Console.WriteLine("4) Calculate Dividend Yield and P/E Ratio");
            Console.WriteLine("5) Calculate Volume Weighted Stock Price");
            Console.WriteLine("6) Calculate GBCE All Share Index");
            Console.WriteLine("0) Exit");
            Console.Write("\r\nOption:");

            switch (Console.ReadLine())
            {
                case "1":
                    ListStockMarket();
                    return true;
                case "2":
                    ListAllTrades();
                    return true;
                case "3":
                    RecordTrade();
                    return true;

                case "4":
                    CalculateDivYieldAndPriceToEarningsRatio();
                    return true;

                case "5":
                    VolumeWeightedStockPrice();
                    return true;

                case "6":
                    CalculateGeometricMean();
                    return true;

                case "0":
                    return false;

                default:
                    return true;
            }
        }

        private void ListStockMarket()
        {
            ConsoleHelper.SeparatorLine();

            Console.WriteLine($"{"Symbol",ConsoleHelper.Padding} | {"Type",ConsoleHelper.Padding} | {"LastDividend",ConsoleHelper.Padding} | {"FixedDividend",ConsoleHelper.Padding} | {"ParValue",ConsoleHelper.Padding}");
            foreach (var stock in _stockRepository.GetAll())
            {
                Console.WriteLine(stock.ToString());
            }

            ConsoleHelper.SeparatorLine();
        }

        private void ListAllTrades()
        {
            ConsoleHelper.SeparatorLine();

            Console.WriteLine($"{"Timestamp",ConsoleHelper.Padding} | {"Stock Symbol",ConsoleHelper.Padding} | {"Operation",ConsoleHelper.Padding} | {"Price",ConsoleHelper.Padding} | {"Quantity",ConsoleHelper.Padding}");

            foreach (var trade in _tradeRepository.GetAll().OrderByDescending(x => x.Timestamp))
            {
                Console.WriteLine(trade.ToString());
            }

            ConsoleHelper.SeparatorLine();
        }

        private void RecordTrade()
        {
            ConsoleHelper.SeparatorLine();

            var stockFound = ReadStock();
            var stockOperation = ReadOperation();
            var price = ReadPrice();
            var quantity = ReadQuantity();

            Trade tradeCreated = null;
            
            if (stockOperation == TradeOperation.Buy)
            {
                tradeCreated = _tradeRepository.Buy(stockFound, price, quantity);
            }
            else if (stockOperation == TradeOperation.Sell)
            {
                tradeCreated = _tradeRepository.Sell(stockFound, price, quantity);
            }

            if (tradeCreated is not null)
            {
                Console.WriteLine($"New Trade recorded: \r\n{tradeCreated.ToSummary()}");
            } else
            {
                Console.WriteLine("No Trade transaction was created");
            }

            ConsoleHelper.SeparatorLine();
        }

        private void CalculateDivYieldAndPriceToEarningsRatio()
        {
            ConsoleHelper.SeparatorLine();

            var stockFound = ReadStock();
            var price = ReadPrice();

            var divYield = stockFound.DividendYield(price);
            var peRatio = stockFound.PriceToEarningsRatio(price);

            Console.WriteLine($"Dividend Yield: {divYield} ({divYield * 100}%)");

            Console.WriteLine($"P/E Ratio: {peRatio}");

            ConsoleHelper.SeparatorLine();
        }

        private void VolumeWeightedStockPrice()
        {
            ConsoleHelper.SeparatorLine();

            var stockFound = ReadStock();

            var result = _tradeRepository.GetVolumeWeightedStockPrice(stockFound);

            Console.WriteLine($"Volume Weighted Stock Price for {stockFound.Symbol}: {result}");

            ConsoleHelper.SeparatorLine();
        }

        private void CalculateGeometricMean()
        {
            ConsoleHelper.SeparatorLine();

            var gbceIndex = _tradeRepository.GetGBCEAllShareIndex();

            Console.WriteLine($"GBCE All Share Index: {gbceIndex}");

            ConsoleHelper.SeparatorLine();
        }

        private Stock ReadStock()
        {
            Stock stockFound = null;

            while (stockFound is null)
            {
                Console.Write("Input Stock Symbol: ");
                var stockSymbol = Console.ReadLine();

                stockFound = _stockRepository.GetBySymbol(stockSymbol);
                if (stockFound is null)
                    Console.WriteLine("Stock not found.");
            }

            return stockFound;
        }

        private TradeOperation ReadOperation()
        {
            var operation = string.Empty;
            while (string.IsNullOrEmpty(operation))
            {
                Console.Write("Input Buy or Sell: ");
                operation = Console.ReadLine();

                if (Enum.TryParse<TradeOperation>(operation, out var parsedOperation))
                {
                    return parsedOperation;
                }
                else
                {
                    Console.WriteLine("Invalid Operation informed");
                    operation = string.Empty;
                }
            }

            return TradeOperation.None;
        }

        private float ReadPrice()
        {
            var price = string.Empty;

            while (string.IsNullOrEmpty(price))
            {
                Console.Write("Input Price: ");
                price = Console.ReadLine();

                if (float.TryParse(price, out var parsedPrice))
                {
                    return parsedPrice;
                }
                else
                {
                    Console.WriteLine("Invalid price informed");
                    price = string.Empty;
                }
            }

            return 0;
        }

        private int ReadQuantity()
        {
            var quantity = string.Empty;

            while (string.IsNullOrEmpty(quantity))
            {
                Console.Write("Input Quantity: ");
                quantity = Console.ReadLine();

                if (int.TryParse(quantity, out var parsedQuantity))
                {
                    return parsedQuantity;
                }
                {
                    Console.WriteLine("Invalid quantity informed");
                    quantity = string.Empty;
                }
            }

            return 0;
        }
    }
}
