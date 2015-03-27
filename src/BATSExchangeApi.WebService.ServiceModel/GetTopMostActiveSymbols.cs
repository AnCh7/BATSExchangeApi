using System.Collections.Generic;
using System.Runtime.Serialization;

using BATSExchangeApi.Library.Models;

using ServiceStack.ServiceHost;

namespace BATSExchangeApi.WebService.ServiceModel
{
    [Route("/topMostActiveSymbols", "GET")]
    [Route("/topMostActiveSymbols/{Count}/{Market}", "GET")]
    public class GetTopMostActiveSymbols : IReturn<GetTopMostActiveSymbolsResponse>
    {
        [ApiMember(Name = "Count", ParameterType = "path", DataType = "string", IsRequired = false)]
        public int? Count { get; set; }

        [ApiMember(Name = "Market", ParameterType = "path", DataType = "string", IsRequired = false)]
        public string Market { get; set; }
    }

    [DataContract]
    public class GetTopMostActiveSymbolsResponse : BaseReponse
    {
        [DataMember(Name = "data")]
        public List<MarketSymbol> Data { get; set; }
    }
}
