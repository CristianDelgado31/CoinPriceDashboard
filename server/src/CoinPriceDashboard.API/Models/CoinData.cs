using Newtonsoft.Json;

namespace StockPriceDashboard.API.Models
{
    public class CoinData
    {
        public required string Id { get; set; }
        public required string Symbol { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        [JsonProperty("current_price")]
        public required string CurrentPrice { get; set; }
        [JsonProperty("market_cap")]
        public required string MarketCap { get; set; }
    }
}
