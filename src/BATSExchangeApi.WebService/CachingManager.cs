using System;

using BATSExchangeApi.WebService.ServiceModel;

using ServiceStack.CacheAccess;

namespace BATSExchangeApi.WebService
{
    public class CachingManager
    {
        private readonly ICacheClient _client;

        public CachingManager(ICacheClient client)
        {
            _client = client;
        }

        public GetTopMostActiveSymbolsResponse GetTopMostActiveSymbols(string key)
        {
            return _client.Get<GetTopMostActiveSymbolsResponse>(key);
        }

        public void Save(string key, GetTopMostActiveSymbolsResponse response)
        {
            var cachedData = _client.Get<GetTopMostActiveSymbolsResponse>(key);
            if (cachedData == null)
            {
                var expireInTimespan = new TimeSpan(0, 0, 0, 2);
                _client.Add(key, response, expireInTimespan);
            }
        }

        public GetOrderBookResponse GetOrderBook(string key)
        {
            return _client.Get<GetOrderBookResponse>(key);
        }

        public void Save(string key, GetOrderBookResponse data)
        {
            var cachedData = _client.Get<GetOrderBookResponse>(key);
            if (cachedData == null)
            {
                var expireInTimespan = new TimeSpan(0, 0, 0, 2);
                _client.Add(key, data, expireInTimespan);
            }
        }
    }
}
