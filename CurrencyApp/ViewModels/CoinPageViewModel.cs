using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CurrencyApp.Models;
using CurrencyApp.Services;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace CurrencyApp.ViewModels
{
    public class CoinPageViewModel : ViewModelBase

    {
        private readonly CoinCapAPIService _coinCapAPIService;
        private readonly string _coinId;
        private CoinModel _coin;

        public CoinModel Coin
        {
            get { return _coin; }
            set
            {
                _coin = value;
                OnPropertyChanged(nameof(Coin));
            }
        }

        public CoinPageViewModel(string coinId) 
        {
            _coinId = coinId;
            _coinCapAPIService = new CoinCapAPIService();
            GetApiCoin();
        }
        public void GetApiCoin() 
        {

            var result = _coinCapAPIService.GetCoinDetails(_coinId);
            if (result != null)
            {
                Coin = result;
            }

            var markets = _coinCapAPIService.GetCoinMarkets(_coinId);
            if (markets != null)
            {
                var uniqueMarkets = GetUniqueExchangeIds(markets);
                Coin.Markets = uniqueMarkets;
            }

            var historicalData = _coinCapAPIService.GetCoinHistoricalData(_coinId);

            if (historicalData != null)
            {

                Coin.HistoricalDataChartSeries = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Price (USD)",
                        Values = new ChartValues<double>(historicalData.Select(data => data.PriceUsd))
                    }
                };
                Coin.HistoricalDataLabels = historicalData.Select(data => data.Date.ToString("yyyy-MM-dd")).ToList();

            }

        }

        private List<MarketModel> GetUniqueExchangeIds(List<MarketModel> markets)
        {
            HashSet<string> uniqueExchangeIds = new HashSet<string>();

            List<MarketModel> uniqueMarkets = new List<MarketModel>();

            foreach (var market in markets)
            {
                if (uniqueExchangeIds.Add(market.ExchangeId))
                {
                    uniqueMarkets.Add(market);
                }
            }

            return uniqueMarkets;
        }
    }
}
