using CurrencyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Services
{
    public class CoinCapAPIService
    {
        private const string BaseUrl = "https://api.coincap.io/v2/";
      

        public  List<CurrencyModel> GetTopAssets(int limit = 10)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}assets?limit={limit}";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data =  response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ApiResponse>(data);
                    return result?.Data;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<CurrencyModel> GetAssets()
        {
            const int pageSize = 100;
            int offset = 0;
            List<CurrencyModel> allAssets = new List<CurrencyModel>();

            using (HttpClient client = new HttpClient())
            {
                do
                {
                    string apiUrl = $"{BaseUrl}assets?limit={pageSize}&offset={offset}";
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<ApiResponse>(data);

                        if (result?.Data == null || result.Data.Count == 0)
                            break;

                        allAssets.AddRange(result.Data);
                        offset += pageSize;
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }

            return allAssets;
        }

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
                } while (apiRequests.Count < 20); // For example, limit to 20 parallel requests

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
                return null; // or throw an exception, depending on your error handling strategy
            }
        }

        public CurrencyModel GetCurrencyDetails(string currencyId)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}assets/{currencyId}";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<CurrencyModel>(data);
                    return result;
                }
                else
                {
                    return null;
                }
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


    }
}
