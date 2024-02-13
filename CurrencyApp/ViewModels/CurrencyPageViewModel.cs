using CurrencyApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CurrencyApp.Models;
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
                OnPropertyChanged(nameof(Assets));
            }
        }

        public CurrencyPageViewModel()
        {
            _coinCapAPIService = new CoinCapAPIService();
            LoadAssetsAsync(); // Call the asynchronous method directly
        }

        private async void LoadAssetsAsync()
        {
            List<CurrencyModel> assets = await _coinCapAPIService.GetAssetsAsync();
            if (assets != null)
            {
                Assets = new ObservableCollection<CurrencyModel>(assets);
            }
        }
    }
}
