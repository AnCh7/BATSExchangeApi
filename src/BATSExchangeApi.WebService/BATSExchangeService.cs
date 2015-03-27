using System;

using Autofac;

using BATSExchangeApi.Library.DataProvider;
using BATSExchangeApi.Library.Enums;
using BATSExchangeApi.WebService.Resolver;
using BATSExchangeApi.WebService.ServiceModel;

using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Cors;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.Text;

namespace BATSExchangeApi.WebService
{
    [EnableCors]
    public sealed class BATSExchangeService : Service
    {
        private readonly CachingManager _cachingManager;
        private readonly IBATSProvider _dataProvider;

        public BATSExchangeService()
        {
            _cachingManager = new CachingManager(Cache);
            _dataProvider = DependencyContainer.Instance.Resolve<IBATSProvider>();
        }

        public object Get(GetTopMostActiveSymbols request)
        {
            if (!request.Count.HasValue || request.Count <= 0)
            {
                request.Count = 25;
            }

            var response = new GetTopMostActiveSymbolsResponse();

            try
            {
                var cached = _cachingManager.GetTopMostActiveSymbols(request.ToJson());
                if (cached != null)
                {
                    return cached;
                }

                var result = _dataProvider.GetTopMostActiveSymbols(request.Market.ToBATSMarkets(), request.Count.Value);
                if (result.Success)
                {
                    response.Success = true;
                    response.Data = result.Data;
                    _cachingManager.Save(request.ToJson(), response);
                }
                else
                {
                    response.ResponseStatus = new ResponseStatus(string.Empty, result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                var status = new ResponseStatus {Message = ex.Message, ErrorCode = ex.Source, StackTrace = ex.StackTrace};
                response.ResponseStatus = status;
            }

            return response;
        }

        public object Get(GetOrderBook request)
        {
            if (string.IsNullOrEmpty(request.Symbol))
            {
                throw new ServiceResponseException("Unknown request. Missing parameters.");
            }

            var response = new GetOrderBookResponse();

            try
            {
                var cached = _cachingManager.GetOrderBook(request.ToJson());
                if (cached != null)
                {
                    return cached;
                }

                var result = _dataProvider.GetOrderBook(request.Symbol, request.Market.ToBATSMarkets());
                if (result.Success)
                {
                    response.Success = true;
                    response.Data = result.Data;
                    _cachingManager.Save(request.ToJson(), response);
                }
                else
                {
                    response.ResponseStatus = new ResponseStatus(string.Empty, result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                var status = new ResponseStatus {Message = ex.Message, ErrorCode = ex.Source, StackTrace = ex.StackTrace};
                response.ResponseStatus = status;
            }

            return response;
        }
    }
}
