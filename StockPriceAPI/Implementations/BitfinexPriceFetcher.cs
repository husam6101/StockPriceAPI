using Newtonsoft.Json;
using StockPriceAPI.Interfaces;
using StockPriceAPI.Models;

namespace StockPriceAPI.Implementations
{
    public class BitfinexPriceFetcher : IBitcoinPriceFetcher
    {
        public async Task<BitcoinPrice> FetchAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("https://api.bitfinex.com/v1/pubticker/btcusd");
                var data = JsonConvert.DeserializeObject<dynamic>(response);
                var price = Convert.ToDecimal(data.last_price);
                var timestamp = DateTimeOffset.FromUnixTimeSeconds((long)Math.Round(Convert.ToDouble(data.timestamp))).DateTime;

                return new BitcoinPrice
                {
                    Price = price,
                    TimeStamp = timestamp,
                    Source = "Bitfinex"
                };
            }
        }

    }
}
