using Microsoft.EntityFrameworkCore;
using StockPriceAPI.Models;

namespace StockPriceAPI.Data
{
    public class BitcoinPriceContext : DbContext
    {
        public DbSet<BitcoinPrice> BitcoinPrices { get; set; }
        public BitcoinPriceContext(DbContextOptions<BitcoinPriceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitcoinPrice>().ToTable("BitcoinPrice");
        }
    }
}
