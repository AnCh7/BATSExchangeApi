using System;

namespace BATSExchangeApi.Library.Enums
{
    public enum BATSMarkets
    {
        Bzx,
        Byx,
        Edgx,
        Edga
    }

    public static class OrderStatusExtensions
    {
        public static BATSMarkets ToBATSMarkets(this string value)
        {
            if (String.Compare("Bzx", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return BATSMarkets.Bzx;
            }

            if (String.Compare("Byx", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return BATSMarkets.Byx;
            }

            if (String.Compare("Edgx", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return BATSMarkets.Edgx;
            }

            if (String.Compare("Edga", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return BATSMarkets.Edga;
            }

            return BATSMarkets.Bzx;
        }
    }
}
