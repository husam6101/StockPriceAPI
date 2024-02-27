using StockPriceAPI.Interfaces;

namespace StockPriceAPI.Implementations
{
    public class BitcoinPriceFetcherFactory
    {
        public IBitcoinPriceFetcher GetPriceFetcher(string source)
        {
            switch (source.ToLower())
            {
                case "bitfinex":
                    return new BitfinexPriceFetcher();
                case "bitstamp":
                    return new BitstampPriceFetcher();
                default:
                    throw new ArgumentException("Invalid source", nameof(source));
            }
        }

        public IEnumerable<string> GetAllSources()
        {
            return new List<string> { "bitfinex", "bitstamp" };
        }
    }
}
