using System.Collections.Generic;

using BATSExchangeApi.Library.Enums;
using BATSExchangeApi.Library.Models;
using BATSExchangeApi.Library.Models.Common;

namespace BATSExchangeApi.Library.DataProvider
{
    public interface IBATSProvider
    {
        OperationResult<List<MarketSymbol>> GetTopMostActiveSymbols(BATSMarkets market, int value);

        OperationResult<OrderBook> GetOrderBook(string symbol, BATSMarkets market);
    }
}
