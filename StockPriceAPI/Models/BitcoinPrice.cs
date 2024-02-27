namespace StockPriceAPI.Models
{
    public class BitcoinPrice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
    }
}
