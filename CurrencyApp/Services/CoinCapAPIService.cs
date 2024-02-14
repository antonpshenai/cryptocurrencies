using CurrencyApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyApp.Services
{
    public class CoinCapAPIService
    {
        private const string BaseUrl = "https://api.coincap.io/v2/";


        public List<CurrencyModel> GetTopAssets(int limit = 10)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}assets?limit={limit}";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ApiResponse>(data);
                    return result?.Data;
                }
                else
                {
                    return null;
                }
            }
        }

        //async for loading quickly all currency + 20 paral
        public async Task<List<CurrencyModel>> GetAssetsAsync()
        {
            const int pageSize = 100;
            int offset = 0;
            List<CurrencyModel> allAssets = new List<CurrencyModel>();

            using (HttpClient client = new HttpClient())
            {
                List<Task<ApiResponse>> apiRequests = new List<Task<ApiResponse>>();

                do
                {
                    string apiUrl = $"{BaseUrl}assets?limit={pageSize}&offset={offset}";
                    apiRequests.Add(GetApiResponseAsync(client, apiUrl));

                    offset += pageSize;
                } while (apiRequests.Count < 20);

                while (apiRequests.Count > 0)
                {
                    Task<ApiResponse> completedTask = await Task.WhenAny(apiRequests);
                    apiRequests.Remove(completedTask);

                    var result = await completedTask;

                    if (result?.Data == null || result.Data.Count == 0)
                        break;

                    allAssets.AddRange(result.Data);
                }
            }

            return allAssets;
        }

        private async Task<ApiResponse> GetApiResponseAsync(HttpClient client, string apiUrl)
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse>(data);
            }
            else
            {
                return null;
            }
        }

        public List<ExchangesModel> GetExchangesDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}exchanges";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ApiResponseExchanges>(data);
                    return result.Data;
                }
                else
                {
                    return null;
                }
            }
        }

        public CurrencyModel GetCoinDetails(string id)
        {   
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}assets/{id}";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ApiResponseCoin>(data);
                    return result.Data;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<MarketModel> GetCoinMarkets(string coinId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{BaseUrl}assets/{coinId}/markets";

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    CoinMarketsResponse marketsResponse = JsonConvert.DeserializeObject<CoinMarketsResponse>(json);

                    if (marketsResponse != null && marketsResponse.Data != null)
                    {
                        return marketsResponse.Data;
                    }
                }

                return null;
            }
        }

        public List<CoinHistoryDataModel> GetCoinHistoricalData(string coinId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{BaseUrl}assets/{coinId}/history?interval=d1";

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    var historyResponse = JsonConvert.DeserializeObject<CoinHistoryResponse>(json);

                    if (historyResponse != null && historyResponse.Data != null)
                    {
                        return historyResponse.Data;
                    }
                }

                return null;
            }
        }

        public async Task<List<RateModel>> GetRatesAsync()
        {
            const int pageSize = 100;
            int offset = 0;
            List<RateModel> allAssets = new List<RateModel>();

            using (HttpClient client = new HttpClient())
            {
                List<Task<RateResponse>> apiRequests = new List<Task<RateResponse>>();

                do
                {
                    string apiUrl = $"{BaseUrl}rates?limit={pageSize}&offset={offset}";
                    apiRequests.Add(GetApiRateResponseAsync(client, apiUrl));

                    offset += pageSize;
                } while (apiRequests.Count < 20);

                while (apiRequests.Count > 0)
                {
                    Task<RateResponse> completedTask = await Task.WhenAny(apiRequests);
                    apiRequests.Remove(completedTask);

                    var result = await completedTask;

                    if (result?.Data == null || result.Data.Count == 0)
                        break;

                    allAssets.AddRange(result.Data);
                }
            }

            return allAssets;
        }

        private async Task<RateResponse> GetApiRateResponseAsync(HttpClient client, string apiUrl)
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RateResponse>(data);
            }
            else
            {
                return null;
            }
        }

        public ExchangesModel GetExchangeDetails(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}exchanges/{id}";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ApiResponseExchange>(data);
                    return result.Data;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<MarketModel> GetMarketCoins(string exchangeId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{BaseUrl}markets?exchangeId={exchangeId}";

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    CoinMarketsResponse marketsResponse = JsonConvert.DeserializeObject<CoinMarketsResponse>(json);

                    if (marketsResponse != null && marketsResponse.Data != null)
                    {
                        return marketsResponse.Data;
                    }
                }

                return null;
            }
        }

    }
}
