using System.Collections.Generic;

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
        public CurrencyModel Data { get; set; }
    }

    public class CoinMarketsResponse
    {
        public List<MarketModel> Data { get; set; }
    }

    public class CoinHistoryResponse
    {
        public List<CoinHistoryDataModel> Data { get; set; }
    }

    public class RateResponse
    {
        public List<RateModel> Data { get; set; }
    }
    public class ApiResponseExchange
    {
        public ExchangesModel Data { get; set; }
    }
}
