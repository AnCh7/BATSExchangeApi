using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BATSExchangeApi.Library.Models
{
    [DataContract(Name = "RootObject")]
    public class OrderBookObject
    {
        [DataMember(Name = "reload")]
        public int reload { get; set; }

        [DataMember(Name = "data")]
        public OrderBookData data { get; set; }

        [DataMember(Name = "success")]
        public bool success { get; set; }
    }

    [DataContract(Name = "data")]
    public class OrderBookData
    {
        [DataMember(Name = "volume")]
        public int volume { get; set; }

        [DataMember(Name = "tick_type")]
        public string tick_type { get; set; }

        [DataMember(Name = "last")]
        public double last { get; set; }

        [DataMember(Name = "asks")]
        public List<List<string>> asks { get; set; }

        [DataMember(Name = "auction")]
        public bool auction { get; set; }

        [DataMember(Name = "timestamp")]
        public string timestamp { get; set; }

        [DataMember(Name = "symbol")]
        public string symbol { get; set; }

        [DataMember(Name = "trades")]
        public List<List<string>> trades { get; set; }

        [DataMember(Name = "bids")]
        public List<List<string>> bids { get; set; }

        [DataMember(Name = "orders")]
        public int orders { get; set; }

        [DataMember(Name = "high")]
        public double high { get; set; }

        [DataMember(Name = "low")]
        public double low { get; set; }

        [DataMember(Name = "prev")]
        public double prev { get; set; }

        [DataMember(Name = "open")]
        public double open { get; set; }

        [DataMember(Name = "company")]
        public string company { get; set; }

        [DataMember(Name = "change")]
        public double change { get; set; }
    }

    [DataContract(Name = "orderbook")]
    public class OrderBook
    {
        [DataMember(Name = "info")]
        public SymbolInfo Info { get; set; }

        [DataMember(Name = "trades")]
        public List<TradesEntry> Trades { get; set; }

        [DataMember(Name = "bids")]
        public List<OrderBookEntry> Bids { get; set; }

        [DataMember(Name = "asks")]
        public List<OrderBookEntry> Asks { get; set; }
    }

    [DataContract(Name = "orderbookentry")]
    public class OrderBookEntry
    {
        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "shares")]
        public int Shares { get; set; }
    }

    [DataContract(Name = "tradesentry")]
    public class TradesEntry
    {
        [DataMember(Name = "datetime")]
        public DateTime Datetime { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "shares")]
        public int Shares { get; set; }
    }

    [DataContract(Name = "symbolinfo")]
    public class SymbolInfo
    {
        [DataMember(Name = "company")]
        public string Company { get; set; }

        [DataMember(Name = "lastupdated")]
        public DateTime LastUpdated { get; set; }

        [DataMember(Name = "orderscount")]
        public int OrdersCount { get; set; }

        [DataMember(Name = "open")]
        public decimal Open { get; set; }

        [DataMember(Name = "high")]
        public decimal High { get; set; }

        [DataMember(Name = "low")]
        public decimal Low { get; set; }

        [DataMember(Name = "close")]
        public decimal Close { get; set; }

        [DataMember(Name = "prevclose")]
        public decimal PrevClose { get; set; }

        [DataMember(Name = "volume")]
        public int Volume { get; set; }

        [DataMember(Name = "change")]
        public decimal Change { get; set; }
    }
}
