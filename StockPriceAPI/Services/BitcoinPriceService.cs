using Microsoft.EntityFrameworkCore;
using StockPriceAPI.Data;
using StockPriceAPI.Implementations;
using StockPriceAPI.Interfaces;
using StockPriceAPI.Models;

namespace StockPriceAPI.Services
{
    public class BitcoinPriceService
    {
        private readonly BitcoinPriceContext _context;
        private readonly BitcoinPriceFetcherFactory _fetcherFactory;

        public BitcoinPriceService(
            BitcoinPriceContext context,
            BitcoinPriceFetcherFactory fetcherFactory
            )
        {
            _context = context;
            _fetcherFactory = fetcherFactory;
        }

        public async Task<BitcoinPrice> GetPriceAndUpdateAsync(string source)
        {
            var fetcher = _fetcherFactory.GetPriceFetcher(source);

            BitcoinPrice lastPrice = await fetcher.FetchAsync();
            _context.BitcoinPrices.Add(lastPrice);
            await _context.SaveChangesAsync();

            return lastPrice;

        }
        public async Task<List<BitcoinPrice>> GetHistory()
        {
            return await _context.BitcoinPrices.OrderByDescending(p => p.TimeStamp).ToListAsync<BitcoinPrice>();
        }

        public IEnumerable<string> GetAllSources()
        {
            return _fetcherFactory.GetAllSources();
        }
    }
}
