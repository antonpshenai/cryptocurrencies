﻿using CurrencyApp.Models;
using CurrencyApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            LoadAssetsAsync();
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

