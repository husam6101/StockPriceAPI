using StockPriceAPI.Interfaces;
using StockPriceAPI.Models;
using Newtonsoft.Json;

namespace StockPriceAPI.Implementations
{
    public class BitstampPriceFetcher : IBitcoinPriceFetcher
    {
        public async Task<BitcoinPrice> FetchAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("https://www.bitstamp.net/api/v2/ticker/btcusd/");
                var data = JsonConvert.DeserializeObject<dynamic>(response);
                var price = Convert.ToDecimal(data.last);
                var timestamp = DateTimeOffset.FromUnixTimeSeconds((long)data.timestamp).DateTime;

                return new BitcoinPrice
                {
                    Price = price,
                    TimeStamp = timestamp,
                    Source = "Bitstamp"
                };
            }
        }

    }
}
