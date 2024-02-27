using Microsoft.AspNetCore.Mvc;
using StockPriceAPI.Models;
using StockPriceAPI.Services;

namespace StockPriceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BitcoinPriceController : ControllerBase
    {
        private readonly ILogger<BitcoinPriceController> _logger;
        private readonly BitcoinPriceService _bitcoinPriceService;

        public BitcoinPriceController(
            ILogger<BitcoinPriceController> logger,
            BitcoinPriceService bitcoinPriceService)
        {
            _logger = logger;
            _bitcoinPriceService = bitcoinPriceService;
        }

        [HttpGet(Name = "GetBitcoinPrice")]
        public async Task<ActionResult<BitcoinPrice>> Get([FromQuery] string source = "bitfinex")
        {
            try
            {
                BitcoinPrice price = await _bitcoinPriceService.GetPriceAndUpdateAsync(source);
                return Ok(price);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching bitcoin price");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("sources")]
        public ActionResult<IEnumerable<string>> GetAvailableSources()
        {
            var sources = _bitcoinPriceService.GetAllSources();
            return Ok(sources);
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<BitcoinPrice>>> GetAllPrices()
        {
            try
            {
                var prices = await _bitcoinPriceService.GetHistory();
                return Ok(prices);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all bitcoin prices");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
