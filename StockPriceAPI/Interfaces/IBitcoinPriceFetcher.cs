using StockPriceAPI.Models;

namespace StockPriceAPI.Interfaces
{
    public interface IBitcoinPriceFetcher
    {
        Task<BitcoinPrice> FetchAsync();
    }
}
