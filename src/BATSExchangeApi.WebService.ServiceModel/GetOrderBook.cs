using System.Runtime.Serialization;

using BATSExchangeApi.Library.Models;

using ServiceStack.ServiceHost;

namespace BATSExchangeApi.WebService.ServiceModel
{
    [Route("/orderBook/{Symbol}", "GET")]
    [Route("/orderBook/{Symbol}/{Market}", "GET")]
    public class GetOrderBook : IReturn<GetOrderBookResponse>
    {
        [ApiMember(Name = "Symbol", ParameterType = "path", DataType = "string", IsRequired = true)]
        public string Symbol { get; set; }

        [ApiMember(Name = "Market", ParameterType = "path", DataType = "string", IsRequired = false)]
        public string Market { get; set; }
    }

    [DataContract]
    public class GetOrderBookResponse : BaseReponse
    {
        [DataMember(Name = "data")]
        public OrderBook Data { get; set; }
    }
}
