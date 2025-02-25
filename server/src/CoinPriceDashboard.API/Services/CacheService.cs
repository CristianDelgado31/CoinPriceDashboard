using Microsoft.Extensions.Caching.Memory;
using StockPriceDashboard.API.Models;

namespace StockPriceDashboard.API.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void AddDefaultCoins(List<CoinData> coins)
        {
            _cache.Set("default_coins", coins);
        }

        public IReadOnlyCollection<CoinData> GetDefaultCoins()
        {
            return _cache.GetOrCreate("default_coins", entry => new List<CoinData>())!;
        }

        public void AddAllCoins(List<CoinData> coins)
        {
            _cache.Set("all_coins", coins);
        }

        public IReadOnlyCollection<CoinData> GetAllCoins()
        {
            return _cache.GetOrCreate("all_coins", entry => new List<CoinData>())!;
        }


        public Task AddGroup(string groupName)
        {

            var listInCache = (List<string>?)_cache.Get("groups");

            if (listInCache == null)
            {
                listInCache = new List<string> { groupName };
            } else
            {
                if (!listInCache.Contains(groupName))
                {
                    listInCache.Add(groupName);
                }
            }

            _cache.Set("groups", listInCache);
            return Task.CompletedTask;

        }

        public IReadOnlyCollection<string>? GetGroups()
        {
            return (IReadOnlyCollection<string>?)_cache.Get("groups");
        }
    }
}
