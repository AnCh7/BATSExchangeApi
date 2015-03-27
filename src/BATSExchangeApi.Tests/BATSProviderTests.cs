using System.Linq;

using Autofac;

using BATSExchangeApi.Library.DataProvider;
using BATSExchangeApi.Library.Enums;
using BATSExchangeApi.WebService.Resolver;

using NUnit.Framework;

namespace BATSExchangeApi.Tests
{
    internal class BATSProviderTests
    {
        private readonly IBATSProvider _dataProvider;

        public BATSProviderTests()
        {
            _dataProvider = DependencyContainer.Instance.Resolve<IBATSProvider>();
        }

        [Test]
        public void Test_GetTopMostActiveSymbols()
        {
            // Arrange
            const BATSMarkets market = BATSMarkets.Bzx;
            const int count = 25;

            // Act
            var result = _dataProvider.GetTopMostActiveSymbols(market, count);

            // Assert
            Assert.True(result.Success);
            Assert.True(result.Data.Any());
        }

        [Test]
        public void Test_GetOrderBook()
        {
            // Arrange
            const BATSMarkets market = BATSMarkets.Bzx;
            const string symbol = "AAPL";

            // Act
            var result = _dataProvider.GetOrderBook(symbol, market);

            // Assert
            Assert.True(result.Success);
            Assert.True(result.Data.Asks.Any());
            Assert.True(result.Data.Bids.Any());
            Assert.True(result.Data.Trades.Any());
        }
    }
}
