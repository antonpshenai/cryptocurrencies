﻿using CurrencyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CurrencyApp.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyApp.ViewModels
{
    public class CurrencyPageViewModel : ViewModelBase
    {
        private ObservableCollection<CurrencyModel> _assets;
        private CoinCapAPIService _coinCapAPIService;

        public ObservableCollection<CurrencyModel> Assets
        {
            get { return _assets; }
            set
            {
                _assets = value;
                OnPropertyChanged(nameof(CurrencyModel));
            }
        }

        public CurrencyPageViewModel()
        {
            _coinCapAPIService = new CoinCapAPIService();
            LoadAssets();
        }

        private void LoadAssets()
        {
            List<CurrencyModel> assets = _coinCapAPIService.GetAssets();
            if (assets != null)
            {
                Assets = new ObservableCollection<CurrencyModel>(assets);
            }
        }
    }
}