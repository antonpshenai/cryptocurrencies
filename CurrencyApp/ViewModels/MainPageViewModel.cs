using CurrencyApp.Models;
using CurrencyApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CurrencyApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
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

        public MainPageViewModel()
        {
            _coinCapAPIService = new CoinCapAPIService();
            LoadAssets();
        }

        private void LoadAssets()
        {
            List<CurrencyModel> assets = _coinCapAPIService.GetTopAssets();
            if (assets != null)
            {
                Assets = new ObservableCollection<CurrencyModel>(assets);
            }
        }
    }
}
