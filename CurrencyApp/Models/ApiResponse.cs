using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class ApiResponse
    {
        public List<CurrencyModel> Data { get; set; }
    }

    public class ApiResponseExchanges
    {
        public List<ExchangesModel> Data { get; set; }
    }

    public class ApiResponseCoin
    {
        public CoinModel Data { get; set; }
    }

    public class CoinMarketsResponse
    {
        public List<MarketModel> Data { get; set; }
    }

    public class CoinHistoryResponse
    {
        public List<CoinHistoryDataModel> Data { get; set; }
    }
}
