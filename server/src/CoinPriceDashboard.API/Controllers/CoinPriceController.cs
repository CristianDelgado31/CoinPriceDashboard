using Microsoft.AspNetCore.Mvc;
using StockPriceDashboard.API.Services;

namespace StockPriceDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinPriceController : ControllerBase
    {
        private readonly CacheService _cacheService;

        public CoinPriceController(CacheService cacheService)
        {
            _cacheService = cacheService;
        }


        [HttpGet]
        public IActionResult CoinList()
        {
            var list = _cacheService.GetDefaultCoins();
            return Ok(list);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> FindCoin([FromRoute] string name)
        {
            var normalizedData = name.ToLower();
            var list = _cacheService.GetDefaultCoins();
            var coin = list.FirstOrDefault(x => x.Id == normalizedData);

            if (coin == null)
            {
                var searchInClientList = _cacheService.GetAllCoins();
                coin = searchInClientList.FirstOrDefault(x => x.Id == normalizedData);

                if(coin == null)
                    return NotFound();

                await _cacheService.AddGroup(name);
            }

            return Ok(coin);
        }

    }
}
