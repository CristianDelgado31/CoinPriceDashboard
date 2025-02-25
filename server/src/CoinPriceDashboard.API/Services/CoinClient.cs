using StockPriceDashboard.API.Models;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace StockPriceDashboard.API.Services
{
    public class CoinClient
    {
        private readonly HttpClient _httpClient;

        public CoinClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CoinData>> GetData()
        {
            try
            {
                var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener los datos de CoinGecko");
                }

                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CoinData>>(content)!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


    }
}
