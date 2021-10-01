using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using SuperSimpleStockMarket.Interfaces;
using Xunit;

namespace SuperSimpleStockMarket.Tests
{
    public class StockTests : BaseTest
    {
        IStockRepository stockRepository;
        public StockTests() : base()
        {
            stockRepository = serviceProvider.GetService<IStockRepository>();
        }

        [Theory]
        [InlineData("JOE", 200f, 0.065f)]
        [InlineData("JOE", 0, 0)]
        public void CommonStock_DividendYield(string stockSymbol, float price, float expectedDivYield)
        {
            // Arrange
            var stock = stockRepository.GetBySymbol(stockSymbol);

            // Act
            var response = stock.DividendYield(price);

            // Arrange
            response.ShouldBe(expectedDivYield);
        }

        [Theory]
        [InlineData("GIN", 100f, 2f)]
        [InlineData("GIN", 0, 0)]
        public void PreferredStock_DividendYield(string stockSymbol, float price, float expectedDivYield)
        {
            // Arrange
            var stock = stockRepository.GetBySymbol(stockSymbol);
            
            // Act
            var response = stock.DividendYield(price);

            // Arrange
            response.ShouldBe(expectedDivYield);
        }

        [Theory]
        [InlineData("TEA", 120f, 0f)]
        [InlineData("POP", 150f, 18.75f)]
        [InlineData("GIN", 100f, 12.5f)]
        [InlineData("GIN", 0, 0)]
        public void Stock_PriceToEarningsRatio(string stockSymbol, float price, float expectedValue)
        {
            // Arrange
            var stock = stockRepository.GetBySymbol(stockSymbol);

            // Act
            var response = stock.PriceToEarningsRatio(price);

            // Arrange
            response.ShouldBe(expectedValue);
        }
    }
}
