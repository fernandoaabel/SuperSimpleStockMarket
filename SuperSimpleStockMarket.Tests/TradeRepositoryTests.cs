using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using SuperSimpleStockMarket.Interfaces;
using SuperSimpleStockMarket.Models;
using Xunit;

namespace SuperSimpleStockMarket.Tests
{
    public class TradeRepositoryTests : BaseTest
    {
        ITradeRepository tradeRepository;

        public TradeRepositoryTests() : base()
        {
            tradeRepository = serviceProvider.GetService<ITradeRepository>();
        }

        [Fact]
        public void GetAll_ShouldReturnTrades()
        {
            // Act
            var response = tradeRepository.GetAll();

            // Assert
            response.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void GetRecentTradesPerStock_ShouldReturnRecentTrades()
        {
            // Arrange
            var stock = new CommonStock() { Symbol = "POP", LastDividend = 8, ParValue = 100 };

            // Act
            var response = tradeRepository.GetRecentTradesPerStock(stock, 15);

            // Assert
            response.Count.ShouldBeGreaterThan(0);
        }

        [Theory]
        [InlineData("TEA")]
        [InlineData("JOE")]
        [InlineData("POP")]
        [InlineData("ALE")]
        [InlineData("GIN")]
        public void GetByStockSymbol_ShouldReturnTrades(string stockSymbol)
        {
            // Act
            var response = tradeRepository.GetByStockSymbol(stockSymbol);

            // Assert
            response.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void GetByStockSymbol_ShouldReturnZero()
        {
            // Act
            var response = tradeRepository.GetByStockSymbol("unexistent stock");

            // Assert
            response.Count.ShouldBe(0);
        }

        [Fact]
        public void Buy_ShouldAddNewTrade()
        {
            // Arrange
            Stock stock = new CommonStock() { Symbol = "POP", LastDividend = 8, ParValue = 100 };
            float price = 100.0f;
            int quantity = 9;

            // Act
            var response = tradeRepository.Buy(stock, price, quantity);

            // Assert
            response.ShouldNotBeNull();
            response.StockSymbol.ShouldBe(stock.Symbol);
            response.Operation.ShouldBe(Models.Enum.TradeOperation.Buy);
            response.Price.ShouldBe(price);
            response.Quantity.ShouldBe(quantity);
            response.Timestamp.ToString().ShouldNotBeNull();
        }

        [Fact]
        public void Sell_ShouldAddNewTrade()
        {
            // Arrange
            Stock stock = new CommonStock() { Symbol = "POP", LastDividend = 8, ParValue = 100 };
            float price = 100.0f;
            int quantity = 9;

            // Act
            var response = tradeRepository.Sell(stock, price, quantity);

            // Assert
            response.ShouldNotBeNull();
            response.StockSymbol.ShouldBe(stock.Symbol);
            response.Operation.ShouldBe(Models.Enum.TradeOperation.Sell);
            response.Price.ShouldBe(price);
            response.Quantity.ShouldBe(quantity);
            response.Timestamp.ToString().ShouldNotBeNull();
        }

        [Fact]
        public void GetVolumeWeightedStockPrice_ShouldCalculateCorrectly()
        {
            // Arrange
            var stock = new CommonStock() { Symbol = "ABE" };
            tradeRepository.Buy(stock, 10.0f, 101);
            tradeRepository.Buy(stock, 20.0f, 201);

            // Act
            var response = tradeRepository.GetVolumeWeightedStockPrice(stock);

            // Arrange
            response.ShouldBe(16.655628f);
        }

        [Fact]
        public void GetVolumeWeightedStockPrice_ShouldReturnZeroWhenNoTrades()
        {
            // Arrange
            var stock = new CommonStock() { Symbol = "TEST" };

            // Act
            var response = tradeRepository.GetVolumeWeightedStockPrice(stock);

            // Arrange
            response.ShouldBe(0);
        }

        [Fact]
        public void GetGBCEAllShareIndex_ShouldReturnCorrectIndex()
        {
            // Act
            var response = (int) tradeRepository.GetGBCEAllShareIndex();

            // Arrange
            response.ShouldBe(55);
        }
    }
}
