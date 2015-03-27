using System;
using System.Collections.Generic;
using System.Linq;

using BATSExchangeApi.Library.Enums;
using BATSExchangeApi.Library.Logging;
using BATSExchangeApi.Library.Models;
using BATSExchangeApi.Library.Models.Common;

using RestSharp;

using ServiceStack.Text;

namespace BATSExchangeApi.Library.DataProvider
{
    public class BATSProvider : IBATSProvider
    {
        private readonly ILogWrapper _logger;

        public BATSProvider(ILogWrapper logger)
        {
            _logger = logger;
        }

        public OperationResult<List<MarketSymbol>> GetTopMostActiveSymbols(BATSMarkets market, int count)
        {
            try
            {
                var client = new RestClient("http://www.batstrading.com/most_active/data/");
                var restRequest = new RestRequest(count + "/", Method.GET);
                restRequest.AddParameter("mkts", market.ToString().ToLowerInvariant());

                var response = client.Execute(restRequest);
                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    _logger.Error(response.ErrorException);
                    return new FailedOperationResult<List<MarketSymbol>>(response.ErrorMessage);
                }

                var result = response.Content.FromJson<TopMostActiveSymbolsObject>();
                var symbols = from marketSymbols in result.data.MarketSymbols
                              select (new MarketSymbol
                              {
                                  Name = marketSymbols[0],
                                  Shares = Int32.Parse(marketSymbols[1]),
                                  SharesInsideBid = Int32.Parse(marketSymbols[2]),
                                  PriceInsideBid = Decimal.Parse(marketSymbols[3]),
                                  PriceInsideAsk = Decimal.Parse(marketSymbols[4]),
                                  SharesInsideAsk = Int32.Parse(marketSymbols[5])
                              });

                return new SuccessOperationResult<List<MarketSymbol>>(symbols.ToList());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new FailedOperationResult<List<MarketSymbol>>(ex.Message);
            }
        }

        public OperationResult<OrderBook> GetOrderBook(string symbol, BATSMarkets market)
        {
            try
            {
                var client = new RestClient("http://www.batstrading.com/json/");
                var restRequest = new RestRequest(market.ToString().ToLowerInvariant() +
                                                  "/book/" +
                                                  symbol.ToUpperInvariant(),
                                                  Method.GET);

                var response = client.Execute(restRequest);
                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    _logger.Error(response.ErrorException);
                    return new FailedOperationResult<OrderBook>(response.ErrorMessage);
                }

                var result = response.Content.FromJson<OrderBookObject>();

                var orderbook = new OrderBook
                {
                    Info = new SymbolInfo
                    {
                        Company = result.data.company,
                        LastUpdated = Convert.ToDateTime(result.data.timestamp),
                        OrdersCount = result.data.orders,
                        Open = new decimal(result.data.open),
                        High = new decimal(result.data.high),
                        Low = new decimal(result.data.low),
                        Close = new decimal(result.data.last),
                        PrevClose = (decimal)result.data.prev,
                        Volume = result.data.volume,
                        Change = (decimal)result.data.change
                    }
                };

                var asks = result.data.asks.Select(ask => new OrderBookEntry
                {
                    Shares = Convert.ToInt32(ask[0]),
                    Price = Convert.ToDecimal(ask[1])
                }).ToList();

                var bids = result.data.bids.Select(bid => new OrderBookEntry
                {
                    Shares = Convert.ToInt32(bid[0]),
                    Price = Convert.ToDecimal(bid[1])
                }).ToList();

                var trades = result.data.trades.Select(trade => new TradesEntry
                {
                    Datetime = Convert.ToDateTime(trade[0]),
                    Shares = Convert.ToInt32(trade[1]),
                    Price = Convert.ToDecimal(trade[2])
                }).ToList();

                orderbook.Asks = asks;
                orderbook.Bids = bids;
                orderbook.Trades = trades;

                return new SuccessOperationResult<OrderBook>(orderbook);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new FailedOperationResult<OrderBook>(ex.Message);
            }
        }
    }
}
