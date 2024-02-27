using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockPriceAPI.Data;
using StockPriceAPI.Implementations;
using StockPriceAPI.Interfaces;

namespace StockPriceAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BitcoinPriceContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("BitcoinPriceDatabase")));

            services.AddScoped<IBitcoinPriceFetcher, BitstampPriceFetcher>();
            services.AddScoped<IBitcoinPriceFetcher, BitfinexPriceFetcher>();
        }
    }
}
