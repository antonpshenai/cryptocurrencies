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
            const int pageSize = 100; // Adjust the page size based on the API's limitations
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
                            break; // No more assets

                        allAssets.AddRange(result.Data);
                        offset += pageSize;
                    }
                    else
                    {
                        break; // Stop in case of an error
                    }
                } while (true);
            }

            return allAssets;
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

        
    }
}
