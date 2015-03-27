using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BATSExchangeApi.Library.Models
{
    [DataContract(Name = "RootObject")]
    public class TopMostActiveSymbolsObject
    {
        [DataMember(Name = "mo")]
        public bool mo { get; set; }

        [DataMember(Name = "data")]
        public TopMostActiveSymbolsData data { get; set; }

        [DataMember(Name = "ts")]
        public string ts { get; set; }

        [DataMember(Name = "success")]
        public string success { get; set; }

        [DataMember(Name = "ttl")]
        public int ttl { get; set; }
    }

    [DataContract(Name = "data")]
    public class TopMostActiveSymbolsData
    {
        [DataMember(Name = "bzx")]
        public List<List<string>> MarketSymbols { get; set; }
    }

    [DataContract(Name = "marketsymbol")]
    public class MarketSymbol
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "shares")]
        public int Shares { get; set; }

        [DataMember(Name = "sharesinsidebid")]
        public int SharesInsideBid { get; set; }

        [DataMember(Name = "priceinsidebid")]
        public decimal PriceInsideBid { get; set; }

        [DataMember(Name = "priceinsideask")]
        public decimal PriceInsideAsk { get; set; }

        [DataMember(Name = "sharesinsideask")]
        public int SharesInsideAsk { get; set; }
    }
}
