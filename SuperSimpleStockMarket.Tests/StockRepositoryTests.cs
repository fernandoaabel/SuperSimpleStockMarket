using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using SuperSimpleStockMarket.Interfaces;
using Xunit;

namespace SuperSimpleStockMarket.Tests
{
    public class StockRepositoryTests : BaseTest
    {
        IStockRepository stockRepository;

        public StockRepositoryTests() : base()
        {
            stockRepository = serviceProvider.GetService<IStockRepository>();
        }

        [Fact]
        public void GetAll_ShouldReturnStocks()
        {
            // Act
            var response = stockRepository.GetAll();

            // Assert
            response.Count.ShouldBeGreaterThan(0);
        }

        [Theory]
        [InlineData("TEA")]
        [InlineData("JOE")]
        [InlineData("POP")]
        [InlineData("ALE")]
        [InlineData("GIN")]
        public void GetBySymbol_ShouldReturnStocks(string stockSymbol)
        {
            // Act
            var response = stockRepository.GetBySymbol(stockSymbol);

            // Assert
            response.ShouldNotBeNull();
        }

        [Fact]
        public void GetBySymbol_ShouldReturnNull()
        {
            // Act
            var response = stockRepository.GetBySymbol("unexistent stock");

            // Assert
            response.ShouldBeNull();
        }
    }
}
