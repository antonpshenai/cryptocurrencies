using CurrencyApp.Models;
using CurrencyApp.Services;
using System.Collections.Generic;

namespace CurrencyApp.ViewModels
{
    public class ExchangePageViewModel : ViewModelBase

    {
        private readonly CoinCapAPIService _coinCapAPIService;
        private readonly string _exchangeId;
        private ExchangesModel _exchange;

        public ExchangesModel Exchange
        {
            get { return _exchange; }
            set
            {
                _exchange = value;
                OnPropertyChanged(nameof(Exchange));
            }
        }

        public ExchangePageViewModel(string exchangeId)
        {
            _exchangeId = exchangeId;
            _coinCapAPIService = new CoinCapAPIService();
            GetApiCoin();
        }
        public void GetApiCoin()
        {

            var result = _coinCapAPIService.GetExchangeDetails(_exchangeId);
            if (result != null)
            {
                Exchange = result;
            }

            var markets = _coinCapAPIService.GetMarketCoins(_exchangeId);
            if (markets != null)
            {
                var uniqueMarkets = GetUniqueExchangeIds(markets);
                Exchange.Markets = uniqueMarkets;
            }
        }

        private List<MarketModel> GetUniqueExchangeIds(List<MarketModel> markets)
        {
            HashSet<string> uniqueExchangeIds = new HashSet<string>();

            List<MarketModel> uniqueMarkets = new List<MarketModel>();

            foreach (var market in markets)
            {
                if (uniqueExchangeIds.Add(market.BaseSymbol))
                {
                    uniqueMarkets.Add(market);
                }
            }

            return uniqueMarkets;
        }
    }
}
