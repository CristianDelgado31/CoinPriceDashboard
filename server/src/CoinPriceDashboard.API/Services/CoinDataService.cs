using CoinPriceDashboard.API.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace StockPriceDashboard.API.Services
{
    public class CoinDataService : BackgroundService
    {
        private readonly CoinClient _coinClient;
        private readonly CacheService _cacheService;
        private readonly IHubContext<CoinHub> _hubContext;

        public CoinDataService(CoinClient coinClient, CacheService cacheService, IHubContext<CoinHub> hubContext)
        {
            _coinClient = coinClient;
            _cacheService = cacheService;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Loading coin data");
            await UpdateCoinsPrices();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
                Console.WriteLine("Update coin prices");
                await UpdateCoinsPrices();
            }
        }

        private async Task UpdateCoinsPrices()
        {
            var coins = await _coinClient.GetData();
            _cacheService.AddAllCoins(coins);

            var saveDataInCache = coins.Take(5).ToList();

            _cacheService.AddDefaultCoins(saveDataInCache);

            await _hubContext.Clients.All.SendAsync("ReceiveData", saveDataInCache);

            var groups = _cacheService.GetGroups();

            if (groups != null)
            {
                var coinsDict = coins.ToDictionary(coin => coin.Id);

                foreach (var group in groups)
                {
                    if (coinsDict.TryGetValue(group, out var coin))
                    {
                        await _hubContext.Clients.Group(group).SendAsync("ReceiveDataByGroup", coin);
                    }
                }
            }
        }

    }
}
