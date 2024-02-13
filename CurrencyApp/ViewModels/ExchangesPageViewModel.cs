using CurrencyApp.Models;
using CurrencyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace CurrencyApp.ViewModels
{
    internal class ExchangesPageViewModel : ViewModelBase
    {
        private ObservableCollection<ExchangesModel> _exchanges;
        private CoinCapAPIService _coinCapAPIService;

        public ObservableCollection<ExchangesModel> Exchanges
        {
            get { return _exchanges; }
            set
            {
                _exchanges = value;
                OnPropertyChanged(nameof(Exchanges));
            }
        }

        public ExchangesPageViewModel()
        {
            _coinCapAPIService = new CoinCapAPIService();
            LoadAssetsAsync(); // Call the asynchronous method directly
        }

        private  void LoadAssetsAsync()
        {
            List<ExchangesModel> exchanges =  _coinCapAPIService.GetExchangesDetails();
            if (exchanges != null)
            {
                Exchanges = new ObservableCollection<ExchangesModel>(exchanges);
            }
        }
    }
}

